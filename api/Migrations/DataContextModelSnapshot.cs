﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Validade = new DateTime(2025, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3844),
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
                            Validade = new DateTime(2025, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3854),
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
                            DataColeta = new DateTime(2024, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3786),
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
                            DataColeta = new DateTime(2024, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3801),
                            IdEcoponto = 2,
                            IdUtilizador = 2,
                            Peso = 20.0,
                            SituacaoColeta = "Pendente",
                            TotalEcopoints = 75f
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

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

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
                            Latitude = 192.0,
                            Logradouro = "sla",
                            Longitude = 193.0,
                            Nome = "Ecoponto1",
                            Numero = 3149,
                            PasswordHash = new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 },
                            PasswordSalt = new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 },
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
                            Latitude = 192.0,
                            Logradouro = "sla",
                            Longitude = 193.0,
                            Nome = "Ecoponto2",
                            Numero = 319,
                            PasswordHash = new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 },
                            PasswordSalt = new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 },
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

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

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
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Nome = "João",
                            PasswordHash = new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 },
                            PasswordSalt = new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 },
                            SituacaoEmail = true,
                            TotalEcoPoints = 100,
                            Username = "UsuarioJoao"
                        },
                        new
                        {
                            IdUtilizador = 2,
                            Email = "maria123@gmail.com",
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Nome = "Maria",
                            PasswordHash = new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 },
                            PasswordSalt = new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 },
                            SituacaoEmail = true,
                            TotalEcoPoints = 100,
                            Username = "UsuarioMaria"
                        },
                        new
                        {
                            IdUtilizador = 3,
                            DataAcesso = new DateTime(2024, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3866),
                            Email = "admin@example.com",
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Nome = "Admin",
                            PasswordHash = new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 },
                            PasswordSalt = new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 },
                            SituacaoEmail = true,
                            TotalEcoPoints = 0,
                            Username = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
