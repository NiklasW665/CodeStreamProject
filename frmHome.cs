using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
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
            EnsureFolderExits(playlistFolder);
            EnsureFolderExits(userIconFolder);
            EnsureFolderExits(playlistIconFolder);
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
            dgvPlaylists.MultiSelect = true;
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
                        string oldPath = FindIconPath(username);
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
        private string FindIconPath(string path)
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
            Image image = null;
            try
            {
                string existingPath = FindIconPath(username);

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
        private string PlaylistIcon(string playlistName)
        {
            string[] extensions = { ".png", ".jpg", ".jpeg", ".bmp" };
            for (int i = 0; i < extensions.Length; i++)
            {
                string candidate = Path.Combine(playlistIconFolder, playlistName + extensions[i]);
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }
            return null;
        }
        //this functions load the playlist of the current user for the playslist form
        public void LoadPlaylist(string username)
        {
            //lstPlaylists.Items.Clear();
            playlistIconList.Images.Clear();
            //reset the in-memory list
            allPlaylists.Clear();
            dgvPlaylists.Rows.Clear();
            //openPlaylist();
            try
            {
                string[] files = Directory.GetFiles(playlistFolder, "*.txt");
                for (int i = 0; i < files.Length; i++)
                {
                    string name = Path.GetFileNameWithoutExtension(files[i]);
                    //Create a playlist object for each file**
                    Playlist j = new Playlist(name, "Unknown Artist", "Unknown Genre", TimeSpan.Zero, "Unknown Path");

                    //read songs from the file and add them to the playlist object**
                    string[] lines = File.ReadAllLines(files[i]);
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string songTitle = line.Split(',')[0];
                            Song newSong = new Song(songTitle);
                            j.AddSong(newSong);
                        }
                    }
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
                }
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
            try
            {
                string selectedPlaylist = dgvPlaylists.SelectedRows[0].Cells["PlaylistName"].Value.ToString();
                string playlistPath = Path.Combine(playlistFolder, selectedPlaylist + ".txt");
                if (!File.Exists(playlistPath))
                {
                    MessageBox.Show("The selected playlist does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadPlaylist(username);
                    return;
                }

                frmPlaylist playlist = new frmPlaylist(selectedPlaylist, playlistPath);
                //lstPlaylists.Items.Add(playlist);

                playlist.FormClosed += (s, args) =>
                {
                    LoadPlaylist(username); // Refresh the playlist list when the playlist form is closed
                    LoadStats();
                };
                playlist.ShowDialog();
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
            btnUploadSong.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnUploadSong.ForeColor = Color.White;
            btnOpenPlaylist.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnOpenPlaylist.ForeColor = Color.White;
            dgvPlaylists.BackgroundColor = ColorTranslator.FromHtml("#B1E5F2");
            dgvPlaylists.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B1E5F2");
            grpStats.BackColor = ColorTranslator.FromHtml("#0000");
            grpStats.ForeColor = Color.White;
            btnDeletePlaylist.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnDeletePlaylist.ForeColor = Color.White;
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
                string playlistPath = Path.Combine(playlistFolder, playlistName + ".txt");
                if (File.Exists(playlistPath))
                {
                    MessageBox.Show("A playlist with that name already exists", "Duplicte Playlist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (StreamWriter writer = File.CreateText(playlistPath))
                {

                }
                LoadPlaylist(username);
                LoadStats();
                MessageBox.Show("Playlist\"" + playlistName + "\" was created.", "Playlist Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create playlist:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddSongToPlaylist(string playlistName, string songTitle, string songFilePath)
        {
            string path = Path.Combine(playlistFolder, playlistName + ".txt");
            try
            {
                //Skip if this song is already in the playlist to avoid duplicates
                if (File.Exists(path))
                {
                    string[] existingLines = File.ReadAllLines(path); // Reads everyline stored in the plalist's .txt file.
                    foreach (string line in existingLines)
                    {
                        //split the line into its 5 parts using the | as a divoder, then just take the first part which is the song's name.
                        if (line.StartsWith(songTitle + "|", StringComparison.OrdinalIgnoreCase))
                        {
                            return;
                        }
                    }
                }
                string entry = songTitle + "|Unknown Artist|Unkown Album| Unkown Genre|" + songFilePath;
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(entry);
                }
                foreach (Playlist p in allPlaylists)
                {
                    if (p.Title == playlistName)
                    {
                        Song newSong = new Song(songTitle);
                        p.AddSong(newSong);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add song to" + "\n" + playlistName + " " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUploadSong_Click(object sender, EventArgs e)
        {
            if (allPlaylists.Count == 0)
            {
                MessageBox.Show("Create a playlist first before adding songs.", "No Playlists",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Audio Files (*.mp3;*.wav;*.wma)|*.mp3;*.wav;*.wma";
                ofd.Title = "Select a Song to Upload";

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string songTitle = Path.GetFileNameWithoutExtension(ofd.FileName);
                string songFilePath = ofd.FileName;

                //Build the list of playlist names to show as checkboxes in the popup
                List<string> playlistNames = new List<string>();
                foreach (Playlist p in allPlaylists)
                {
                    playlistNames.Add(p.Title);
                }
                //Show the popup and wait for the user to pick playlists
                using (frmSelectPlaylists selectForm = new frmSelectPlaylists(playlistNames))
                {
                    if (selectForm.ShowDialog() != DialogResult.OK)
                    {
                        return;// use this when the user cancels or picks nothing
                    }
                    foreach (string playlistName in selectForm.SelectedPlaylists)
                    {
                        AddSongToPlaylist(playlistName, songTitle, songFilePath);
                    }
                }
                //Refresh the Home page so the new song counts show up immediately
                LoadPlaylist(username);
                LoadStats();

                MessageBox.Show("Song added to selected playlists.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnOpenPlaylist_Click(object sender, EventArgs e)
        {
            openPlaylist();
        }

        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            //Make sure that the user actually selected a playlist row first
            if(dgvPlaylists.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a playlist to delete.", "No playlist selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Get the name of the playlist the user clicked on
            string playlistName = dgvPlaylists.SelectedRows[0].Cells["PlaylistName"].Value.ToString();

            //Ask the user to confirm before deleting to prevent accidental deletions
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete \"" + playlistName + "\"? This cannot be undone.", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //If the user clicked "No", stop here and do nothing
            if(confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                //Build the full file path of the playlist's .txt file and delete it.
                string playlistPath = Path.Combine(playlistFolder, playlistName + ".txt");
                if(File.Exists(playlistPath))
                {
                    File.Delete(playlistPath);
                }
                //Delete the playlist's cover image by image extension 
                string[] extensions = { ".png", ".jpg", ".jpeg", ".bmp" };
                for ( int i = 0; i< extensions.Length; i++)
                {
                    string iconPath = Path.Combine(playlistIconFolder, playlistName + extensions[i]);
                    if(File.Exists(iconPath))
                    {
                        File.Delete(iconPath);
                    }
                }
                //Remove the plalist from the memory and loadstats
                Playlist playlistToRemove = null;
                foreach( Playlist p in allPlaylists)
                {
                    if(p.Title == playlistName)
                    {
                        playlistToRemove = p;
                        break;
                    }
                }
                if(playlistToRemove != null)
                {
                    allPlaylists.Remove(playlistToRemove);
                }
                //Refresh the grid and stats so the deleted playlist disappears from the home screen.
                LoadPlaylist(username);
                LoadStats();

                MessageBox.Show("Playlist \"" + playlistName + "\" was deleted.", "Playlist Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not delete playlist: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
