﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class systemdbEntities : DbContext
    {
        public systemdbEntities()
            : base("name=systemdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<account> accounts { get; set; }
        public DbSet<adminaccount> adminaccounts { get; set; }
        public DbSet<bussinesstype> bussinesstypes { get; set; }
        public DbSet<clientaccount> clientaccounts { get; set; }
        public DbSet<listreward> listrewards { get; set; }
        public DbSet<promotion> promotions { get; set; }
        public DbSet<qrcode> qrcodes { get; set; }
        public DbSet<reward> rewards { get; set; }
        public DbSet<store> stores { get; set; }
        public DbSet<storeaccount> storeaccounts { get; set; }
        public DbSet<ticket> tickets { get; set; }
    }
}
