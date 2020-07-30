using MySql.Data;
using POS.Properties;
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
    public partial class SalesInquiry : Form
    {
        public SalesInquiry()
        {
            InitializeComponent();
            InitializeContent();
        }

        private void InitializeContent()
        {
            DateTime now = DateTime.Now;
            comboBox1.SelectedItem = now.ToString("MMMM");
            txt_Year.Text = now.ToString("yyyy");
            /*this.imageList1.Images.Add(Properties.Resources.chart_bar);
            this.imageList1.Images.Add(Properties.Resources.excel_2013);
            this.imageList1.Images.Add(Properties.Resources.print);
            button1.ImageIndex = 0;
            button2.ImageIndex = 1;
            button3.ImageIndex = 2;*/

        }
  


}
}
