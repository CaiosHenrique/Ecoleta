using System;
using api.Controllers;
using api.models;
using Microsoft.EntityFrameworkCore;


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
                new Utilizador() { IdUtilizador = 1, Nome = "João", Email = "joao123@gmail.com", SituacaoEmail = true },
                new Utilizador() { IdUtilizador = 2, Nome = "Maria", Email = "maria123@gmail.com", SituacaoEmail = true }
            );


         }
    }
}
