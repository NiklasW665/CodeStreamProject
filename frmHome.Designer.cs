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
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(224, 37);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(106, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Message";
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.Location = new Point(235, 77);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(79, 15);
            lblPlaylists.TabIndex = 1;
            lblPlaylists.Text = "Your Playlists:";
            // 
            // lstPlaylists
            // 
            lstPlaylists.FormattingEnabled = true;
            lstPlaylists.Location = new Point(113, 95);
            lstPlaylists.Name = "lstPlaylists";
            lstPlaylists.Size = new Size(348, 139);
            lstPlaylists.TabIndex = 2;
            lstPlaylists.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(lstPlaylists);
            Controls.Add(lblPlaylists);
            Controls.Add(lblWelcome);
            Margin = new Padding(2);
            Name = "frmHome";
            Text = "Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblPlaylists;
        private ListBox lstPlaylists;
    }
}