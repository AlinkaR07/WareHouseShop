﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class foodshopEntities : DbContext
    {
        public foodshopEntities()
            : base("name=foodshopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryTovara> CategoryTovara { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Postavshik> Postavshik { get; set; }
        public virtual DbSet<Tovar> Tovar { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<Write> Write { get; set; }
        public virtual DbSet<LineOrder> LineOrder { get; set; }
        public virtual DbSet<LineWrite> LineWrite { get; set; }
    }
}
