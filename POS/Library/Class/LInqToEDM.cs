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
                               Barcode = p.Barcode,
                               Description = p.ItemName,
                               InitialPrice = p.InitialPrice,
                               Category = c.TypeName,
                               Stock = p.Stock,
                               Supplier = s.Supplier,
                               DateRestock = p.DateRestock
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
                             Barcode = p.Barcode,
                             Description = p.ItemName,
                             InitialPrice = p.InitialPrice,
                             Category = c.TypeName,
                             Stock = p.Stock,
                             Supplier = s.Supplier,
                             DateRestock = p.DateRestock
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
    }
}
