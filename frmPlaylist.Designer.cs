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
            ((System.ComponentModel.ISupportInitialize)pBoxCoverArt).BeginInit();
            SuspendLayout();
            // 
            // lblPlaylistTitle
            // 
            lblPlaylistTitle.AutoSize = true;
            lblPlaylistTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaylistTitle.Location = new Point(412, 61);
            lblPlaylistTitle.Name = "lblPlaylistTitle";
            lblPlaylistTitle.Size = new Size(132, 30);
            lblPlaylistTitle.TabIndex = 0;
            lblPlaylistTitle.Text = "Playlist Title";
            lblPlaylistTitle.Click += lblPlaylistTitle_Click;
            // 
            // lblTitleValue
            // 
            lblTitleValue.AutoSize = true;
            lblTitleValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleValue.Location = new Point(412, 106);
            lblTitleValue.Name = "lblTitleValue";
            lblTitleValue.Size = new Size(116, 30);
            lblTitleValue.TabIndex = 1;
            lblTitleValue.Text = "SongName";
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreationDate.Location = new Point(412, 190);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(147, 30);
            lblCreationDate.TabIndex = 2;
            lblCreationDate.Text = "Creation Date";
            // 
            // lblCreationDateValue
            // 
            lblCreationDateValue.AutoSize = true;
            lblCreationDateValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreationDateValue.Location = new Point(412, 233);
            lblCreationDateValue.Name = "lblCreationDateValue";
            lblCreationDateValue.Size = new Size(85, 30);
            lblCreationDateValue.TabIndex = 3;
            lblCreationDateValue.Text = "---------";
            lblCreationDateValue.Click += lblCreationDateValue_Click;
            // 
            // pBoxCoverArt
            // 
            pBoxCoverArt.Location = new Point(80, 44);
            pBoxCoverArt.Name = "pBoxCoverArt";
            pBoxCoverArt.Size = new Size(250, 250);
            pBoxCoverArt.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxCoverArt.TabIndex = 4;
            pBoxCoverArt.TabStop = false;
            // 
            // btnUploadPlaylistArt
            // 
            btnUploadPlaylistArt.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUploadPlaylistArt.Location = new Point(101, 333);
            btnUploadPlaylistArt.Name = "btnUploadPlaylistArt";
            btnUploadPlaylistArt.Size = new Size(210, 43);
            btnUploadPlaylistArt.TabIndex = 5;
            btnUploadPlaylistArt.Text = "Upload Playlist Art";
            btnUploadPlaylistArt.UseVisualStyleBackColor = true;
            btnUploadPlaylistArt.Click += btnUploadPlaylistArt_Click;
            // 
            // frmPlaylist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUploadPlaylistArt);
            Controls.Add(pBoxCoverArt);
            Controls.Add(lblCreationDateValue);
            Controls.Add(lblCreationDate);
            Controls.Add(lblTitleValue);
            Controls.Add(lblPlaylistTitle);
            Name = "frmPlaylist";
            Text = "Playlist";
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
    }
}