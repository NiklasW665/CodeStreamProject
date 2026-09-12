namespace CodeStream20
{
    partial class frmSelectPlaylists
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
            cbxListPlaylists = new CheckedListBox();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // cbxListPlaylists
            // 
            cbxListPlaylists.FormattingEnabled = true;
            cbxListPlaylists.Location = new Point(73, 12);
            cbxListPlaylists.Name = "cbxListPlaylists";
            cbxListPlaylists.Size = new Size(530, 246);
            cbxListPlaylists.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(374, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(161, 284);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // frmSelectPlaylists
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(cbxListPlaylists);
            Name = "frmSelectPlaylists";
            Text = "frmSelectPlaylists";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox cbxListPlaylists;
        private Button btnCancel;
        private Button btnOk;
    }
}