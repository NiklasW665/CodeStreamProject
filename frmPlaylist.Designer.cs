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
            lblPlaylistTitle = new Label();
            lblTitleValue = new Label();
            lblCreationDate = new Label();
            lblCreationDateValue = new Label();
            pBoxCoverArt = new PictureBox();
            btnUploadPlaylistArt = new Button();
            btnBackToHome = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxCoverArt).BeginInit();
            SuspendLayout();
            // 
            // lblPlaylistTitle
            // 
            lblPlaylistTitle.AutoSize = true;
            lblPlaylistTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaylistTitle.Location = new Point(471, 81);
            lblPlaylistTitle.Name = "lblPlaylistTitle";
            lblPlaylistTitle.Size = new Size(176, 37);
            lblPlaylistTitle.TabIndex = 0;
            lblPlaylistTitle.Text = "Playlist Title";
            lblPlaylistTitle.Click += lblPlaylistTitle_Click;
            // 
            // lblTitleValue
            // 
            lblTitleValue.AutoSize = true;
            lblTitleValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleValue.Location = new Point(471, 141);
            lblTitleValue.Name = "lblTitleValue";
            lblTitleValue.Size = new Size(149, 37);
            lblTitleValue.TabIndex = 1;
            lblTitleValue.Text = "SongName";
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreationDate.Location = new Point(471, 253);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(195, 37);
            lblCreationDate.TabIndex = 2;
            lblCreationDate.Text = "Creation Date";
            // 
            // lblCreationDateValue
            // 
            lblCreationDateValue.AutoSize = true;
            lblCreationDateValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreationDateValue.Location = new Point(471, 311);
            lblCreationDateValue.Name = "lblCreationDateValue";
            lblCreationDateValue.Size = new Size(116, 37);
            lblCreationDateValue.TabIndex = 3;
            lblCreationDateValue.Text = "---------";
            lblCreationDateValue.Click += lblCreationDateValue_Click;
            // 
            // pBoxCoverArt
            // 
            pBoxCoverArt.Location = new Point(91, 59);
            pBoxCoverArt.Margin = new Padding(3, 4, 3, 4);
            pBoxCoverArt.Name = "pBoxCoverArt";
            pBoxCoverArt.Size = new Size(286, 333);
            pBoxCoverArt.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxCoverArt.TabIndex = 4;
            pBoxCoverArt.TabStop = false;
            // 
            // btnUploadPlaylistArt
            // 
            btnUploadPlaylistArt.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUploadPlaylistArt.Location = new Point(115, 444);
            btnUploadPlaylistArt.Margin = new Padding(3, 4, 3, 4);
            btnUploadPlaylistArt.Name = "btnUploadPlaylistArt";
            btnUploadPlaylistArt.Size = new Size(240, 57);
            btnUploadPlaylistArt.TabIndex = 5;
            btnUploadPlaylistArt.Text = "Upload Playlist Art";
            btnUploadPlaylistArt.UseVisualStyleBackColor = true;
            btnUploadPlaylistArt.Click += btnUploadPlaylistArt_Click;
            // 
            // btnBackToHome
            // 
            btnBackToHome.Location = new Point(749, 509);
            btnBackToHome.Name = "btnBackToHome";
            btnBackToHome.Size = new Size(125, 42);
            btnBackToHome.TabIndex = 6;
            btnBackToHome.Text = "<-Homepage";
            btnBackToHome.UseVisualStyleBackColor = true;
            btnBackToHome.Click += btnBackToHome_Click;
            // 
            // frmPlaylist
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnBackToHome);
            Controls.Add(btnUploadPlaylistArt);
            Controls.Add(pBoxCoverArt);
            Controls.Add(lblCreationDateValue);
            Controls.Add(lblCreationDate);
            Controls.Add(lblTitleValue);
            Controls.Add(lblPlaylistTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPlaylist";
            Text = "Playlist";
            Load += frmPlaylist_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxCoverArt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlaylistTitle;
        private Label lblTitleValue;
        private Label lblCreationDate;
        private Label lblCreationDateValue;
        private PictureBox pBoxCoverArt;
        private Button btnUploadPlaylistArt;
        private Button btnBackToHome;
    }
}