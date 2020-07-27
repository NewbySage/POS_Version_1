using POS.Library.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class POS : Form
    {
        private Users user;
        public POS(Users user)
        {
            //Passing LoginForm user object in POS user object
            this.user = user;
            
            InitializeComponent();
            
            //visibility of edit item button
            if(user.IsAdmin != true)
            {
                btn_editItem.Visible = false;
            }

            // Set the name of the label1
            label1.Text = user.Name1;
            Refresh();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_barCode.Text != string.Empty)
            {
                // Need condition if the data is exist or not in the database

                Form1 fm = new Form1(txt_barCode.Text);
            }
            else
            {
                MessageBox.Show("No Barcode");
            }
        }

        private void btn_Search_Add_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
        }
    }
}
