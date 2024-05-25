﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240525173505_RelacaoUtilizadores")]
    partial class RelacaoUtilizadores
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.BrindeModel", b =>
                {
                    b.Property<int>("IdBrinde")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBrinde"));

                    b.Property<string>("Cadastro")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("DescricaoBrinde")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeBrinde")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Saldo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValorEcopoints")
                        .HasColumnType("int");

                    b.HasKey("IdBrinde");

                    b.ToTable("TB_BRINDE");

                    b.HasData(
                        new
                        {
                            IdBrinde = 1,
                            Cadastro = "S",
                            DescricaoBrinde = "Caneca Ecológica",
                            NomeBrinde = "Caneca",
                            Quantidade = 100,
                            Saldo = 100,
                            Validade = new DateTime(2025, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9226),
                            ValorEcopoints = 150
                        },
                        new
                        {
                            IdBrinde = 2,
                            Cadastro = "S",
                            DescricaoBrinde = "Camiseta Reciclada",
                            NomeBrinde = "Camiseta",
                            Quantidade = 50,
                            Saldo = 50,
                            Validade = new DateTime(2025, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9239),
                            ValorEcopoints = 200
                        });
                });

            modelBuilder.Entity("api.Models.ColetaModel", b =>
                {
                    b.Property<int>("IdColeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColeta"));

                    b.Property<int>("CodigoEcoponto")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUtilizador")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataColeta")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEcoponto")
                        .HasColumnType("int");

                    b.Property<int>("IdUtilizador")
                        .HasColumnType("int");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<string>("SituacaoColeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalEcopoints")
                        .HasColumnType("real");

                    b.HasKey("IdColeta");

                    b.ToTable("TB_COLETA");

                    b.HasData(
                        new
                        {
                            IdColeta = 1,
                            CodigoEcoponto = 1001,
                            CodigoUtilizador = 2001,
                            DataColeta = new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9176),
                            IdEcoponto = 1,
                            IdUtilizador = 1,
                            Peso = 15.5,
                            SituacaoColeta = "Completa",
                            TotalEcopoints = 50f
                        },
                        new
                        {
                            IdColeta = 2,
                            CodigoEcoponto = 1002,
                            CodigoUtilizador = 2002,
                            DataColeta = new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9194),
                            IdEcoponto = 2,
                            IdUtilizador = 2,
                            Peso = 20.0,
                            SituacaoColeta = "Pendente",
                            TotalEcopoints = 75f
                        });
                });

            modelBuilder.Entity("api.Models.EcopointsModel", b =>
                {
                    b.Property<int>("IdMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaterial"));

                    b.Property<string>("OrdemGrandeza")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("TotalEcoPoints")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("IdMaterial");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("TB_ECOPOINTS");

                    b.HasData(
                        new
                        {
                            IdMaterial = 1,
                            OrdemGrandeza = "A",
                            Quantidade = 10,
                            TotalEcoPoints = 0,
                            UtilizadorId = 0
                        },
                        new
                        {
                            IdMaterial = 2,
                            OrdemGrandeza = "B",
                            Quantidade = 20,
                            TotalEcoPoints = 0,
                            UtilizadorId = 0
                        });
                });

            modelBuilder.Entity("api.Models.EcopontoModel", b =>
                {
                    b.Property<int>("IdEcoponto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEcoponto"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<int>("CNPJ")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Latitude")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Longitude")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEcoponto");

                    b.ToTable("TB_ECOPONTO");

                    b.HasData(
                        new
                        {
                            IdEcoponto = 1,
                            Bairro = "sla4",
                            CEP = 3081010,
                            CNPJ = 12345678,
                            Cidade = "sla5",
                            Complemento = "sla3",
                            Email = "ecoponto1@example.com",
                            Endereco = "sla2",
                            Latitude = 192,
                            Logradouro = "sla",
                            Longitude = 193,
                            Nome = "Ecoponto1",
                            PasswordHash = new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 },
                            PasswordSalt = new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 },
                            RazaoSocial = "Paz Mundial",
                            UF = "sl",
                            Username = "Ecoponto1"
                        },
                        new
                        {
                            IdEcoponto = 2,
                            Bairro = "sla4",
                            CEP = 3081010,
                            CNPJ = 12345678,
                            Cidade = "sla5",
                            Complemento = "sla3",
                            Email = "ecoponto2@example.com",
                            Endereco = "sla2",
                            Latitude = 192,
                            Logradouro = "sla",
                            Longitude = 193,
                            Nome = "Ecoponto2",
                            PasswordHash = new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 },
                            PasswordSalt = new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 },
                            RazaoSocial = "Paz Mundial",
                            UF = "sl",
                            Username = "Ecoponto2"
                        });
                });

            modelBuilder.Entity("api.Models.MateriaisModel", b =>
                {
                    b.Property<int>("IdMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaterial"));

                    b.Property<int>("Classe")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMaterial");

                    b.ToTable("TB_MATERIAIS");
                });

            modelBuilder.Entity("api.Models.UtilizadorModel", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtilizador"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("SituacaoEmail")
                        .HasColumnType("bit");

                    b.Property<int>("TotalEcoPoints")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUtilizador");

                    b.ToTable("TB_UTILIZADOR");

                    b.HasData(
                        new
                        {
                            IdUtilizador = 1,
                            Email = "joao123@gmail.com",
                            Nome = "João",
                            PasswordHash = new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 },
                            PasswordSalt = new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 },
                            SituacaoEmail = true,
                            TotalEcoPoints = 0,
                            Username = "UsuarioJoao"
                        },
                        new
                        {
                            IdUtilizador = 2,
                            Email = "maria123@gmail.com",
                            Nome = "Maria",
                            PasswordHash = new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 },
                            PasswordSalt = new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 },
                            SituacaoEmail = true,
                            TotalEcoPoints = 0,
                            Username = "UsuarioMaria"
                        },
                        new
                        {
                            IdUtilizador = 3,
                            DataAcesso = new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9249),
                            Email = "admin@example.com",
                            Nome = "Admin",
                            PasswordHash = new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 },
                            PasswordSalt = new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 },
                            SituacaoEmail = true,
                            TotalEcoPoints = 0,
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("api.Models.EcopointsModel", b =>
                {
                    b.HasOne("api.Models.UtilizadorModel", "Utilizador")
                        .WithMany("Ecopoints")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("api.Models.UtilizadorModel", b =>
                {
                    b.Navigation("Ecopoints");
                });
#pragma warning restore 612, 618
        }
    }
}