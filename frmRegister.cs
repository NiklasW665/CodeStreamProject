using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace CodeStream20
{
    public partial class frmRegister : Form
    {
        private readonly string usersFilePath = "Users.json";
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

            try
            {
                List<User> users = LoadUsers();
                // Check for duplicate username
                if (UserExists(users, username))
                {
                    MessageBox.Show("Username is taken. Please try another");
                    return;
                }

                // Save user 
                users.Add(new User(username, password));
                SaveUser(users);

                MessageBox.Show("Account created successfully! Please log in.");

                // Redirect to login
                frmLogin LoginForm = new frmLogin();
                LoginForm.Show();
                this.Hide();
                LoginForm.FormClosed += (s, args) => this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message);
            }
        }

        // VOID METHOD: Returns true if user exists
        private bool UserExists(List<User> users, string username)
        {
            foreach (User u in users)
            {
                if (u.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private List<User> LoadUsers()
        {
            if (!File.Exists(usersFilePath))
            {
                return new List<User>();
            }
            string json = File.ReadAllText(usersFilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        
        // VOID METHOD: Save user data to file
        private void SaveUser(List<User> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(usersFilePath, json);
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