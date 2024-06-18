using System;
using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UtilizadorModel> TB_UTILIZADOR { get; set; }
        public DbSet<EcopontoModel> TB_ECOPONTO { get; set; }
        public DbSet<ColetaModel> TB_COLETA { get; set; }
        public DbSet<MateriaisModel> TB_MATERIAIS { get; set; }
        public DbSet<BrindeModel> TB_BRINDE { get; set; }
        public DbSet<ResgateModel> TB_RESGATE { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            byte[] passwordHash, passwordSalt;

            Criptografia.CriarPasswordHash("123456", out passwordHash, out passwordSalt);

            modelBuilder.Entity<UtilizadorModel>().HasData(
                new UtilizadorModel() { IdUtilizador = 1, Nome = "João", Email = "joao123@gmail.com", SituacaoEmail = true, Username = "UsuarioJoao", PasswordHash = passwordHash, PasswordSalt = passwordSalt,TotalEcoPoints = 100 },
                new UtilizadorModel() { IdUtilizador = 2, Nome = "Maria", Email = "maria123@gmail.com", SituacaoEmail = true, Username = "UsuarioMaria", PasswordHash = passwordHash, PasswordSalt = passwordSalt,TotalEcoPoints = 100}
            );

            modelBuilder.Entity<EcopontoModel>().HasData(
                new EcopontoModel() { IdEcoponto = 1, Nome = "Ecoponto1", CNPJ = 12345678, RazaoSocial = "Paz Mundial", Logradouro = "sla", Endereco = "sla2", Complemento = "sla3", Bairro = "sla4", Cidade = "sla5", UF = "sl", CEP = 03081010, Latitude = 0192, Longitude = 0193, Email = "ecoponto1@example.com", Username = "Ecoponto1", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Numero = 3149},
                new EcopontoModel() { IdEcoponto = 2, Nome = "Ecoponto2", CNPJ = 12345678, RazaoSocial = "Paz Mundial", Logradouro = "sla", Endereco = "sla2", Complemento = "sla3", Bairro = "sla4", Cidade = "sla5", UF = "sl", CEP = 03081010, Latitude = 0192, Longitude = 0193, Email = "ecoponto2@example.com", Username = "Ecoponto2", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Numero = 319}
            );

            modelBuilder.Entity<ColetaModel>().HasData(
                new ColetaModel() { IdColeta = 1, IdEcoponto = 1, IdUtilizador = 1, CodigoEcoponto = 1001, CodigoUtilizador = 2001, DataColeta = DateTime.Now, TotalEcopoints = 50.0f, Peso = 15.5, SituacaoColeta = "Completa" },
                new ColetaModel() { IdColeta = 2, IdEcoponto = 2, IdUtilizador = 2, CodigoEcoponto = 1002, CodigoUtilizador = 2002, DataColeta = DateTime.Now, TotalEcopoints = 75.0f, Peso = 20.0, SituacaoColeta = "Pendente" }
            );

            modelBuilder.Entity<BrindeModel>().HasData(
                new BrindeModel() { IdBrinde = 1, DescricaoBrinde = "Caneca Ecológica", NomeBrinde = "Caneca", Cadastro = 'S', Validade = DateTime.Now.AddYears(1), Quantidade = 100, Saldo = 100, ValorEcopoints = 150 },
                new BrindeModel() { IdBrinde = 2, DescricaoBrinde = "Camiseta Reciclada", NomeBrinde = "Camiseta", Cadastro = 'S', Validade = DateTime.Now.AddYears(1), Quantidade = 50, Saldo = 50, ValorEcopoints = 200 }
            );
            modelBuilder.Entity<ResgateModel>().HasData(
                new ResgateModel() { IdResgate = 1, IdUtilizador = 1, IdBrinde = 1, DataResgate = DateTime.Now },
                new ResgateModel() { IdResgate = 2, IdUtilizador = 2, IdBrinde = 2, DataResgate = DateTime.Now }
            );

            // Seed data for an admin user
            var adminUser = new UtilizadorModel
            {
                IdUtilizador = 3,
                Nome = "Admin",
                Email = "admin@example.com",
                SituacaoEmail = true,
                Username = "Admin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DataAcesso = DateTime.Now
            };
            modelBuilder.Entity<UtilizadorModel>().HasData(adminUser);
        }
    }
}
