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
    public partial class loginScreen : Form
    {
        public int userID { get;set; }
        public string loginID { get; set; }
        public string password { get; set; }
        public MySqlConnection conn;

        public loginScreen()
        {
            InitializeComponent();
        }

        private void loginScreen_Load(object sender, EventArgs e)
        {
            this.passwordtxt.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginID = this.loginIDtxt.Text;
            password = this.passwordtxt.Text;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT userPass FROM registeredUser WHERE loginID=@ID";
            cmd.Parameters.AddWithValue("@ID", loginID);
            if (password.Equals(cmd.ExecuteScalar()))
            {
                this.DialogResult = DialogResult.OK;
                conn.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid credentials!");
                conn.Close();
                this.passwordtxt.Text = "";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT Count(*) FROM defaultUser";
            int Count = -1;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            Count = int.Parse(cmd.ExecuteScalar() + "");

            userID = Count + 1;
            loginID = "guest" + userID.ToString();
            this.DialogResult = DialogResult.Cancel;

            conn.Close();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            registrationForm regForm = new registrationForm();
            regForm.conn = this.conn;
            regForm.ShowDialog();
            this.userID = regForm.userID;
            this.loginID = regForm.loginID;
            this.password = regForm.password;
            this.Show();
        }
    }
}
