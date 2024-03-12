// using System;
// using api.Controllers;
// using api.Models;

// namespace api.Data
// {
//     public class DataContext : DbContext
//     {
//         public DataContext(DbContextOptions<DataContext> options) : base(options) 
//         { 

//         }
//         public DbSet<Utilizador> Tabela_Utilizador { get; set; }

//          protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Utilizador>().ToTable("Utilizador");
//             (
//                 modelBuilder.Entity<Utilizador>().Property(u => u.IdUtilizador).HasColumnName("IdUtilizador"),
//                 modelBuilder.Entity<Utilizador>().Property(u => u.Nome).HasColumnName("Nome"),
//                 modelBuilder.Entity<Utilizador>().Property(u => u.Email).HasColumnName("Email"),
//                 modelBuilder.Entity<Utilizador>().Property(u => u.SituacaoEmail).HasColumnName("SituacaoEmail")
//             )
//         }
//     }
// }