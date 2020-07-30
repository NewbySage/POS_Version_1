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
        private Users user = null;
        public Home(Users user)
        {
            this.user = user;
            InitializeComponent();
            InitializeComponent2();
        }

        //Debug use
        public Home()
        {

            InitializeComponent();
            InitializeComponent2();
        }





        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var text = this.tabControl1.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(text, this.tabControl1.Font);

            var x = e.Bounds.Left + 3;
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;

            g.DrawString(text, this.tabControl1.Font, Brushes.Black, x, y);
        }

        private void InitializeComponent2()
        {
            //Tab Sales connect ot Usercontrol Sales
            Home_User_Control.Sales sales = new Home_User_Control.Sales();
            sales.Dock = DockStyle.Fill;
            tabSales.Controls.Add(sales);

            //Tab Dashboard connect ot Usercontrol Dashboard
            Home_User_Control.Dashboard dashboard = new Home_User_Control.Dashboard();
            dashboard.Dock = DockStyle.Fill;
            tabDashboard.Controls.Add(dashboard);

            //Tab Inventory connect ot Usercontrol Inventory
            Home_User_Control.Inventory inventory = new Home_User_Control.Inventory();
            inventory.Dock = DockStyle.Fill;
            tabInven.Controls.Add(inventory);

            //Tab Employee connect ot Usercontrol Employee
            Home_User_Control.Employee employee = new Home_User_Control.Employee();
            employee.Dock = DockStyle.Fill;
            tabEmp.Controls.Add(employee);

            //Tab setting connect ot Usercontrol Setting
            Home_User_Control.Setting setting = new Home_User_Control.Setting();
            setting.Dock = DockStyle.Fill;
            tabSetting.Controls.Add(setting);


        }
    }
}
