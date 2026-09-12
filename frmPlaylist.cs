using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CodeStream20
{
    public partial class frmPlaylist : Form
    {
        private List<Song> songs = new List<Song>();
        public string? SelectedPlaylist { get; }
        public string PlaylistPath { get; } = string.Empty;
        //private string playlistIconFolder = Path.Combine(Application.StartupPath, "PlaylistIcon");
        //Puts the PlayListIcon folder in the application startup path
        private Playlist? currentPlaylist;
        public frmPlaylist()
        {
            InitializeComponent();
        }
        public frmPlaylist(Playlist playlist)
        {
            InitializeComponent();
            currentPlaylist = playlist;
            SelectedPlaylist = playlist.Title;
            //PlaylistPath = playlist.FilePath;
        }

        public frmPlaylist(string? selectedPlaylist, string playlistPath)
        {
            InitializeComponent();
            SelectedPlaylist = selectedPlaylist;
            PlaylistPath = playlistPath;
        }

        private void lblPlaylistTitle_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTrackCount()
        {
            lblTrackCountValue.Text = songs.Count.ToString();
        }

        private void lblCreationDateValue_Click(object sender, EventArgs e)
        {
        }

        private void btnUploadPlaylistArt_Click(object sender, EventArgs e)
        {
            //try catch block to handle any exceptions that may occur during the file upload process
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pBoxCoverArt.Image = Image.FromFile(openFileDialog.FileName);
                    pBoxCoverArt.Image = Image.FromFile(openFileDialog.FileName);
                    if (currentPlaylist != null)
                    {
                        DataManager.SavePlaylistIcon(currentPlaylist, openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error uploading the playlist artwork.\n\n" + ex.Message,
                    "Upload Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //Load song into the datagridview from the playlist file
        private void LoadSongs()
        {
            try
            {
                songs.Clear();
                if (currentPlaylist != null)
                {
                    // Load songs from the current playlist
                    songs.AddRange(currentPlaylist.Songs);
                }
                else if (File.Exists(PlaylistPath))
                {
                    string[] lines = File.ReadAllLines(PlaylistPath);

                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] data = line.Split('|');

                            if (data.Length >= 5)
                            {
                                Song song = new Song();

                                song.Name = data[0];
                                song.Artist = data[1];
                                song.Album = data[2];
                                song.Genre = data[3];
                                song.FilePath = data[4];

                                songs.Add(song);
                            }
                        }
                    }
                }

                dgvSongs.Rows.Clear();

                foreach (Song song in songs)
                {
                    dgvSongs.Rows.Add(
                        song.Name,
                        song.Artist,
                        song.Album,
                        song.Genre
                    );
                }
                UpdateTrackCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error loading the songs.\n\n" + ex.Message,
                    "Song Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //Selecting a song to play when double-clicked in the DataGridView
        private void dgvSongs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Make sure the user clicked a valid song row
                if (e.RowIndex >= 0 && e.RowIndex < songs.Count)
                {
                    Song selectedSong = songs[e.RowIndex];

                    // Check that the music file still exists
                    if (File.Exists(selectedSong.FilePath))
                    {
                        axWindowsMediaPlayer1.URL = selectedSong.FilePath;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    else
                    {
                        MessageBox.Show(
                            "The song file could not be found.",
                            "File Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error playing the song.\n\n" + ex.Message,
                    "Playback Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void frmPlaylist_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#000424");
            this.ForeColor = Color.White;

            lblPlaylistTitle.Text = SelectedPlaylist ?? "Playlist";

            // Upload Playlist Art button
            btnUploadPlaylistArt.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnUploadPlaylistArt.ForeColor = Color.White;

            // Back to Home button
            btnBackToHome.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnBackToHome.ForeColor = Color.White;

            // Add Song button
            

            // Delete Song button
            btnDeleteSong.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnDeleteSong.ForeColor = Color.White;
            btnDeleteSong.Enabled = true;
            // Delete Playlist button
            btnDeletePlaylist.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnDeletePlaylist.ForeColor = Color.White;

            // Sort button
            btnSort.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnSort.ForeColor = Color.White;

<<<<<<< HEAD
            //DataGridView
            // Make sure song grid text is always readable, regardless of the form's dark theme
            dgvSongs.DefaultCellStyle.BackColor = Color.White;
            dgvSongs.DefaultCellStyle.ForeColor = Color.Black;
            dgvSongs.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvSongs.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            // Load playlist artwork using DataManager
            if (currentPlaylist != null)
            {
                string? iconPath = DataManager.GetPlaylistIconPath(currentPlaylist);
                if (iconPath != null)
=======
            // Load playlist artwork
            if(currentPlaylist != null)
            {
                string? iconPath = DataManager.GetPlaylistIconPath(currentPlaylist);
                if(iconPath != null)
>>>>>>> 806224d162fdcdd0ff8470acb40c07ad7ece7c22
                {
                    pBoxCoverArt.Image = Image.FromFile(iconPath);
                }
            }

            // Sets the creation date of the playlist to the date the file was created
<<<<<<< HEAD
            if (currentPlaylist != null)
=======
            if(currentPlaylist != null)
            {
                lblCreationDate.Text = currentPlaylist.CreatedDate.ToString("dd MMMM yyyy");
            } else
            if (File.Exists(PlaylistPath))
>>>>>>> 806224d162fdcdd0ff8470acb40c07ad7ece7c22
            {
                string playlistFilePath = DataManager.GetPlaylistFilePath(currentPlaylist);
                if (File.Exists(playlistFilePath))
                {
                    DateTime creationDate = File.GetCreationTime(playlistFilePath);
                    lblCreationDateValue.Text = creationDate.ToString("dd MMMM yyyy");
                }
            }

            // Load songs
            LoadSongs();
        }



        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method to save the songs in the playlist to the playlist file
        private void SaveSongs()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(PlaylistPath, false))
                {
                    foreach (Song song in songs)
                    {
                        writer.WriteLine(
                            song.Name + "|" +
                            song.Artist + "|" +
                            song.Album + "|" +
                            song.Genre + "|" +
                            song.FilePath
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error saving the playlist.\n\n" + ex.Message,
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //Delete Songs from DataGridView and the playlist file
        private void btnDeleteSong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSongs.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Please select a song to delete.",
                        "No Song Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                int index = dgvSongs.CurrentRow.Index;

                if (index >= 0 && index < songs.Count)
                {
                    Song selectedSong = songs[index];

                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete \"" + selectedSong.Name + "\" from this playlist?",
                        "Delete Song",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Remove the song from the current playlist
                        songs.RemoveAt(index);

                        if (currentPlaylist != null)
                        {
                            // Keep the real Playlist object in sync, then save it as JSON
                            currentPlaylist.Songs.RemoveAt(index);
                            DataManager.savePlaylist(currentPlaylist);
                        }
                        else
                        {
                            SaveSongs(); // fallback for the old .txt-based path, just in case
                        }

                        LoadSongs();

                        MessageBox.Show(
                            "Song deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error deleting the song.\n\n" + ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSort.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please select what you want to sort by.",
                        "Sort Songs",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                string sortBy = cmbSort.SelectedItem.ToString();

                if (sortBy == "Name")
                {
                    songs.Sort((x, y) => x.Name.CompareTo(y.Name));
                }
                else if (sortBy == "Artist")
                {
                    songs.Sort((x, y) => x.Artist.CompareTo(y.Artist));
                }
                else if (sortBy == "Album")
                {
                    songs.Sort((x, y) => x.Album.CompareTo(y.Album));
                }
                else if (sortBy == "Genre")
                {
                    songs.Sort((x, y) => x.Genre.CompareTo(y.Genre));
                }

                dgvSongs.Rows.Clear();

                foreach (Song song in songs)
                {
                    dgvSongs.Rows.Add(
                        song.Name,
                        song.Artist,
                        song.Album,
                        song.Genre
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error sorting the songs.\n\n" + ex.Message,
                    "Sort Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (currentPlaylist == null)
            {
                MessageBox.Show(
                    "No playlist is currently loaded.",
                    "Delete Playlist",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the playlist \"" + currentPlaylist.Title + "\"?",
                "Delete Playlist",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result != DialogResult.Yes) 
            {
                return;
            }
            try
            {
                DataManager.deletePlaylist(currentPlaylist);
                MessageBox.Show(
                    "Playlist deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "There was an error deleting the playlist.\n\n" + ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
