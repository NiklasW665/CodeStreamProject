namespace CodeStream20
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //Video comment
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
                bool found = false;

                //Read the file
                while ((username = inputFile.ReadLine()) != null)
                {
                    password = inputFile.ReadLine();

                    //Compare
                    if (username == txtUsername.Text && password == txtPassword.Text)
                    {
                        found = true;

                    }
                }

                //Close the file
                inputFile.Close();

                //Check if login succeeded
                if (found)
                {
                    frmHome home = new frmHome();
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
    }
}
