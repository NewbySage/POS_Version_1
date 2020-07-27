using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public DBHelper() {

            CheckConnection();
        }

        private void CheckConnection()
        {
             string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
             
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
