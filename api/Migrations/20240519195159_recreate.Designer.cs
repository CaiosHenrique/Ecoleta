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
    [Migration("20240519195159_recreate")]
    partial class recreate
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
                            Validade = new DateTime(2025, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1543),
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
                            Validade = new DateTime(2025, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1553),
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
                            DataColeta = new DateTime(2024, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1505),
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
                            DataColeta = new DateTime(2024, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1519),
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

                    b.Property<int>("EcoPointsTotais")
                        .HasColumnType("int");

                    b.Property<string>("OrdemGrandeza")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdMaterial");

                    b.ToTable("TB_ECOPOINTS");

                    b.HasData(
                        new
                        {
                            IdMaterial = 1,
                            EcoPointsTotais = 100,
                            OrdemGrandeza = "A",
                            Quantidade = 10
                        },
                        new
                        {
                            IdMaterial = 2,
                            EcoPointsTotais = 200,
                            OrdemGrandeza = "B",
                            Quantidade = 20
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
                            PasswordHash = new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 },
                            PasswordSalt = new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 },
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
                            PasswordHash = new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 },
                            PasswordSalt = new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 },
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
                            PasswordHash = new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 },
                            PasswordSalt = new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 },
                            SituacaoEmail = true,
                            Username = "UsuarioJoao"
                        },
                        new
                        {
                            IdUtilizador = 2,
                            Email = "maria123@gmail.com",
                            Nome = "Maria",
                            PasswordHash = new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 },
                            PasswordSalt = new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 },
                            SituacaoEmail = true,
                            Username = "UsuarioMaria"
                        },
                        new
                        {
                            IdUtilizador = 3,
                            DataAcesso = new DateTime(2024, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1560),
                            Email = "admin@example.com",
                            Nome = "Admin",
                            PasswordHash = new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 },
                            PasswordSalt = new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 },
                            SituacaoEmail = true,
                            Username = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}