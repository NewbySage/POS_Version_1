using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace POS.Library.Object
{
    public class Users
    {
        private string Name;
        private string Username;
        private byte[] me;
        private bool isAdmin;

        public Users()
        {

        }

        public string Name1 { get => Name; set => Name = value; }
        public string Username1 { get => Username; set => Username = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public byte[] Me { get => me; set => me = value; }
    }
}
