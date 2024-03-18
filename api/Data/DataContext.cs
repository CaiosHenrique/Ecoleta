using System;
using api.Controllers;
using api.Models;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Utilizador> TB_UTILIZADOR { get; set; }
            public DbSet<Ecoponto> TB_ECOPONTO { get; set; }
             public DbSet<EcoPoints> TB_ECOPOINTS { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<Utilizador>().ToTable("Utilizador");
            (
                modelBuilder.Entity<Utilizador>().Property(u => u.IdUtilizador).HasColumnName("IdUtilizador"),
                modelBuilder.Entity<Utilizador>().Property(u => u.Nome).HasColumnName("Nome"),
                modelBuilder.Entity<Utilizador>().Property(u => u.Email).HasColumnName("Email"),
                modelBuilder.Entity<Utilizador>().Property(u => u.SituacaoEmail).HasColumnName("SituacaoEmail")
            )
            modelBuilder.Entity<Ecoponto>().ToTable("Ecoponto");
            (
                modelBuilder.Entity<Ecoponto>().Property(p => p.IdEcoponto).HasColumnName("IdEcoponto"),
             modelBuilder.Entity<Ecoponto>().Property(p => p.Nome).HasColumnName("Nome"),
             modelBuilder.Entity<Ecoponto>().Property(p => p.Bairro).HasColumnName("Bairro"),
             modelBuilder.Entity<Ecoponto>().Property(p => p.Cidade).HasColumnName("Cidade"),
                modelBuilder.Entity<Ecoponto>().Property(p => p.Longitude).HasColumnName("Longitude"),
                modelBuilder.Entity<Ecoponto>().Property(p => p.Latitude).HasColumnName("Latitude"),
                modelBuilder.Entity<Ecoponto>().Property(p => p.CNPJ).HasColumnName("CNPJ"),
                modelBuilder.Entity<Ecoponto>().Property(p => p.CEP).HasColumnName("CEP")
            )
            modelBuilder.Entity<EcoPoints>().ToTable("EcoPoints");
            (
                modelBuilder.Entity<EcoPoints>().Property(e => e.IdMaterial).HasColumnName("IdMaterial"),
                modelBuilder.Entity<EcoPoints>().Property(e => e.OrdemGrandeza).HasColumnName("OrdemGrandeza"),
                modelBuilder.Entity<EcoPoints>().Property(e => e.Quantidade).HasColumnName("Quantidade"),
                modelBuilder.Entity<EcoPoints>().Property(e => e.EcoPointsTotais).HasColumnName("EcoPointsTotais")
            )
        }
    }
}
