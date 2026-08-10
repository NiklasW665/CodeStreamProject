using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeStream20
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter both Username and Password");
            }

            try
            {
                //Open the file
                StreamReader inputFile;
                inputFile = new StreamReader("User.txt");

                //declare variables
                string username;
                string password;
                string matchedUsername = "";
                bool found = false;

                //Read the file
                while ((username = inputFile.ReadLine()) != null)
                {
                    password = inputFile.ReadLine();

                    //Compare
                    if (username == txtUsername.Text && password == txtPassword.Text)
                    {
                        found = true;
                        matchedUsername = username;
                    }
                }

                //Close the file
                inputFile.Close();

                //Check if login succeeded
                if (found)
                {
                    frmHome home = new frmHome(matchedUsername);
                    home.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Invalid username or password. ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("file not found " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            register.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#000424");
            this.ForeColor = Color.White;
            btnRegister.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnRegister.ForeColor = Color.White;
            btnLogin.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            //btnLogin.ForeColor = Color.White;
        }
    }
}
