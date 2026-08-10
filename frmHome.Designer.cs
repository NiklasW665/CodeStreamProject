namespace CodeStream20
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            lblWelcome = new Label();
            lblPlaylists = new Label();
            picUserIcon = new PictureBox();
            lblUser = new Label();
            grpStats = new GroupBox();
            flpStats = new FlowLayoutPanel();
            pnlTotalPlaylist = new Panel();
            flpPanel1 = new FlowLayoutPanel();
            lblTotalplaylists = new Label();
            lblCaption1 = new Label();
            pnlHeavyRotation = new Panel();
            panel1 = new Panel();
            pnlHeavy = new Panel();
            flpPanel2 = new FlowLayoutPanel();
            lblTopArtist = new Label();
            lblCaption2 = new Label();
            pnlTracks = new Panel();
            flpPanel3 = new FlowLayoutPanel();
            lblTrackCount = new Label();
            lblCaption3 = new Label();
            btnCreatePlaylist = new Button();
            btnAddPlaylist = new Button();
            lstPlaylists = new ListView();
            ((System.ComponentModel.ISupportInitialize)picUserIcon).BeginInit();
            grpStats.SuspendLayout();
            flpStats.SuspendLayout();
            pnlTotalPlaylist.SuspendLayout();
            flpPanel1.SuspendLayout();
            pnlHeavyRotation.SuspendLayout();
            pnlHeavy.SuspendLayout();
            flpPanel2.SuspendLayout();
            pnlTracks.SuspendLayout();
            flpPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI Black", 14F);
            lblWelcome.Location = new Point(251, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(231, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Message";
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.Font = new Font("Segoe UI Black", 12F);
            lblPlaylists.Location = new Point(314, 85);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(153, 28);
            lblPlaylists.TabIndex = 1;
            lblPlaylists.Text = "Your Playlists:";
            // 
            // picUserIcon
            // 
            picUserIcon.Location = new Point(12, 12);
            picUserIcon.Name = "picUserIcon";
            picUserIcon.Size = new Size(95, 76);
            picUserIcon.TabIndex = 3;
            picUserIcon.TabStop = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 8F);
            lblUser.Location = new Point(30, 94);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(37, 19);
            lblUser.TabIndex = 4;
            lblUser.Text = "User";
            // 
            // grpStats
            // 
            grpStats.Controls.Add(flpStats);
            grpStats.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpStats.Location = new Point(30, 374);
            grpStats.Name = "grpStats";
            grpStats.Size = new Size(797, 191);
            grpStats.TabIndex = 5;
            grpStats.TabStop = false;
            grpStats.Text = "Your Music at a Glance";
            // 
            // flpStats
            // 
            flpStats.Controls.Add(pnlTotalPlaylist);
            flpStats.Controls.Add(pnlHeavy);
            flpStats.Controls.Add(pnlTracks);
            flpStats.Dock = DockStyle.Fill;
            flpStats.Location = new Point(3, 30);
            flpStats.Name = "flpStats";
            flpStats.Size = new Size(791, 158);
            flpStats.TabIndex = 0;
            flpStats.WrapContents = false;
            // 
            // pnlTotalPlaylist
            // 
            pnlTotalPlaylist.Controls.Add(flpPanel1);
            pnlTotalPlaylist.Controls.Add(pnlHeavyRotation);
            pnlTotalPlaylist.Location = new Point(3, 3);
            pnlTotalPlaylist.Name = "pnlTotalPlaylist";
            pnlTotalPlaylist.Size = new Size(200, 100);
            pnlTotalPlaylist.TabIndex = 0;
            // 
            // flpPanel1
            // 
            flpPanel1.Controls.Add(lblTotalplaylists);
            flpPanel1.Controls.Add(lblCaption1);
            flpPanel1.Dock = DockStyle.Fill;
            flpPanel1.FlowDirection = FlowDirection.TopDown;
            flpPanel1.Location = new Point(0, 0);
            flpPanel1.Name = "flpPanel1";
            flpPanel1.Size = new Size(200, 100);
            flpPanel1.TabIndex = 6;
            flpPanel1.WrapContents = false;
            // 
            // lblTotalplaylists
            // 
            lblTotalplaylists.AutoSize = true;
            lblTotalplaylists.Location = new Point(3, 0);
            lblTotalplaylists.Name = "lblTotalplaylists";
            lblTotalplaylists.Size = new Size(23, 28);
            lblTotalplaylists.TabIndex = 6;
            lblTotalplaylists.Text = "0";
            // 
            // lblCaption1
            // 
            lblCaption1.AutoSize = true;
            lblCaption1.Location = new Point(3, 28);
            lblCaption1.Name = "lblCaption1";
            lblCaption1.Size = new Size(133, 28);
            lblCaption1.TabIndex = 7;
            lblCaption1.Text = "Total Playlists";
            // 
            // pnlHeavyRotation
            // 
            pnlHeavyRotation.Controls.Add(panel1);
            pnlHeavyRotation.Location = new Point(200, 0);
            pnlHeavyRotation.Name = "pnlHeavyRotation";
            pnlHeavyRotation.Size = new Size(200, 100);
            pnlHeavyRotation.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 125);
            panel1.TabIndex = 0;
            // 
            // pnlHeavy
            // 
            pnlHeavy.Controls.Add(flpPanel2);
            pnlHeavy.Location = new Point(209, 3);
            pnlHeavy.Name = "pnlHeavy";
            pnlHeavy.Size = new Size(200, 100);
            pnlHeavy.TabIndex = 1;
            // 
            // flpPanel2
            // 
            flpPanel2.Controls.Add(lblTopArtist);
            flpPanel2.Controls.Add(lblCaption2);
            flpPanel2.Dock = DockStyle.Fill;
            flpPanel2.FlowDirection = FlowDirection.TopDown;
            flpPanel2.Location = new Point(0, 0);
            flpPanel2.Name = "flpPanel2";
            flpPanel2.Size = new Size(200, 100);
            flpPanel2.TabIndex = 0;
            flpPanel2.WrapContents = false;
            // 
            // lblTopArtist
            // 
            lblTopArtist.AutoSize = true;
            lblTopArtist.Location = new Point(3, 0);
            lblTopArtist.Name = "lblTopArtist";
            lblTopArtist.Size = new Size(23, 28);
            lblTopArtist.TabIndex = 0;
            lblTopArtist.Text = "0";
            // 
            // lblCaption2
            // 
            lblCaption2.AutoSize = true;
            lblCaption2.Location = new Point(3, 28);
            lblCaption2.Name = "lblCaption2";
            lblCaption2.Size = new Size(190, 56);
            lblCaption2.TabIndex = 1;
            lblCaption2.Text = "Average Songs per Playlist";
            // 
            // pnlTracks
            // 
            pnlTracks.Controls.Add(flpPanel3);
            pnlTracks.Location = new Point(415, 3);
            pnlTracks.Name = "pnlTracks";
            pnlTracks.Size = new Size(200, 100);
            pnlTracks.TabIndex = 6;
            // 
            // flpPanel3
            // 
            flpPanel3.Controls.Add(lblTrackCount);
            flpPanel3.Controls.Add(lblCaption3);
            flpPanel3.FlowDirection = FlowDirection.TopDown;
            flpPanel3.Location = new Point(0, 0);
            flpPanel3.Name = "flpPanel3";
            flpPanel3.Size = new Size(200, 100);
            flpPanel3.TabIndex = 0;
            flpPanel3.WrapContents = false;
            // 
            // lblTrackCount
            // 
            lblTrackCount.AutoSize = true;
            lblTrackCount.Location = new Point(3, 0);
            lblTrackCount.Name = "lblTrackCount";
            lblTrackCount.Size = new Size(23, 28);
            lblTrackCount.TabIndex = 0;
            lblTrackCount.Text = "0";
            // 
            // lblCaption3
            // 
            lblCaption3.AutoSize = true;
            lblCaption3.Location = new Point(3, 28);
            lblCaption3.Name = "lblCaption3";
            lblCaption3.Size = new Size(116, 28);
            lblCaption3.TabIndex = 1;
            lblCaption3.Text = "Total Tracks";
            // 
            // btnCreatePlaylist
            // 
            btnCreatePlaylist.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreatePlaylist.Location = new Point(230, 330);
            btnCreatePlaylist.Name = "btnCreatePlaylist";
            btnCreatePlaylist.Size = new Size(163, 38);
            btnCreatePlaylist.TabIndex = 6;
            btnCreatePlaylist.Text = "Create Playlist";
            btnCreatePlaylist.UseVisualStyleBackColor = true;
            btnCreatePlaylist.Click += btnCreatePlaylist_Click;
            // 
            // btnAddPlaylist
            // 
            btnAddPlaylist.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddPlaylist.Location = new Point(414, 330);
            btnAddPlaylist.Name = "btnAddPlaylist";
            btnAddPlaylist.Size = new Size(163, 38);
            btnAddPlaylist.TabIndex = 7;
            btnAddPlaylist.Text = "Upload a Song";
            btnAddPlaylist.UseVisualStyleBackColor = true;
            btnAddPlaylist.Click += btnAddPlaylist_Click;
            // 
            // lstPlaylists
            // 
            lstPlaylists.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            lstPlaylists.Location = new Point(207, 129);
            lstPlaylists.Name = "lstPlaylists";
            lstPlaylists.Size = new Size(397, 179);
            lstPlaylists.TabIndex = 8;
            lstPlaylists.UseCompatibleStateImageBehavior = false;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 593);
            Controls.Add(lstPlaylists);
            Controls.Add(btnAddPlaylist);
            Controls.Add(btnCreatePlaylist);
            Controls.Add(grpStats);
            Controls.Add(lblUser);
            Controls.Add(picUserIcon);
            Controls.Add(lblPlaylists);
            Controls.Add(lblWelcome);
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmHome";
            Text = "Home";
            Load += frmHome_Load;
            ((System.ComponentModel.ISupportInitialize)picUserIcon).EndInit();
            grpStats.ResumeLayout(false);
            flpStats.ResumeLayout(false);
            pnlTotalPlaylist.ResumeLayout(false);
            flpPanel1.ResumeLayout(false);
            flpPanel1.PerformLayout();
            pnlHeavyRotation.ResumeLayout(false);
            pnlHeavy.ResumeLayout(false);
            flpPanel2.ResumeLayout(false);
            flpPanel2.PerformLayout();
            pnlTracks.ResumeLayout(false);
            flpPanel3.ResumeLayout(false);
            flpPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblPlaylists;
        private PictureBox picUserIcon;
        private Label lblUser;
        private GroupBox grpStats;
        private FlowLayoutPanel flpStats;
        private Panel pnlTotalPlaylist;
        private Panel pnlHeavyRotation;
        private Panel panel1;
        private Panel pnlHeavy;
        private Panel pnlTracks;
        private FlowLayoutPanel flpPanel1;
        private FlowLayoutPanel flpPanel2;
        private FlowLayoutPanel flpPanel3;
        private Label lblTotalplaylists;
        private Label lblCaption1;
        private Label lblTopArtist;
        private Label lblCaption2;
        private Label lblTrackCount;
        private Label lblCaption3;
        private Button btnCreatePlaylist;
        private Button btnAddPlaylist;
        private ListView lstPlaylists;
    }
}