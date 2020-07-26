using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Object
{
    public class Users
    {
        private string Name;
        private string Username;
        private string Password;
        private bool isAdmin;

        public Users(string name, string username, string password, bool isAdmin)
        {
            Name = name;
            Username = username;
            Password = password;
            this.isAdmin = isAdmin;
        }

        public string Name1 { get => Name; private set => Name = value; }
        public string Username1 { get => Username; private set => Username = value; }
        public string Password1 { get => Password; private set => Password = value; }
        public bool IsAdmin { get => isAdmin; private set => isAdmin = value; }
    }
}
