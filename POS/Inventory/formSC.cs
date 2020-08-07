using POS.Library.Class;
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

namespace POS.Inventory
{
    public partial class formVSC : Form
    {
        posInvEntities pe = new posInvEntities();
        public formVSC(string title,string gtitle)
        {
            InitializeComponent();
            Init(title, gtitle);
        }

        public void Init(string title, string gtitle)
        {
            this.Text = title;
            groupBox1.Text = gtitle;

            List<SuppAndCat> sc = LInqToEDM.suppAndCat(pe, "", title);
            searchSC(sc);



        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            List<SuppAndCat> sc = LInqToEDM.suppAndCat(pe, "", this.Text);
            searchSC(sc);
        }

        private void searchSC(List<SuppAndCat> sc)
        {
            dataGridView1.DataSource = sc;

            if(this.Text == "Category")
            {
                dataGridView1.Columns["CategoryName"].HeaderText = "Category Name";
                dataGridView1.Columns["Supplier"].Visible = false;
            }
            else
            {
                dataGridView1.Columns["CategoryName"].Visible = false;
            }

            dataGridView1.Refresh();
        }
    }
}
