using POS.Library.Database;
using POS.Library.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
          

            if (txtUsername.Text != string.Empty && txtPassword.Text != string.Empty) {
                
                //Entity Data Model pos Entities new Instance and linq query
                posEntities pe = new posEntities();
                List<Users> users = (from p in pe.tbl_users
                             where p.Username == txtUsername.Text && p.Password == txtPassword.Text
                             select new Users 
                             {
                                 Name1 = p.Name,
                                 Username1 = p.Username,
                                 IsAdmin = p.IsAdmin,
                                 Me = p.PP
                             }).ToList();
                Users user = (users.Count != 0) ? users[0] : null;


                //Condition if the user is exist or not
                if (user != null)
                {
                    if (user.IsAdmin == true) {
                        Home hm = new Home(user);
                        hm.TopMost = true;
                        Program.SwitchMainForm(hm);
                    }
                    else
                    {
                        POS ps = new POS(user);
                        Program.SwitchMainForm(ps);
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
