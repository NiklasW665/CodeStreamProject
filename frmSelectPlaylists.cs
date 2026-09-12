using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeStream20
{
    public partial class frmSelectPlaylists : Form
    {
        public List<string> SelectedPlaylists = new List<string>();
        public frmSelectPlaylists(List<string> allPlaylistNames)
        {
            InitializeComponent();
            foreach (string name in allPlaylistNames)
            {
                cbxListPlaylists.Items.Add(name);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedPlaylists.Clear();
            for (int i = 0; i < cbxListPlaylists.CheckedItems.Count; i++)
            {
                string playlistName = cbxListPlaylists.CheckedItems[i].ToString();
                SelectedPlaylists.Add(playlistName);
            }
                if (SelectedPlaylists.Count == 0)
                {
                    MessageBox.Show("Please select at least one playlist.", "No Playlist Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
     
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
