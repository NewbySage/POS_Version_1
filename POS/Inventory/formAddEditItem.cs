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
    public partial class formAddEditItem : Form
    {
        posInvEntities pe;
        string Modes;
        Product product;
        Home_User_Control.Inventory user;

        
        //Add Constructor
        public formAddEditItem(string mode, Home_User_Control.Inventory user)
        {
            Modes = mode;
            product = new Product();
            pe = new posInvEntities();
            product.Category = new ComboBoxItem();
            product.Supplier = new ComboBoxItem();
            this.user = user;
            InitializeComponent();
            Init();
        }


        //Edit Constructor
        public formAddEditItem(string mode,Product product, Home_User_Control.Inventory user)
        {
            Modes = mode;
            this.product = product;
            this.user = user;
            pe = new posInvEntities();
            InitializeComponent();
            Init();
        }

        public void Init()
        {

            //Method if the Add or Edit form
            isMode(Modes);

            // Datasource for Category TextBox
            List<ComboBoxItem> cat = (from p in pe.tbl_category
                                    select new ComboBoxItem
                                    {
                                        Value= p.ID,
                                        Text = p.TypeName
                                    }).ToList();
            
            // Datasource for Supplier TextBox
            List<ComboBoxItem> sup = (from p in pe.tbl_supplier
                                    select new ComboBoxItem
                                    {
                                        Value = p.ID,
                                        Text = p.Supplier
                                    }).ToList();
            
            //Insert the --Select-- for the default value of ComboBox Category and Supplier
            cat.Insert(0, new ComboBoxItem { Text = "--Select--", Value = 0 });
            sup.Insert(0, new ComboBoxItem { Text = "--Select--", Value = 0 });

            //
            cbCat.DataSource = cat;
            cbCat.DisplayMember = "Text";
            cbCat.ValueMember = "Value";
            cbSupp.DataSource = sup;
            cbSupp.DisplayMember = "Text";
            cbSupp.ValueMember = "Value";
           
            


            // Placing the Data for the Edit
            txtBarcode.DataBindings.Add("Text", product, "Barcode", true, DataSourceUpdateMode.OnPropertyChanged);
            product.DateRestock = DateTime.Now;
            dateTimePicker1.DataBindings.Add("Value", product, "DateRestock", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDesc.DataBindings.Add("Text", product, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMStock.DataBindings.Add("Text", product, "MinStock", true, DataSourceUpdateMode.OnPropertyChanged);
            txtStock.DataBindings.Add("Text", product, "Stock", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrice.DataBindings.Add("Text", product, "InitialPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            cbCat.DataBindings.Add("SelectedValue", product, "Category.Value", true, DataSourceUpdateMode.OnPropertyChanged);
            cbSupp.DataBindings.Add("SelectedValue", product, "Supplier.Value", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBox2.DataBindings.Add("Checked", product, "isBypack", true, DataSourceUpdateMode.OnPropertyChanged);
            

            //
            isCheckBarcodeAndByPack(checkBox2,"ByPack");




        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

            if (txtBarcode.Text != "" && txtDesc.Text != "" && txtMStock.Text != "" && txtStock.Text != "" && txtPrice.Text != "" && cbCat.SelectedItem.ToString() != "--Select--" && cbSupp.SelectedItem.ToString() != "--Select--" && (checkBox2.Checked == false) ? txtMQ.Text != "" : true && (checkBox2.Checked == false) ? txtCQ.Text != "" : true && (checkBox2.Checked == false) ? txtPP.Text != "" : true)
            {
               if(Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtMStock.Text))
                {
                    string title = (Modes == "Add") ? "Can't Add" : "Can't Edit";
                    MessageBox.Show("Minimun Stock is Greater Than Stock", title);
                    return;
                }
               if(checkBox2.Checked == false)
                {
                    if(Convert.ToInt32(txtCQ.Text) > Convert.ToInt32(txtMQ.Text))
                    {
                        string title = (Modes == "Add") ? "Can't Add" : "Can't Edit";
                        MessageBox.Show("Current Piece is Greater That Maximum Piece", title);
                        return;
                    }
                }
                
                if ((Modes == "Add") ? (!(pe.tbl_product.Any(a => a.Barcode == txtBarcode.Text))  && !(pe.tbl_product.Any(b => b.ItemName == txtDesc.Text))): true)
                {
                    //Product product = new Product(txtBarcode.Text,txtDesc.Text,float.Parse(txtPrice.Text),(int)cbCat.SelectedValue,int.Parse(txtStock.Text),int.Parse(txtMStock.Text),(int)cbSupp.SelectedValue,DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd HH:mm tt", null));
                    ///
                    product.Supplier.Text = cbSupp.SelectedItem.ToString();
                    product.Category.Text = cbCat.SelectedItem.ToString();
                   ///
                    
                    LInqToEDM.CUD(pe, Modes, product);
                    user.passData(product,Modes);
                    string message = (Modes == "Add") ? "Successfully Add" : "Successfully Edit";
                    string title = (Modes == "Add") ? "Add Product" : "Update Product";
                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    string message = (Modes == "Add") ? "There is Existing Product or The Description is Used" : "The Description is Used";
                    string title = (Modes == "Add") ? "Can't Add" : "Can't Edit";
                    MessageBox.Show(message, title);


                }
            }
            else
            {
                string title = (Modes == "Add") ? "Can't Add" : "Can't Edit";
                MessageBox.Show("Please fill all the TextBox", title);
            }


        }

        //Cancel Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Checkbox Event Listener
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            isCheckBarcodeAndByPack(c,"Barcode");
        }

        // 
        private void isMode(string modes)
        {
            switch (modes)
            {
                case "Add":
                    checkBox1.Enabled = true;
                    isCheckBarcodeAndByPack(checkBox1,"Barcode");
                    isCheckBarcodeAndByPack(checkBox2, "ByPack");
                    groupBox1.Text = "Inventory Add Item";
                    btnAddItem.Text = "Add";
                    break;
                case "Edit":
                    // Disable barcode textbox, buttons and checkbox
                    checkBox1.Enabled = false;
                    txtBarcode.ReadOnly = true;
                    btnRB.Enabled = false;
                    groupBox1.Text = "Inventory Edit Item";
                    btnAddItem.Text = "Edit";
                    break;
            }

        }

        //Check if Auto Generated Barcode and check if byPack
        private void isCheckBarcodeAndByPack(CheckBox c,string cBIdentifier)
        {
            switch (cBIdentifier)
            {
                case "Barcode":
                    if (c.Checked)
                    {
                        txtBarcode.ReadOnly = true;
                        btnRB.Enabled = true;
                    }
                    else
                    {
                        txtBarcode.ReadOnly = false;
                        btnRB.Enabled = false;
                    }
                    break;
                case "ByPack":
                    if (c.Checked)
                    {
                        groupBox2.Hide();
                        txtMQ.DataBindings.Clear();
                        txtCQ.DataBindings.Clear();
                        txtPP.DataBindings.Clear();

                    }
                    else
                    {
                        groupBox2.Show();
                        if (product.ByPack == null)  product.ByPack =  new tbl_pack() { ID = product.ID};
                        txtMQ.DataBindings.Add("Text", product, "Bypack.MaxQty", true, DataSourceUpdateMode.OnPropertyChanged);
                        txtCQ.DataBindings.Add("Text", product, "Bypack.Qty", true, DataSourceUpdateMode.OnPropertyChanged);
                        txtPP.DataBindings.Add("Text", product, "Bypack.Price", true, DataSourceUpdateMode.OnPropertyChanged);
                    }
                    break;
            }

        }
        //Button for Auto Generated Barcode
        private void btnRB_Click(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = System.Text.RegularExpressions.Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, 12);
            txtBarcode.Text = barcode;
            txtBarcode.Refresh();
        }


        //Form Closing for formAddEditITem
        private void formAddEditItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            pe.Dispose();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            isCheckBarcodeAndByPack(sender as CheckBox, "ByPack");
        }


    }
}
