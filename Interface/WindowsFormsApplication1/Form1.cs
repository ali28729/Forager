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
    public struct Page
    {
        public string url;
        public string title;
        public int rank;
    };

    public partial class Form1 : Form
    {
        public int userID { get; set; }
        public string loginID { get; set; }
        public DBConnect DBconn = new DBConnect();
        public MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBconn.OpenConnection();
            conn = DBconn.connection;
            DBconn.CloseConnection();
            logInPrompt();
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
            string query = RemoveSpecialCharacters(SearchTextBox.Text.ToLower());
            
            Array KeyWords = query.Split(' ');

            List<List<Page>> AllPages = new List<List<Page>>();
            foreach (var word in KeyWords)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT docURL,docTitle,rank FROM document JOIN (SELECT docID,SUM(fontSize) as rank FROM Hits WHERE wordID IN( SELECT wordID FROM word WHERE word LIKE @word)GROUP BY docID)AS x1 USING (docID);";
                cmd.Parameters.AddWithValue("@word", word);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                List<Page> pages = new List<Page>();

                while (dataReader.Read())
                {
                    Page temp = new Page();
                    temp.url = dataReader["docURL"].ToString();
                    temp.title = dataReader["docTitle"].ToString();
                    temp.rank = Convert.ToInt32(dataReader["rank"]);
                    pages.Add(temp);
                }
                pages = pages.OrderByDescending(o => o.rank).Take(10).ToList();
                AllPages.Add(pages);
                dataReader.Close();
                conn.Close();
            }

            List<List<List<Page>>> Intersections = new List<List<List<Page>>>();
            Intersections.Add(AllPages);

            for(int i=0;i<Intersections.Count;i++)
            {
                var intersection = Intersections.ElementAt(i);
                var intersect1 = new List<List<Page>>();
                for (int j = 0; j < intersection.Count; j++)
                {
                    var pageList=intersection.ElementAt(j);
                    var intersect2 = new List<Page>();
                    for (int k = j + 1; k < intersection.Count; k++)
                    {
                        var pageList2 = intersection.ElementAt(k);
                        for (int x = 0; x < pageList.Count; x++)
                        {
                            var page = pageList.ElementAt(x);
                            for (int y = 0; y < pageList2.Count; y++)
                            {
                                var page2 = pageList2.ElementAt(y);
                                if (page.url.Equals(page2.url)) 
                                {
                                    Page temp = new Page();
                                    temp.url = page.url;
                                    temp.title = page.title;
                                    temp.rank = page.rank + page2.rank;
                                    intersect2.Add(temp);
                                    pageList.Remove(page);
                                    pageList2.Remove(page2);
                                }
                            }
                        }
                    }
                    if (intersect2.Count > 0)
                        intersect1.Add(intersect2);
                }
                if (intersect1.Count > 0)
                    Intersections.Add(intersect1);
                if(intersect1.Count<=1)
                    break;
            }

            List<Page> FinalResults = new List<Page>();

            for (int i = Intersections.Count - 1; i >= 0; i--) 
            {
                var intersection = Intersections.ElementAt(i);
                var first = intersection.ElementAt(0);
                for (int j = 1; j < intersection.Count; j++)
                    first.AddRange(intersection.ElementAt(j));
                first = first.OrderByDescending(o => o.rank).Take(10).ToList();
                FinalResults.AddRange(first);
                if(FinalResults.Count>=9)
                {
                    FinalResults = FinalResults.Take(10).ToList();
                    break;
                }
            }


            ResultForm resultForm = new ResultForm();
            resultForm.pages = FinalResults;
            resultForm.Show();
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
                if (char.IsLetterOrDigit(c)||c==' ')
                    sb.Append(c);
            return sb.ToString();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
