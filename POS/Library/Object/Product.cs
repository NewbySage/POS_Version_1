using POS.Library.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Object
{
    public class Product
    {
        
        public Product()
        {

        }


        public int ID { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public float InitialPrice { get; set; }
        public ComboBoxItem Category { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public ComboBoxItem Supplier { get; set; }
        public DateTime DateRestock { get; set; }
        //public int SupplierID { get; set; }
        //public int CategoryID { get; set; }
        public tbl_pack ByPack { get; internal set; }
        public sbyte isByPack { get; set; }

    }
}
