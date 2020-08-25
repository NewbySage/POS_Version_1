using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Object
{
    public class Pack
    {
        public int PackID { get; set; }

        public int CurrentQty { get; set; }
        public int MaxQty { get; set; }
        public int Price { get; set; }
    }
}
