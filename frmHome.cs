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
        public frmHome(string username)
        {
            InitializeComponent();
            EnsureFolderExits(playlistFolder);
            EnsureFolderExits(userIconFolder);

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
                    } catch (Exception ex)
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
                if (File.Exists(candidate)) {
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
                    using (FileStream stream = new FileStream(existingPath, FileMode.Open, FileAccess.Read))
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

        //this functions load the playlist of the current user for the playslist form
        public void LoadPlaylist(string username)
        {
            lstPlaylists.Items.Clear();
            try
            {
                string[] files = Directory.GetFiles(playlistFolder, "*.txt");
                for (int i = 0; i < files.Length; i++)
                {
                    string name = Path.GetFileNameWithoutExtension(files[i]);
                    lstPlaylists.Items.Add(name);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error loading playlists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                for (int i = 0; i< playlistFiles.Length; i++)
                {
                    //use a try catch inside the for loop so that the program can cstch any individual problematic files and proceed with the rest
                    try
                    {
                        using(StreamReader reader = new StreamReader(playlistFiles[i]))
                        {
                            string line; // Declare a variable that will store the lines as they are read
                            while((line = reader.ReadLine()) !=null) // use a while loop to read line by line
                            {
                                if(!string.IsNullOrWhiteSpace(line)) //check if the line is empty
                                {
                                    totalTracks++; // we must increase the total as we go
                                }
                            }
                        }
                    }
                    catch(Exception ex) //Catch an individual problem file
                    {
                        MessageBox.Show("Error reading playlist file" + playlistFiles[i] + ":" + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //STAT3:
                string topArtist = "N/A"; //NB!! fix this 

                //Display the results in their respective labels
                lblTotalplaylists.Text = totalPlaylists.ToString();
                lblTrackCount.Text = totalTracks.ToString();
                lblTopArtist.Text = topArtist;
            }
            catch(Exception ex) // Catch for the first Try
            {
                MessageBox.Show("Could not load stats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        



    }
}
