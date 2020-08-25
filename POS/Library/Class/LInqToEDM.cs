using POS.Library.Database;
using POS.Library.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Class
{
    //Add Dynamic Linq Core in the reference
    public static class LInqToEDM
    {
        public static List<Product> LinqExpProduct(posInvEntities pe, string columnName,string searchTerm)
        {
            List<Product> product = new List<Product>();
            
            if(searchTerm != "" )
            {
                //Linq Query with Dynamic Linq Core
                product = (from p in pe.tbl_product
                           join c in pe.tbl_category on p.CategoryID equals c.ID
                           join s in pe.tbl_supplier on p.SupplierID equals s.ID
                           
                           select new Product
                           {
                               ID = p.ID,
                               Barcode = p.Barcode,
                               Description = p.ItemName,
                               InitialPrice = p.InitialPrice,
                               Category = new ComboBoxItem() { Text = c.TypeName, Value = c.ID },
                               Stock = p.Stock,
                               Supplier = new ComboBoxItem() { Text = s.Supplier, Value = s.ID },
                               MinStock = p.MinStock,
                               DateRestock = p.DateRestock,
                               isByPack = p.isByPack,
                               ByPack = p.tbl_pack
                           }).Where(columnName +".Contains(@0)",searchTerm).ToList();
            }
            else
            {
                //Linq Query
                product = (from p in pe.tbl_product
                          join c in pe.tbl_category on p.CategoryID equals c.ID
                          join s in pe.tbl_supplier on p.SupplierID equals s.ID
                          
                           select new Product
                          {
                              ID = p.ID,
                              Barcode = p.Barcode,
                              Description = p.ItemName,
                              InitialPrice = p.InitialPrice,
                              Category = new ComboBoxItem() { Text = c.TypeName, Value = c.ID },
                              Supplier = new ComboBoxItem() { Text = s.Supplier, Value = s.ID },
                              DateRestock = p.DateRestock,
                              MinStock = p.MinStock,
                              isByPack = p.isByPack,
                              ByPack = p.tbl_pack
                           }).ToList();

            }

            return product;

        }

        public static List<SuppAndCat> suppAndCat(posInvEntities pe, string searchTerm,string types)
        {
            List<SuppAndCat> list = new List<SuppAndCat>();

            if (searchTerm != "")
            {
                switch (types)
                {
                    case "Category":

                        list = (from p in pe.tbl_category
                                where p.TypeName.Contains(searchTerm)
                                select new SuppAndCat
                                {
                                    ID = p.ID,
                                    CategoryName = p.TypeName
                                }).ToList();
                        break;
                    case "Supplier":
                        list = (from p in pe.tbl_supplier
                                where p.Supplier.Contains(searchTerm)
                                select new SuppAndCat
                                {
                                    ID = p.ID,
                                    Supplier = p.Supplier
                                }).ToList();
                        break;
                }

            }
            else
            {
                switch (types)
                {
                    case "Category":
                        list = (from p in pe.tbl_category
                                select new SuppAndCat
                                {
                                    ID = p.ID,
                                    CategoryName = p.TypeName
                                }).ToList();
                        break;
                    case "Supplier":
                        list = (from p in pe.tbl_supplier
                                select new SuppAndCat
                                {
                                    ID = p.ID,
                                    Supplier = p.Supplier
                                }).ToList();
                        break;
                }
            }
            return list;
        }

        public static void CUD(posInvEntities pe, string mode,Product product)
        {

            switch(mode){
                case "Add":
                    tbl_product prod = new tbl_product()
                    {
                        Barcode = product.Barcode,
                        ItemName = product.Description,
                        InitialPrice = product.InitialPrice,
                       CategoryID = product.Category.Value,
                       SupplierID = product.Supplier.Value,
                        Stock = product.Stock,
                        MinStock = product.MinStock,
                        DateRestock = product.DateRestock,
                    };
                    pe.tbl_product.Add(prod);

                    if (Convert.ToBoolean(product.isByPack) != true)
                    {
                        tbl_pack pc = new tbl_pack()
                        {
                            ID = product.ID,
                            MaxQty = product.ByPack.MaxQty,
                            Qty = product.ByPack.Qty,
                            Price = product.ByPack.Price
                        };
                        pe.tbl_pack.Add(pc);
                    }
                    pe.SaveChanges();
                    break;
                case "Edit":
                    tbl_product prod1 = pe.tbl_product.Find(product.ID);
                    prod1.Barcode = product.Barcode;
                    prod1.ItemName = product.Description;
                    prod1.InitialPrice = product.InitialPrice;
                    prod1.CategoryID = product.Category.Value;
                    prod1.SupplierID = product.Supplier.Value;
                    prod1.Stock = product.Stock;
                    prod1.MinStock = product.MinStock;
                    prod1.DateRestock = product.DateRestock;
                    prod1.isByPack = product.isByPack;
                    if (Convert.ToBoolean(product.isByPack) != true)
                    {
                        if(prod1.tbl_pack != null)
                        {
                            tbl_pack tbp = pe.tbl_pack.Find(product.ByPack.ID);
                            tbp.MaxQty = product.ByPack.MaxQty;
                            tbp.Qty = product.ByPack.Qty;
                            tbp.Price = product.ByPack.Price;

                        }
                        else
                        {
                            tbl_pack pc = new tbl_pack()
                            {
                                ID = product.ID,
                                MaxQty = product.ByPack.MaxQty,
                                Qty = product.ByPack.Qty,
                                Price = product.ByPack.Price
                            };
                            pe.tbl_pack.Add(pc);
                        }
                    }
                    pe.SaveChanges();
                    break;
                case "Delete":
                    tbl_product prod2 = pe.tbl_product.Find(product.ID);
                    tbl_pack cc = prod2.tbl_pack;
                    pe.tbl_product.Remove(prod2);
                    pe.tbl_pack.Remove(cc);
                    pe.SaveChanges();
                    break;
            }

        }
    }
}
