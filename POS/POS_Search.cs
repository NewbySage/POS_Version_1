using System;
using System.Windows.Forms;

namespace POS
{
    public partial class POS_search : Form
    {
        public POS_search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POS_add pa = new POS_add();
            pa.Show();
        }
    }
}
