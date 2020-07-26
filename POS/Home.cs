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

namespace POS
{
    public partial class Home : Form
    {
        private Users user;
        public Home(Users user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            POS ps = new POS(user);
            ps.ShowDialog();

        }
    }
}
