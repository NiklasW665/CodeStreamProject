namespace CodeStream20
{
    partial class frmPlaylist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlaylist));
            lblPlaylistTitle = new Label();
            lblCreationDate = new Label();
            lblCreationDateValue = new Label();
            pBoxCoverArt = new PictureBox();
            btnUploadPlaylistArt = new Button();
            btnBackToHome = new Button();
            dgvSongs = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colArtist = new DataGridViewTextBoxColumn();
            colAlbum = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            btnDeleteSong = new Button();
            cmbSort = new ComboBox();
            btnSort = new Button();
            lblTrackCountCaption = new Label();
            lblTrackCountValue = new Label();
            btnDeletePlaylist = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxCoverArt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // lblPlaylistTitle
            // 
            lblPlaylistTitle.AutoSize = true;
            lblPlaylistTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaylistTitle.Location = new Point(67, 27);
            lblPlaylistTitle.Name = "lblPlaylistTitle";
            lblPlaylistTitle.Size = new Size(176, 37);
            lblPlaylistTitle.TabIndex = 0;
            lblPlaylistTitle.Text = "Playlist Title";
            lblPlaylistTitle.Click += lblPlaylistTitle_Click;
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreationDate.Location = new Point(29, 481);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(143, 28);
            lblCreationDate.TabIndex = 2;
            lblCreationDate.Text = "Creation Date";
            // 
            // lblCreationDateValue
            // 
            lblCreationDateValue.AutoSize = true;
            lblCreationDateValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreationDateValue.Location = new Point(51, 509);
            lblCreationDateValue.Name = "lblCreationDateValue";
            lblCreationDateValue.Size = new Size(84, 28);
            lblCreationDateValue.TabIndex = 3;
            lblCreationDateValue.Text = "---------";
            lblCreationDateValue.Click += lblCreationDateValue_Click;
            // 
            // pBoxCoverArt
            // 
            pBoxCoverArt.Location = new Point(29, 84);
            pBoxCoverArt.Margin = new Padding(3, 4, 3, 4);
            pBoxCoverArt.Name = "pBoxCoverArt";
            pBoxCoverArt.Size = new Size(229, 267);
            pBoxCoverArt.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxCoverArt.TabIndex = 4;
            pBoxCoverArt.TabStop = false;
            // 
            // btnUploadPlaylistArt
            // 
            btnUploadPlaylistArt.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUploadPlaylistArt.Location = new Point(51, 359);
            btnUploadPlaylistArt.Margin = new Padding(3, 4, 3, 4);
            btnUploadPlaylistArt.Name = "btnUploadPlaylistArt";
            btnUploadPlaylistArt.Size = new Size(190, 52);
            btnUploadPlaylistArt.TabIndex = 5;
            btnUploadPlaylistArt.Text = "Upload Playlist Art";
            btnUploadPlaylistArt.UseVisualStyleBackColor = true;
            btnUploadPlaylistArt.Click += btnUploadPlaylistArt_Click;
            // 
            // btnBackToHome
            // 
            btnBackToHome.Location = new Point(747, 513);
            btnBackToHome.Name = "btnBackToHome";
            btnBackToHome.Size = new Size(125, 43);
            btnBackToHome.TabIndex = 6;
            btnBackToHome.Text = "<-Homepage";
            btnBackToHome.UseVisualStyleBackColor = true;
            btnBackToHome.Click += btnBackToHome_Click;
            // 
            // dgvSongs
            // 
            dgvSongs.AllowUserToAddRows = false;
            dgvSongs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSongs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSongs.Columns.AddRange(new DataGridViewColumn[] { colName, colArtist, colAlbum, colGenre });
            dgvSongs.Location = new Point(367, 45);
            dgvSongs.Margin = new Padding(3, 4, 3, 4);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.RowHeadersVisible = false;
            dgvSongs.RowHeadersWidth = 51;
            dgvSongs.Size = new Size(506, 157);
            dgvSongs.TabIndex = 7;
            dgvSongs.CellDoubleClick += dgvSongs_CellDoubleClick;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            // 
            // colArtist
            // 
            colArtist.HeaderText = "Artist";
            colArtist.MinimumWidth = 6;
            colArtist.Name = "colArtist";
            // 
            // colAlbum
            // 
            colAlbum.HeaderText = "Album";
            colAlbum.MinimumWidth = 6;
            colAlbum.Name = "colAlbum";
            // 
            // colGenre
            // 
            colGenre.HeaderText = "Genre";
            colGenre.MinimumWidth = 6;
            colGenre.Name = "colGenre";
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(337, 315);
            axWindowsMediaPlayer1.Margin = new Padding(3, 4, 3, 4);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(535, 47);
            axWindowsMediaPlayer1.TabIndex = 8;
            // 
            // btnDeleteSong
            // 
            btnDeleteSong.Location = new Point(401, 210);
            btnDeleteSong.Margin = new Padding(3, 4, 3, 4);
            btnDeleteSong.Name = "btnDeleteSong";
            btnDeleteSong.Size = new Size(121, 47);
            btnDeleteSong.TabIndex = 9;
            btnDeleteSong.Text = "Delete Song";
            btnDeleteSong.UseVisualStyleBackColor = true;
            btnDeleteSong.Click += btnDeleteSong_Click;
            // 
            // cmbSort
            // 
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "", "Name", "Artist", "Album", "Genre" });
            cmbSort.Location = new Point(748, 220);
            cmbSort.Margin = new Padding(3, 4, 3, 4);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(125, 28);
            cmbSort.TabIndex = 10;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(611, 210);
            btnSort.Margin = new Padding(3, 4, 3, 4);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(126, 47);
            btnSort.TabIndex = 11;
            btnSort.Text = "Sort By:";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // lblTrackCountCaption
            // 
            lblTrackCountCaption.AutoSize = true;
            lblTrackCountCaption.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrackCountCaption.Location = new Point(259, 481);
            lblTrackCountCaption.Name = "lblTrackCountCaption";
            lblTrackCountCaption.Size = new Size(124, 28);
            lblTrackCountCaption.TabIndex = 13;
            lblTrackCountCaption.Text = "Track Count";
            // 
            // lblTrackCountValue
            // 
            lblTrackCountValue.AutoSize = true;
            lblTrackCountValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrackCountValue.Location = new Point(281, 509);
            lblTrackCountValue.Name = "lblTrackCountValue";
            lblTrackCountValue.Size = new Size(84, 28);
            lblTrackCountValue.TabIndex = 14;
            lblTrackCountValue.Text = "---------";
            // 
            // btnDeletePlaylist
            // 
            btnDeletePlaylist.Location = new Point(571, 513);
            btnDeletePlaylist.Name = "btnDeletePlaylist";
            btnDeletePlaylist.Size = new Size(133, 43);
            btnDeletePlaylist.TabIndex = 15;
            btnDeletePlaylist.Text = "Delete Playlist";
            btnDeletePlaylist.UseVisualStyleBackColor = true;
            btnDeletePlaylist.Click += btnDeletePlaylist_Click;
            // 
            // frmPlaylist
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnDeletePlaylist);
            Controls.Add(lblTrackCountValue);
            Controls.Add(lblTrackCountCaption);
            Controls.Add(btnSort);
            Controls.Add(cmbSort);
            Controls.Add(btnDeleteSong);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(dgvSongs);
            Controls.Add(btnBackToHome);
            Controls.Add(btnUploadPlaylistArt);
            Controls.Add(pBoxCoverArt);
            Controls.Add(lblCreationDateValue);
            Controls.Add(lblCreationDate);
            Controls.Add(lblPlaylistTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPlaylist";
            Text = "Playlist";
            Load += frmPlaylist_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxCoverArt).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlaylistTitle;
        private Label lblCreationDate;
        private Label lblCreationDateValue;
        private PictureBox pBoxCoverArt;
        private Button btnUploadPlaylistArt;
        private Button btnBackToHome;
        private DataGridView dgvSongs;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colArtist;
        private DataGridViewTextBoxColumn colAlbum;
        private DataGridViewTextBoxColumn colGenre;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button btnDeleteSong;
        private ComboBox cmbSort;
        private Button btnSort;
        private Label lblTrackCountCaption;
        private Label lblTrackCountValue;
        private Button btnDeletePlaylist;

        
    }
}