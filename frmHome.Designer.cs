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
            lblWelcome = new Label();
            lblPlaylists = new Label();
            lstPlaylists = new ListBox();
            picUserIcon = new PictureBox();
            lblUser = new Label();
            ((System.ComponentModel.ISupportInitialize)picUserIcon).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI Black", 14F);
            lblWelcome.Location = new Point(173, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(231, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Message";
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.Font = new Font("Segoe UI Black", 12F);
            lblPlaylists.Location = new Point(236, 85);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(153, 28);
            lblPlaylists.TabIndex = 1;
            lblPlaylists.Text = "Your Playlists:";
            // 
            // lstPlaylists
            // 
            lstPlaylists.Font = new Font("Segoe UI", 11F);
            lstPlaylists.FormattingEnabled = true;
            lstPlaylists.Location = new Point(129, 127);
            lstPlaylists.Margin = new Padding(3, 4, 3, 4);
            lstPlaylists.Name = "lstPlaylists";
            lstPlaylists.Size = new Size(397, 179);
            lstPlaylists.TabIndex = 2;
            lstPlaylists.SelectedIndexChanged += listBox1_SelectedIndexChanged;
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
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(lblUser);
            Controls.Add(picUserIcon);
            Controls.Add(lstPlaylists);
            Controls.Add(lblPlaylists);
            Controls.Add(lblWelcome);
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmHome";
            Text = "Home";
            Load += frmHome_Load;
            ((System.ComponentModel.ISupportInitialize)picUserIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblPlaylists;
        private ListBox lstPlaylists;
        private PictureBox picUserIcon;
        private Label lblUser;
    }
}