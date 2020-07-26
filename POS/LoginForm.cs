using POS.Library.Database;
using POS.Library.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Creating Object UserDBHelper userdb
            UserDBHelper userdb = new UserDBHelper();

            if (txtUsername.Text != string.Empty && txtPassword.Text != string.Empty) { 
            //Create Object Users and pass the value of userdb method searchUser to user
            Users user = userdb.searchUser(txtUsername.Text, txtPassword.Text);

                //Condition if the user is exist or not
                if (user != null)
                {
                    if (user.IsAdmin == true) {
                        Home hm = new Home(user);
                        hm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        POS ps = new POS(user);
                        ps.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    string title = "Login Failed";
                    string message = "Invalid Username or Password. Please Try Again";
                    MessageBox.Show(message, title);
                }

            }
            else
            {
                string title = "Login Failed";
                string message = "Username or Password are empty";
                MessageBox.Show(message, title);
            }

        }
    }
}
