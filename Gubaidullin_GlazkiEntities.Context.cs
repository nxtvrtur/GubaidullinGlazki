﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GubaidullinGlazki
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Gubaidullin_GlazkiEntities : DbContext
    {
        public static Gubaidullin_GlazkiEntities _context;
        public Gubaidullin_GlazkiEntities()
            : base("name=Gubaidullin_GlazkiEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public static Gubaidullin_GlazkiEntities GetContext()
        {
            if (_context == null)
            {
                _context = new Gubaidullin_GlazkiEntities();
            }

            return _context;
        }

        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        public virtual DbSet<AgentType> AgentType { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialCountHistory> MaterialCountHistory { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterial { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
    }
}
