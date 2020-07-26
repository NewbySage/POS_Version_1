using MySql.Data.MySqlClient;
using POS.Library.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Database
{
    class UserDBHelper : DBHelper
    {
        public UserDBHelper() : base() 

        {
            
        }


        public Users searchUser(string userName,string password) {
            string query = "SELECT * FROM tbl_users Where Username = \"" + userName + "\" AND Password = \"" + password + "\"";
            Users user = null;
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read data and store in User class
                while (dataReader.Read())
                {
                    user = new Users(dataReader["Name"] + "", dataReader["Username"] + "", dataReader["Password"] + "", Boolean.Parse(dataReader["isAdmin"] + ""));
                }

                //Close DataReader
                dataReader.Close();

                //Close Connection
                this.CloseConnection();

                return user;


            }
            else {
                return user;
            }
        }
    }
}
