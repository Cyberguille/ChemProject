//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chem.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChemDBEntities : DbContext
    {
        public ChemDBEntities()
            : base("name=ChemDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Guide> Guide { get; set; }
        public virtual DbSet<Substance> Substance { get; set; }
        public virtual DbSet<Substance_Entity> Substance_Entity { get; set; }
        public virtual DbSet<Substance_Guide> Substance_Guide { get; set; }
        public virtual DbSet<Substance_Synonym> Substance_Synonym { get; set; }
        public virtual DbSet<Synonym> Synonym { get; set; }
    }
}