using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Home_User_Control
{
    public partial class Sales : UserControl
    {
        public Sales()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            POS pos = new POS();
            pos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesInquiry sI = new SalesInquiry();
            sI.Show();
        }
    }
}
