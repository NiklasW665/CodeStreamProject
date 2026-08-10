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

        private void btnRegister_Click(object sender, EventArgs e)
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
                // Check for duplicate username
                if (UserExists(usersFilePath, username))
                {
                    MessageBox.Show("Username is taken. Please try another");
                    return;
                }

                // Save user 
                SaveUser(usersFilePath, username, password);

                MessageBox.Show("Account created successfully! Please log in.");

                // Redirect to login
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

        // VOID METHOD: Returns true if user exists
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
                        return true; //match found
                    }
                }
            }

            return false; //match not found
        }

        // VOID METHOD: Save user data to file
        private void SaveUser(string filePath, string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(username + "," + password);
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

        }
    }
}
