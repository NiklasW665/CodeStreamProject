using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeStream20
{
    public partial class frmHome : Form
    {
        private string username;
        public frmHome(string username)
        {
            InitializeComponent();
            this.username = username;
            lblWelcome.Text = "Welcome back " + username + "!";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
