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
    public partial class Form1 : Form
    {
        public int userID { get; set; }
        public string loginID { get; set; }
        public DBConnect DBconn = new DBConnect();
        public MySqlConnection conn;
        MySqlCommand cmd = new MySqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SearchResultsText.Enabled = false;
            this.SearchResultsText.BackColor = System.Drawing.SystemColors.Window;

            DBconn.OpenConnection();
            conn = DBconn.connection;
            DBconn.CloseConnection();
            //logInPrompt();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logInPrompt()
        {
            this.Hide();
            loginScreen login = new loginScreen();
            login.conn = this.conn;

            login.ShowDialog();

            loginID = login.loginID;
            this.loggedAsLabel.Text = "Logged in as: " + loginID;
            this.Show();
        }

        private void SearchResultsText_TextChanged(object sender, EventArgs e)
        {

        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            string query = SearchTextBox.Text;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText =   "SELECT distinct(docURL) FROM document WHERE docID IN( SELECT docID FROM Hits WHERE wordID=( SELECT wordID FROM word WHERE word= @word));";
            cmd.Parameters.AddWithValue("@word", query);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<string> urls=new List<string>();

            while(dataReader.Read())
            {
                urls.Add(dataReader["docURL"] + "");
            }
            dataReader.Close();
            conn.Close();



            ResultForm resultForm = new ResultForm();
            resultForm.links = urls;
            resultForm.titles = urls;
            resultForm.Show();
        }
    }
}
