using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DBConnect
    {
        public MySqlConnection connection
        {
            get;
            set;
        }
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "Forager";
            uid = "root";
            password = "of88line";
            string connectionString =   "SERVER=" + server + ";" + "DATABASE=" +
                                        database + ";" + "UID=" + uid + ";" + "PASSWORD=" 
                                        + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                dataReader.Close();

                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                Count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
