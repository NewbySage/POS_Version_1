using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Library.Database;
using POS.Library.Object;
using POS.Library.Class;
using POS.Inventory;

namespace POS.Home_User_Control
{
    public partial class Inventory : UserControl
    {
        posInvEntities pe;
        public Inventory()
        {
            InitializeComponent();
            InitializeComponent1();
        }

        private void InitializeComponent1()
        {
            pe = new posInvEntities();

            List<string> type = new List<string> {"Barcode","Description","InitialPrice","Type","Stock","Supplier"/*,"DateRestock"*/};
            comboBox1.DataSource = type;
            List<Product> product = LInqToEDM.LinqExpProduct(pe, comboBox1.SelectedItem.ToString(), textBox1.Text);
            dataGridView1.DataSource = product;

            
      
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            List<Product> product = LInqToEDM.LinqExpProduct(pe, comboBox1.SelectedItem.ToString(), textBox.Text);
            dataGridView1.DataSource = product;
            dataGridView1.Refresh();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            formVSC fs = new formVSC("Category", "Category List");
            fs.ShowDialog();
        }

        private void btnVC_Click(object sender, EventArgs e)
        {
            formVSC fs = new formVSC("Supplier", "Supplier List");
            fs.ShowDialog();
        }
    }
}
