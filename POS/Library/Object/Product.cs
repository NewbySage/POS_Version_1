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

        public Product(string barcode, string description, float initialPrice, int category, int stock, int minStock, int supplier, DateTime dateRestock)
        {

            Barcode = barcode;
            Description = description;
            InitialPrice = initialPrice;
            CategoryID = category;
            Stock = stock;
            MinStock = minStock;
            SupplierID = supplier;
            DateRestock = dateRestock;
        }

        public int ID { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public float InitialPrice { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public string Supplier { get; set; }
        public DateTime DateRestock { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public tbl_pack ByPack { get; internal set; }
        public sbyte isByPack { get; set; }

    }
}
