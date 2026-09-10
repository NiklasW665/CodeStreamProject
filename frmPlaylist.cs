using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeStream20
{
    public partial class frmPlaylist : Form
    {
        public string? SelectedPlaylist { get; }
        public string PlaylistPath { get; }
        private string playlistIconFolder = Path.Combine(Application.StartupPath, "PlaylistIcon");
        //Puts the PlayListIcon folder in the application startup path

        public frmPlaylist()
        {
            InitializeComponent();
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

        private void lblCreationDateValue_Click(object sender, EventArgs e)
        {
            //Creation date of the playlist, only set to now as a placeholder
            DateTime creationDate = DateTime.Now;

            lblCreationDateValue.Text = creationDate.ToString("dd MMMM yyyy");
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
                    if (!string.IsNullOrEmpty(SelectedPlaylist))
                    {
                        // Remove old art in any format
                        foreach (string oldExt in new[] { ".png", ".jpg", ".jpeg", ".bmp" })
                        {
                            string old = Path.Combine(playlistIconFolder, SelectedPlaylist + oldExt);
                            if (File.Exists(old)) File.Delete(old);
                        }
                        string savePath = Path.Combine(playlistIconFolder, SelectedPlaylist + Path.GetExtension(openFileDialog.FileName));
                        File.Copy(openFileDialog.FileName, savePath, true);
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

        private void frmPlaylist_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#000424");
            this.ForeColor = Color.White;
            btnUploadPlaylistArt.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnUploadPlaylistArt.ForeColor = Color.White;
            btnBackToHome.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnBackToHome.ForeColor = Color.White;
            //LoadPlaylistData();
            if (!string.IsNullOrEmpty(SelectedPlaylist))
            {
                string[] exts = { ".png", ".jpg", ".jpeg", ".bmp" };
                foreach (string ext in exts)
                {
                    string iconPath = Path.Combine(playlistIconFolder, SelectedPlaylist + ext);
                    //getting the icon from the playlist icon folder
                    if (File.Exists(iconPath))
                    {
                        pBoxCoverArt.Image = Image.FromFile(iconPath);
                        break;
                    }
                }
            }
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
