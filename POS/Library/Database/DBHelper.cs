using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Library.Database
{
    interface DBInterface {
        bool OpenConnection();
        bool CloseConnection();
        
        
    }
    class DBHelper : DBInterface
    {
        protected MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        public DBHelper() {
            server = "localhost";
            database = "sampledb";
            uid = "root";
            password = "mysql";
            CheckConnection();
        }

        private void CheckConnection()
        {
             string connectionString;
             connectionString = "SERVER=" + server + ";" + "DATABASE=" +
             database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);

        }

        public bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex) {
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
    }
}
