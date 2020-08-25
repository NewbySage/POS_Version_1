using POS.Library.Database;
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
    public partial class formSCAdd : Form
    {
        string title;
        public formSCAdd(string title)
        {
            this.title = title;
            InitializeComponent();
            this.Text = "Point of Sale (" + title + " Add)";
            label1.Text = title + " Name:";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add code for Supplier and Category Table
            posInvEntities pe = new posInvEntities();

            try
            {
                if (textBox1.Text != "")
                {
                    switch (title)
                    {
                        case "Category":
                            //List<string> sa = (from p in pe.tbl_category where p.TypeName == textBox1.Text select p.TypeName).ToList();
                            if (!(pe.tbl_category.Any(o => o.TypeName == textBox1.Text)))
                            {
                                tbl_category a = new tbl_category();
                                a.TypeName = textBox1.Text;
                                pe.tbl_category.Add(a);
                                pe.SaveChanges();
                                DialogResult d = MessageBox.Show("Succesfully Added to Category", "Succesfully Added", MessageBoxButtons.OK);
                                if (d == DialogResult.OK)
                                {

                                    this.Close();
                                }
                            }
                            else
                            {

                                MessageBox.Show("Category have that Category Name", "Failed to Add" + title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            break;
                        case "Supplier":
                            List<string> sa1 = (from p in pe.tbl_supplier where p.Supplier == textBox1.Text select p.Supplier).ToList();
                            if (sa1.Count == 0)
                            {
                                tbl_supplier s = new tbl_supplier();
                                s.Supplier = textBox1.Text;
                                pe.tbl_supplier.Add(s);
                                pe.SaveChanges();
                                DialogResult d = MessageBox.Show("Succesfully Added to Supplier", "Succesfully Added", MessageBoxButtons.OK);
                                if (d == DialogResult.OK)
                                {

                                    this.Close();
                                }
                            }
                            else
                            {

                                MessageBox.Show("Supplier have that Supplier Name", "Failed to Add" + title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("The textbox is Empty", "Failed to Execute" + title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                pe.Dispose();
            }
        }


    }
}
