using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Object
{
    public class Product
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public float InitialPrice { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public string Supplier { get; set; }
        public DateTime DateRestock { get; set; }
}
}
