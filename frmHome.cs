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
        public frmHome(string username)
        {
            InitializeComponent();
            EnsureFolderExits(playlistFolder);
            EnsureFolderExits(userIconFolder);
            EnsureFolderExits(playlistIconFolder);
            playlistIconList.ImageSize = new Size(64, 64);
            playlistIconList.ColorDepth = ColorDepth.Depth32Bit;
            lstPlaylists.View = View.LargeIcon;
            lstPlaylists.LargeImageList = playlistIconList;
            lstPlaylists.MultiSelect = true;
            lstPlaylists.HideSelection = false;

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
            lstPlaylists.Items.Clear();
            playlistIconList.Images.Clear();
            //openPlaylist();
            try
            {
                string[] files = Directory.GetFiles(playlistFolder, "*.txt");
                for (int i = 0; i < files.Length; i++)
                {
                    string name = Path.GetFileNameWithoutExtension(files[i]);
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
                    playlistIconList.Images.Add(name, coverImage);
                    ListViewItem item = new ListViewItem(name, name);
                    lstPlaylists.Items.Add(item);
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
            if (lstPlaylists.SelectedItems.Count == null)
            {
                MessageBox.Show("Please select a playlist to open.", "No Playlist Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string selectedPlaylist = lstPlaylists.SelectedItems[0].Text;
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

        private void lstPlaylists_DoubleClick(object sender, EventArgs e)
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
            lstPlaylists.BackColor = ColorTranslator.FromHtml("#B1E5F2");
        }
        //Write the LoadStats method
        private void LoadStats()
        {
            //Use a try Catch to wrap the whole method for any unexpected errors
            try
            {
                string[] playlistFiles = Directory.GetFiles(playlistFolder, "*.txt");
                //Stat1: Total Playlist
                int totalPlaylists = playlistFiles.Length; // Use .Length to count the number of playlists
                int totalTracks = 0; // this counter value starts at 0 and will accumulate as the number of playlists are counted
                //STAT2:Use a for loop to go through every playlist 
                for (int i = 0; i < playlistFiles.Length; i++)
                {
                    //use a try catch inside the for loop so that the program can cstch any individual problematic files and proceed with the rest
                    try
                    {
                        using (StreamReader reader = new StreamReader(playlistFiles[i]))
                        {
                            string line; // Declare a variable that will store the lines as they are read
                            while ((line = reader.ReadLine()) != null) // use a while loop to read line by line
                            {
                                if (!string.IsNullOrWhiteSpace(line)) //check if the line is empty
                                {
                                    totalTracks++; // we must increase the total as we go
                                }
                            }
                        }
                    }
                    catch (Exception ex) //Catch an individual problem file
                    {
                        MessageBox.Show("Error reading playlist file" + playlistFiles[i] + ":" + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //STAT3:Average songs per playlist
                double averageSongs = 0;
                if (totalPlaylists > 0)
                {
                    averageSongs = Convert.ToDouble(totalTracks) / totalPlaylists;
                }

                //Display the results in their respective labels
                lblTotalplaylists.Text = totalPlaylists.ToString();
                lblTrackCount.Text = totalTracks.ToString();
                lblTopArtist.Text = averageSongs.ToString("0.0"); //"0.0" to display 1 decimal
            }
            catch (Exception ex) // Catch for the first Try
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

        private void btnAddPlaylist_Click(object sender, EventArgs e)
        {
            if(lstPlaylists.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a playlist to add.", "No Playlist Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string songName = songTitle + ", " + ofd.FileName;
                    int addedCount = 0;
                    int index = 0;
                    while (index < lstPlaylists.SelectedItems.Count)
                    {
                        string playlistName = lstPlaylists.SelectedItems[index].Text;
                        string path = Path.Combine(playlistFolder, playlistName + ".txt");
                        try
                        {
                            if (!File.Exists(path))
                            {
                                MessageBox.Show("Playlist\"" + playlistName + "\" could not be found.", "Missing Playlist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                index++;
                                continue;
                            }
                            bool exist = false;
                            using (StreamReader read = new StreamReader(path))
                            {
                                string line;
                                while((line = read.ReadLine()) != null)
                                {
                                    if(line.Equals(songName, StringComparison.OrdinalIgnoreCase))
                                    {
                                        exist = true;
                                        break;
                                    }
                                }
                            }
                            if (exist)
                            {
                                index++;
                                continue;
                            }

                            using(StreamWriter write = new StreamWriter(path, true))
                            {
                                write.WriteLine(songName);
                            }
                            addedCount++;
                        } catch (Exception exInner)
                        {
                            MessageBox.Show("Could not add song to \"" + playlistName+"\": " + exInner.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        index++;
                    }
                  
                    string selectedPlaylist = lstPlaylists.SelectedItems[0].Text;
                    string destinationPath = Path.Combine(playlistFolder, selectedPlaylist + ".txt");
                    File.Copy(ofd.FileName, destinationPath, true);
                    LoadPlaylist(username);
                    LoadStats();
                    MessageBox.Show("Playlist added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error has occured while adding the song:" + ex.Message + "Error"); 
            }
            
        }
    }
}
