using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeStream20
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string usersFilePath = "user.txt";

            try
            {
                if (UserExists(usersFilePath, username))
                {
                    MessageBox.Show("Username is taken. Please try another");
                    return;
                }

                SaveUser(usersFilePath, username, password);

                MessageBox.Show("Account created successfully! Please log in.");

                frmLogin LoginForm = new frmLogin();
                LoginForm.Show();
                this.Hide();
                LoginForm.FormClosed += (s, args) => this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred" + ex.Message);
            }
        }

        private bool UserExists(string filePath, string username)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath)) { }
                return false;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length > 1 && parts[0].Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void SaveUser(string filePath, string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(username + "," + password);
            }
        }



        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#000424");
            this.ForeColor = Color.White;
            btnRegister.BackColor = ColorTranslator.FromHtml("#1f1fa1");
            btnRegister.ForeColor = Color.White;
        }

        
    }
}
