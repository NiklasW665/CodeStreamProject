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
            ((System.ComponentModel.ISupportInitialize)pBoxCoverArt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // lblPlaylistTitle
            // 
            lblPlaylistTitle.AutoSize = true;
            lblPlaylistTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaylistTitle.Location = new Point(59, 20);
            lblPlaylistTitle.Name = "lblPlaylistTitle";
            lblPlaylistTitle.Size = new Size(132, 30);
            lblPlaylistTitle.TabIndex = 0;
            lblPlaylistTitle.Text = "Playlist Title";
            lblPlaylistTitle.Click += lblPlaylistTitle_Click;
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreationDate.Location = new Point(59, 361);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(115, 21);
            lblCreationDate.TabIndex = 2;
            lblCreationDate.Text = "Creation Date";
            // 
            // lblCreationDateValue
            // 
            lblCreationDateValue.AutoSize = true;
            lblCreationDateValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreationDateValue.Location = new Point(80, 382);
            lblCreationDateValue.Name = "lblCreationDateValue";
            lblCreationDateValue.Size = new Size(64, 21);
            lblCreationDateValue.TabIndex = 3;
            lblCreationDateValue.Text = "---------";
            lblCreationDateValue.Click += lblCreationDateValue_Click;
            // 
            // pBoxCoverArt
            // 
            pBoxCoverArt.Location = new Point(25, 63);
            pBoxCoverArt.Name = "pBoxCoverArt";
            pBoxCoverArt.Size = new Size(200, 200);
            pBoxCoverArt.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxCoverArt.TabIndex = 4;
            pBoxCoverArt.TabStop = false;
            // 
            // btnUploadPlaylistArt
            // 
            btnUploadPlaylistArt.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUploadPlaylistArt.Location = new Point(45, 269);
            btnUploadPlaylistArt.Name = "btnUploadPlaylistArt";
            btnUploadPlaylistArt.Size = new Size(166, 39);
            btnUploadPlaylistArt.TabIndex = 5;
            btnUploadPlaylistArt.Text = "Upload Playlist Art";
            btnUploadPlaylistArt.UseVisualStyleBackColor = true;
            btnUploadPlaylistArt.Click += btnUploadPlaylistArt_Click;
            // 
            // btnBackToHome
            // 
            btnBackToHome.Location = new Point(655, 382);
            btnBackToHome.Margin = new Padding(3, 2, 3, 2);
            btnBackToHome.Name = "btnBackToHome";
            btnBackToHome.Size = new Size(109, 32);
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
            dgvSongs.Location = new Point(321, 34);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.RowHeadersVisible = false;
            dgvSongs.Size = new Size(443, 118);
            dgvSongs.TabIndex = 7;
            dgvSongs.CellDoubleClick += dgvSongs_CellDoubleClick;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            // 
            // colArtist
            // 
            colArtist.HeaderText = "Artist";
            colArtist.Name = "colArtist";
            // 
            // colAlbum
            // 
            colAlbum.HeaderText = "Album";
            colAlbum.Name = "colAlbum";
            // 
            // colGenre
            // 
            colGenre.HeaderText = "Genre";
            colGenre.Name = "colGenre";
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(321, 310);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(443, 47);
            axWindowsMediaPlayer1.TabIndex = 8;
            // 
            // btnDeleteSong
            // 
            btnDeleteSong.Location = new Point(321, 177);
            btnDeleteSong.Name = "btnDeleteSong";
            btnDeleteSong.Size = new Size(78, 35);
            btnDeleteSong.TabIndex = 9;
            btnDeleteSong.Text = "Delete Song";
            btnDeleteSong.UseVisualStyleBackColor = true;
            btnDeleteSong.Click += btnDeleteSong_Click;
            // 
            // cmbSort
            // 
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "", "Name", "Artist", "Album", "Genre" });
            cmbSort.Location = new Point(654, 218);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(110, 23);
            cmbSort.TabIndex = 10;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(654, 177);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(110, 35);
            btnSort.TabIndex = 11;
            btnSort.Text = "Sort By:";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // frmPlaylist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}