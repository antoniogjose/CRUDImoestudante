﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDImoestudante
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ImoEstudanteEntities : DbContext
    {
        public ImoEstudanteEntities()
            : base("name=ImoEstudanteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alojamento> alojamentoes { get; set; }
        public virtual DbSet<aluguer> aluguers { get; set; }
        public virtual DbSet<areaCurso> areaCursoes { get; set; }
        public virtual DbSet<comodidade> comodidades { get; set; }
        public virtual DbSet<comudidadesAlojamento> comudidadesAlojamentoes { get; set; }
        public virtual DbSet<curso> cursoes { get; set; }
        public virtual DbSet<estado> estadoes { get; set; }
        public virtual DbSet<genero> generoes { get; set; }
        public virtual DbSet<instituicaoEnsino> instituicaoEnsinoes { get; set; }
        public virtual DbSet<morada> moradas { get; set; }
        public virtual DbSet<pai> pais { get; set; }
        public virtual DbSet<tipoAlojamento> tipoAlojamentoes { get; set; }
        public virtual DbSet<tipologia> tipologias { get; set; }
        public virtual DbSet<tipoUser> tipoUsers { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
