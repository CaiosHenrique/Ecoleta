using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BRINDE",
                columns: table => new
                {
                    IdBrinde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoBrinde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeBrinde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastro = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    ValorEcopoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BRINDE", x => x.IdBrinde);
                });

            migrationBuilder.CreateTable(
                name: "TB_COLETA",
                columns: table => new
                {
                    IdColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEcoponto = table.Column<int>(type: "int", nullable: false),
                    CodigoEcoponto = table.Column<int>(type: "int", nullable: false),
                    IdUtilizador = table.Column<int>(type: "int", nullable: false),
                    CodigoUltilizador = table.Column<int>(type: "int", nullable: false),
                    DataColeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalEcopoints = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    SituacaoColeta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COLETA", x => x.IdColeta);
                });

            migrationBuilder.CreateTable(
                name: "TB_ECOPOINTS",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemGrandeza = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    EcoPointsTotais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ECOPOINTS", x => x.IdMaterial);
                });

            migrationBuilder.CreateTable(
                name: "TB_ECOPONTO",
                columns: table => new
                {
                    IdEcoponto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<int>(type: "int", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ECOPONTO", x => x.IdEcoponto);
                });

            migrationBuilder.CreateTable(
                name: "TB_MATERIAIS",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MATERIAIS", x => x.IdMaterial);
                });

            migrationBuilder.CreateTable(
                name: "TB_UTILIZADOR",
                columns: table => new
                {
                    IdUtilizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoEmail = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_UTILIZADOR", x => x.IdUtilizador);
                });

            migrationBuilder.InsertData(
                table: "TB_ECOPONTO",
                columns: new[] { "IdEcoponto", "Bairro", "CEP", "CNPJ", "Cidade", "Complemento", "Endereco", "Latitude", "Logradouro", "Longitude", "Nome", "RazaoSocial", "UF" },
                values: new object[,]
                {
                    { 1, "sla4", 3081010, 12345678, "sla5", "sla3", "sla2", 192, "sla", 193, "Ecoponto1", "Paz Mundial", "sl" },
                    { 2, "sla4", 3081010, 12345678, "sla5", "sla3", "sla2", 192, "sla", 193, "Ecoponto2", "Paz Mundial", "sl" }
                });

            migrationBuilder.InsertData(
                table: "TB_UTILIZADOR",
                columns: new[] { "IdUtilizador", "Email", "Nome", "SituacaoEmail" },
                values: new object[,]
                {
                    { 1, "joao123@gmail.com", "João", true },
                    { 2, "maria123@gmail.com", "Maria", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BRINDE");

            migrationBuilder.DropTable(
                name: "TB_COLETA");

            migrationBuilder.DropTable(
                name: "TB_ECOPOINTS");

            migrationBuilder.DropTable(
                name: "TB_ECOPONTO");

            migrationBuilder.DropTable(
                name: "TB_MATERIAIS");

            migrationBuilder.DropTable(
                name: "TB_UTILIZADOR");
        }
    }
}
