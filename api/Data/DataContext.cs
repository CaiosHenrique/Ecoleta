using System;
using api.Controllers;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
            public DbSet<UtilizadorModel> TB_UTILIZADOR { get; set; }
            public DbSet<EcopontoModel> TB_ECOPONTO { get; set; }
            public DbSet<EcopointsModel> TB_ECOPOINTS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<UtilizadorModel>().ToTable("Utilizador");
            (
                new UtilizadorModel() { IdUtilizador = 1, Nome = "João", Email = "joao123@gmail.com", SituacaoEmail = true },
                new UtilizadorModel() { IdUtilizador = 2, Nome = "Maria", Email = "maria123@gmail.com", SituacaoEmail = true }
            );

            modelBuilder.Entity<EcopontoModel>().ToTable("Ecoponto");
            (
               new EcopontoModel() { IdEcoponto = 1, Nome = "Ecoponto1", CNPJ = 12345678, RazaoSocial = "Paz Mundial", Logradouro = "sla", Endereco = "sla2", Complemento = "sla3", Bairro = "sla4", Cidade = "sla5", UF = "sl", CEP = 03081010, Latitude = 0192, Longitude = 0193 },
               new EcopontoModel() { IdEcoponto = 2, Nome = "Ecoponto2", CNPJ = 12345678, RazaoSocial = "Paz Mundial", Logradouro = "sla", Endereco = "sla2", Complemento = "sla3", Bairro = "sla4", Cidade = "sla5", UF = "sl", CEP = 03081010, Latitude = 0192, Longitude = 0193 }
            );


         }
    }
}
