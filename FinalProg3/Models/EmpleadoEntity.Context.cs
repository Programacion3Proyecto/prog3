﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProg3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class consultorioEntities : DbContext
    {
        public consultorioEntities()
            : base("name=consultorioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<empleados> empleados { get; set; }
        public DbSet<empleados> usuario { get; set; }
        public DbSet<empleados> clave { get; set; }
        public DbSet<empleados> puesto { get; set; }
    }
}
