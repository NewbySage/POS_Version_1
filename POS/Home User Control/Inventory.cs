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
        List<Product> product;
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
            product = LInqToEDM.LinqExpProduct(pe, comboBox1.SelectedItem.ToString(), textBox1.Text);
            populateDGV();
            
      
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            product = LInqToEDM.LinqExpProduct(pe, comboBox1.SelectedItem.ToString(), textBox.Text);
            populateDGV();

        }

        private void populateDGV()
        {
         
            dataGridView1.DataSource = product;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["MinStock"].Visible = false;
            dataGridView1.Columns["CategoryID"].Visible = false;
            dataGridView1.Columns["SupplierID"].Visible = false;
            dataGridView1.Columns["ByPack"].Visible = false;
            dataGridView1.Columns["isByPack"].Visible = false;
            dataGridView1.Refresh();
        }

        public void passData(Product prod, string mode)
        {
            if(mode == "Edit")
            {
                product[product.FindIndex(x => x.ID.Equals(prod.ID))] = prod;
                
            }
            else
            {
                product.Add(prod);
                dataGridView1.DataSource = null;
            }
            populateDGV();

        }




        private void btnS_Click(object sender, EventArgs e)
        {
            formVSC fs = new formVSC("Category", "Category List");
            fs.ShowDialog();
            fs.Dispose();
        }

        private void btnVC_Click(object sender, EventArgs e)
        {
            formVSC fs = new formVSC("Supplier", "Supplier List");
            fs.ShowDialog();
            fs.Dispose();
        }

        private void btnAddS_Click(object sender, EventArgs e)
        {
            formSCAdd fs = new formSCAdd("Supplier");
            fs.ShowDialog();
            fs.Dispose();
        }

        private void btnAddC_Click(object sender, EventArgs e)
        {
            formSCAdd fc = new formSCAdd("Category");
            fc.ShowDialog();
            fc.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAddEditItem fa = new formAddEditItem("Add",this);
            fa.ShowDialog(this);
            fa.Dispose();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Product prod = product[dataGridView1.SelectedRows[0].Index];
                formAddEditItem fa = new formAddEditItem("Edit",prod,this);
                fa.ShowDialog(this);
                fa.Dispose();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
