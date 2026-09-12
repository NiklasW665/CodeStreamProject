using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

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
                MessageBox.Show("Please enter both Username and Password"); //checking if the username and password fields are empty and displaying a message to the user
                return; //returning from the method if the fields are empty.Which method is being returned from? The btnLogin_Click method is being returned from, which is the event handler for the login button click event. This means that if the username or password fields are empty, the method will exit and no further code will be executed.
            }

            //try catch block when no file is found
            try
            {
                //string json = File.ReadAllText("User.json"); //using json file to store user data
                string json = File.ReadAllText(User.UsersFilePath); //using json file to store user data
                List<User> users = JsonSerializer.Deserialize<List<User>>(json); //taking the data from the json file and storing it in a variable of type List<User>

                foreach (User user in users) //looping through the list of users and checking if the username and password entered by the user matches the data stored in the json file)
                {
                    if (user.Username.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase) &&
                    user.Password == txtPassword.Text) //Checking if the username and password entered by the user matches the data stored in the json file 
                    {
                        frmHome home = new frmHome(user.Username); //if the username and password matches, then the user is logged in and the home form is displayed)
                        home.FormClosed += (s, args) => this.Close(); //when Home closes, close this hidden login form too, so the app actually exits
                        home.Show();
                        this.Hide();
                        return;
                    }
                }
                MessageBox.Show("Invalid username and password, please register");
                return; //if the username and password does not match, then a message is displayed to the user
            }
            catch (FileNotFoundException) //catching the exception when the file is not found and displaying a message to the user
            {
                MessageBox.Show("No user accounts found. Please register first.");
                return;
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
