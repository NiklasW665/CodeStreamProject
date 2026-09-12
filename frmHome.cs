using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace CodeStream20
{
    public partial class frmHome : Form
    {
        private string username;
        //check whether the user exist aswell as the playlist
        private string playlistFolder = Path.Combine(Application.StartupPath, "Playlist");
        private string userIconFolder = Path.Combine(Application.StartupPath, "UserIcon");

        //for the listview
        private string playlistIconFolder = Path.Combine(Application.StartupPath, "PlaylistIcon");
        private ImageList playlistIconList = new ImageList();
        //list that stores All playlists created in the program.
        private List<Playlist> allPlaylists = new List<Playlist>();
        public frmHome(string username)
        {
            InitializeComponent();
            //EnsureFolderExits(playlistFolder);
            EnsureFolderExits(userIconFolder);
            //EnsureFolderExits(playlistIconFolder);
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Cover";
            imgCol.Name = "CoverArt";
            imgCol.Width = 70;
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvPlaylists.Columns.Add(imgCol);

            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.HeaderText = "Playlist Name";
            nameCol.Name = "PlaylistName";
            nameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPlaylists.Columns.Add(nameCol);

            dgvPlaylists.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlaylists.MultiSelect = true;//let the user tick multiple playlists to add a song to
            dgvPlaylists.ReadOnly = true;
            dgvPlaylists.RowHeadersVisible = false;
            dgvPlaylists.AllowUserToAddRows = false;
            dgvPlaylists.RowTemplate.Height = 70;
            dgvPlaylists.DoubleClick += dgvPlaylists_DoubleClick;

            this.username = username;
            lblWelcome.Text = "Welcome back " + username + "!";
            //the is for the user icons for each user
            picUserIcon.Cursor = Cursors.Hand;// change icon
            picUserIcon.Click += PicUserIcon_Click; // let user click and change icon

            LoadUserIcon(username); // load user icon
            LoadPlaylist(username); // load their playlist
            LoadStats(); //T:Loads the stats part
                         //user name label under icon
            lblUser.Text = username;
        }

        //allow the user to change their icon by clicking on it and selecting a new image file
        private void PicUserIcon_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                ofd.Title = "Select a Profile Picture";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string? oldPath = FindIconPath(username);
                        if (oldPath != null)
                        {
                            File.Delete(oldPath);
                        }
                        string ex = Path.GetExtension(ofd.FileName);
                        string savedPath = Path.Combine(userIconFolder, username + ex);
                        File.Copy(ofd.FileName, savedPath, true);
                        LoadUserIcon(username);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not save profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        //find user icons
        private string? FindIconPath(string path)
        {
            string[] extensions = { ".png", ".jpg", ".jpeg", ".bmp" };
            for (int i = 0; i < extensions.Length; i++)
            {
                string candidate = Path.Combine(userIconFolder, path + extensions[i]);
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }
            return null;
        }
        //this function load's the current user's icon
        public void LoadUserIcon(string username)
        {
            Image? image = null;
            try
            {
                string? existingPath = FindIconPath(username);

                if (existingPath != null)
                {
                    byte[] imageByte = File.ReadAllBytes(existingPath);
                    using (MemoryStream stream = new MemoryStream(imageByte))
                    {
                        image = new Bitmap(stream);
                    }
                }
                else
                {
                    image = SystemIcons.Application.ToBitmap();
                }
                int diameter = Math.Min(picUserIcon.Width, picUserIcon.Height);
                Image circularImage = new Bitmap(diameter, diameter);
                // Create a circular mask
                using (Graphics g = Graphics.FromImage(circularImage))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse(0, 0, diameter, diameter);
                        g.SetClip(path);
                        g.DrawImage(image, 0, 0, diameter, diameter);
                    }
                }

                picUserIcon.Image = circularImage;

                picUserIcon.Width = diameter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picUserIcon.Image = SystemIcons.Application.ToBitmap();
            }
        }
        //this function find the playlist cover
        //folder (Playlist/Shared) or (Playlist?<username> instead of the user icon folder)
        private string? PlaylistIcon(Playlist playlist)//uses playlist objects
        {
            return DataManager.GetPlaylistIconPath(playlist);
        }
        //this functions load the playlist of the current user for the playslist form
        public void LoadPlaylist(string username)
        {
            //lstPlaylists.Items.Clear();
            //dgvPlaylists.Rows.Clear();
            //playlistIconList.Images.Clear();
            //reset the in-memory list
            allPlaylists.Clear();
            dgvPlaylists.Rows.Clear();
            //openPlaylist();
            try
            {
                allPlaylists = DataManager.loadUserPlaylists(username);
                foreach (Playlist playlist in allPlaylists)
                {
                    string? iconpath = PlaylistIcon(playlist);
                    Image coverImage;
                    try
                    {
                        coverImage = (iconpath != null) ? new Bitmap(new MemoryStream(File.ReadAllBytes(iconpath))) : SystemIcons.Application.ToBitmap();
                    }
                    catch
                    {
                        coverImage = SystemIcons.Application.ToBitmap();
                    }
                    dgvPlaylists.Rows.Add(coverImage, playlist.Title);
                }
                string[] files = Directory.GetFiles(playlistFolder, "*.txt");
                /* (int i = 0; i < files.Length; i++)
                //{
                    //string name = Path.GetFileNameWithoutExtension(files[i]);
                    //Create a playlist object for each file**
                   // Playlist j = new Playlist(name, "Unknown Artist", "Unknown Genre", TimeSpan.Zero, "Unknown Path");

                    //read songs from the file and add them to the playlist object**
                   // string[] lines = File.ReadAllLines(files[i]);
                   // foreach(string line in lines)
                   // {
                     //   if(!string.IsNullOrWhiteSpace(line))
                       // {
                         //   string songTitle = line.Split(',')[0];
                           // j.AddSong(songTitle);
                        //}
                   // }
                    allPlaylists.Add(j);
                    string iconpath = PlaylistIcon(name);
                    Image coverImage;
                    try
                    {
                        coverImage = (iconpath != null) ? new Bitmap(new MemoryStream(File.ReadAllBytes(iconpath))) : SystemIcons.Application.ToBitmap();

                    }
                    catch
                    {
                        coverImage = SystemIcons.Application.ToBitmap();
                    }
                    dgvPlaylists.Rows.Add(coverImage, name);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading playlists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //this function opens the playlist form when the user double clicks on a playlist in the listbox
        private void openPlaylist()
        {
            if (dgvPlaylists.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a playlist to open.", "No Playlist Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string selectedPlaylist = dgvPlaylists.SelectedRows[0].Cells["PlaylistName"].Value.ToString();
            Playlist? playlist = allPlaylists.Find(p => p.Title.Equals(selectedPlaylist, StringComparison.OrdinalIgnoreCase));
            if (playlist == null)
            {
                MessageBox.Show("Playlist not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadPlaylist(username); // Refresh the playlist list    
                return;
            }
            OpenPlaylistWindow(playlist);
        }
        /*
        private void OpenPlaylistFromFile(string jsonFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                Playlist? playlist = JsonSerializer.Deserialize<Playlist>(json);
                if (playlist != null)
                {
                    frmPlaylist playlistForm = new frmPlaylist(playlist.Title, jsonFilePath);
                    playlistForm.FormClosed += (s, args) =>
                    {
                        LoadPlaylist(username); // Refresh the playlist list when the playlist form is closed
                        LoadStats();
                    };
                    playlistForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Could not load playlist from file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                OpenPlaylistWindow(playlist);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening playlist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }*/
        //Opens a single playlist object in its own window so multiple playlist an be opened
        private void OpenPlaylistWindow(Playlist playlist)
        {
            try
            {
                frmPlaylist playlistForm = new frmPlaylist(playlist.Title, Path.Combine(playlistFolder, playlist.Title + ".txt"));
                playlistForm.FormClosed += (s, args) =>
                {
                    LoadPlaylist(username); // Refresh the playlist list when the playlist form is closed
                    LoadStats();
                };
                playlistForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening playlist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPlaylists_DoubleClick(object sender, EventArgs e)
        {
            openPlaylist();
        }
        private void EnsureFolderExits(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            //UX for the form (basic)
            this.BackColor = ColorTranslator.FromHtml("#000424");
            this.ForeColor = Color.White;
            btnCreatePlaylist.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnCreatePlaylist.ForeColor = Color.White;
            btnAddPlaylist.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnAddPlaylist.ForeColor = Color.White;
            btnOpenPlaylist.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnOpenPlaylist.ForeColor = Color.White;
            dgvPlaylists.BackgroundColor = ColorTranslator.FromHtml("#B1E5F2");
            dgvPlaylists.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B1E5F2");
            grpStats.BackColor = ColorTranslator.FromHtml("#0000");
            grpStats.ForeColor = Color.White;
        }

        //Write the LoadStats method for the Stats
        private void LoadStats()
        {
            try
            {
                //total playlists that exists
                int totalPlaylists = allPlaylists.Count;

                //Count how many songs are in all the playlists combined
                int totalTracks = 0;
                foreach (Playlist i in allPlaylists)
                {
                    totalTracks += i.Songs.Count;
                }

                //Calculate the average songs per playlist
                double averageSongs = 0;
                if (totalPlaylists > 0)// this is to avoid the divideby zero error
                {
                    averageSongs = Convert.ToDouble(totalTracks) / totalPlaylists;
                }

                //Display the results
                lblTotalplaylists.Text = totalPlaylists.ToString();
                lblTrackCount.Text = totalTracks.ToString();
                lblTopArtist.Text = averageSongs.ToString("0.0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load stats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            try
            {
                string playlistName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the new Playlist: ", "Create Playlist", "");
                playlistName = playlistName.Trim();
                if (string.IsNullOrWhiteSpace(playlistName))
                {
                    return;
                }
                char[] charArray = Path.GetInvalidFileNameChars();
                int i = 0;
                while (i < charArray.Length)
                {
                    playlistName = playlistName.Replace(charArray[i], '_');
                    i++;
                }
                bool alreadyExists = allPlaylists.Exists(p => p.Title.Equals(playlistName, StringComparison.OrdinalIgnoreCase));
                if (alreadyExists)
                {
                    MessageBox.Show("A playlist with that name already exists", "Duplicate Playlist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //ask whether the user wants to create a shared playlist or a personal playlist
                DialogResult result = MessageBox.Show("Do you want to create a shared playlist?\"" + "Should" + playlistName + "be shared with everyone?\n" + "Yes your account is public / No keep your account private" + MessageBoxButtons.YesNo + MessageBoxIcon.Question);
                bool IsShared = (result == DialogResult.Yes);
                Playlist newPlaylist = new Playlist(playlistName, "Unknown Artist", "Unknown Genre", TimeSpan.Zero, "Unknown Path")
                {
                    Owner = username,
                    IsShared = IsShared
                };
                //save the playlist object to a file as json in the right folder
                DataManager.savePlaylist(newPlaylist);
                LoadPlaylist(username);
                LoadStats();
                MessageBox.Show("Playlist\"" + playlistName + "\" was created.", "Playlist Created", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured while adding the song:" + ex.Message + "Error");
            }

        }
        private void btnAddPlaylist_Cilck(object sender, EventArgs e)
        {
            if (dgvPlaylists.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a playlist to add a song to.", "No Playlist Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Audio Files (*.mp3; *.wav; *wma)|*.mp3; *.wav; *wma";
                    ofd.Title = "Select a Song to Add";
                    if (ofd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    string songTitle = Path.GetFileNameWithoutExtension(ofd.FileName);
                    //string songName = songTitle + ", " + ofd.FileName;
                    int addedCount = 0;
                    int index = 0;
                    while (index < dgvPlaylists.SelectedRows.Count)
                    {
                        string playlistName = dgvPlaylists.SelectedRows[index].Cells["PlaylistName"].Value.ToString();
                        Playlist? targetPlaylist = allPlaylists.Find(p => p.Title.Equals(playlistName, StringComparison.OrdinalIgnoreCase));
                        //string path = Path.Combine(playlistFolder, playlistName + ".txt");
                        try
                        {
                            if (targetPlaylist == null)
                            {
                                MessageBox.Show("Playlist\"" + playlistName + "\" could not be found.", "Missing Playlist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                index++;
                                continue;
                            }
                            bool exist = targetPlaylist.Songs.Exists(s => s.FilePath.Equals(ofd.FileName, StringComparison.OrdinalIgnoreCase));
                            if (exist)
                            {
                                index++;
                                continue;
                            }
                            Song newSong = new Song(songTitle, "Unknown Artist", "Unknown Genre", TimeSpan.Zero, ofd.FileName);
                            targetPlaylist.AddSong(newSong);
                            DataManager.savePlaylist(targetPlaylist);
                            addedCount++;

                        }
                        catch (Exception exInner)
                        {
                            MessageBox.Show("Could not add song to \"" + playlistName + "\": " + exInner.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        index++;
                    }
                    LoadPlaylist(username);
                    LoadStats();
                    MessageBox.Show("Playlist added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred while adding the playlist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOpenPlaylist_Click(object sender, EventArgs e)
        {
            openPlaylist();
        }

        private void btnBrowsePlaylist_Click(object sender, EventArgs e)
        {   
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Playlist Files (*.json)|*.json";
                ofd.Title = "Browse for a Playlist";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string json = File.ReadAllText(ofd.FileName);
                        Playlist? playlist = JsonSerializer.Deserialize<Playlist>(json);
                        if (playlist == null)
                        {
                            MessageBox.Show("That is not a valid playlist file.", "Invalid Playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        OpenPlaylistWindow(playlist);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening playlist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
            }
        }
    }
}
