﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.Library.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class posInvEntities : DbContext
    {
        public posInvEntities()
            : base("name=posInvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_invoice> tbl_invoice { get; set; }
        public virtual DbSet<tbl_pack> tbl_pack { get; set; }
        public virtual DbSet<tbl_product> tbl_product { get; set; }
        public virtual DbSet<tbl_sales> tbl_sales { get; set; }
        public virtual DbSet<tbl_supplier> tbl_supplier { get; set; }
        public virtual DbSet<tbl_users> tbl_users { get; set; }
    }
}
