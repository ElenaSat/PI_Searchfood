﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI_SearchfoodF.MVC.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_SEARCHFOODEntities : DbContext
    {
        public BD_SEARCHFOODEntities()
            : base("name=BD_SEARCHFOODEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbEstado_Incidencia> tbEstado_Incidencia { get; set; }
        public virtual DbSet<tbIncidencia> tbIncidencia { get; set; }
        public virtual DbSet<tbIncidencia_Comentarios> tbIncidencia_Comentarios { get; set; }
        public virtual DbSet<tbTipoIncidencia> tbTipoIncidencia { get; set; }
    }
}
