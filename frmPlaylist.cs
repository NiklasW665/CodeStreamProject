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
            //LoadPlaylistData();
        }
    }
}
