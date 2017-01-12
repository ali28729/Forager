using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class registrationForm : Form
    {
        public int userID { get; set; }
        public string loginID { get; set; }
        public string password { get; set; }
        public MySqlConnection conn;

        public registrationForm()
        {
            InitializeComponent();
            this.password2Text.PasswordChar = '*';
            this.passwordText.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!password2Text.Text.Equals(passwordText.Text))
            {
                MessageBox.Show("Passwords Mismatch!");
                return; 
            }

            loginID = loginIDText.Text;
            password = password2Text.Text;

            MySqlCommand cmd = new MySqlCommand();


            cmd.CommandText = "SELECT userID FROM registeredUser WHERE loginID = @login OR emailID = @email";

            cmd.Parameters.AddWithValue("@login", loginID);
            cmd.Parameters.AddWithValue("@email", emailIDText.Text);

            conn.Open();

            cmd.Connection = conn;

            if (cmd.ExecuteScalar() == null)
            {
                int Count = -1;
                cmd.CommandText = "SELECT Count(*) FROM defaultUser";
                Count = int.Parse(cmd.ExecuteScalar() + "");

                userID = Count + 1;

                cmd.CommandText = "INSERT INTO defaultUser VALUES (@id,null);";
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO registeredUser VALUES (@id,@fname,null,@lname,@login,@pass,false,@email);";
                cmd.Parameters.AddWithValue("@fname", fnameText.Text);
                cmd.Parameters.AddWithValue("@lname", lnameText.Text);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.ExecuteNonQuery();

                loginID = this.loginIDText.Text;
                this.DialogResult = DialogResult.OK;

                conn.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("'Login' or 'Email' ID is already registered!");
            }
            this.DialogResult = DialogResult.OK;
            conn.Close();
        }

        private void registrationForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
