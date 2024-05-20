using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModelsWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoUltilizador",
                table: "TB_COLETA",
                newName: "CodigoUtilizador");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAcesso",
                table: "TB_UTILIZADOR",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "TB_UTILIZADOR",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TB_UTILIZADOR",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TB_UTILIZADOR",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TB_ECOPONTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "TB_ECOPONTO",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TB_ECOPONTO",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TB_ECOPONTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TB_BRINDE",
                columns: new[] { "IdBrinde", "Cadastro", "DescricaoBrinde", "NomeBrinde", "Quantidade", "Saldo", "Validade", "ValorEcopoints" },
                values: new object[,]
                {
                    { 1, "S", "Caneca Ecológica", "Caneca", 100, 100, new DateTime(2025, 5, 19, 16, 21, 16, 837, DateTimeKind.Local).AddTicks(3051), 150 },
                    { 2, "S", "Camiseta Reciclada", "Camiseta", 50, 50, new DateTime(2025, 5, 19, 16, 21, 16, 837, DateTimeKind.Local).AddTicks(3061), 200 }
                });

            migrationBuilder.InsertData(
                table: "TB_COLETA",
                columns: new[] { "IdColeta", "CodigoEcoponto", "CodigoUtilizador", "DataColeta", "IdEcoponto", "IdUtilizador", "Peso", "SituacaoColeta", "TotalEcopoints" },
                values: new object[,]
                {
                    { 1, 1001, 2001, new DateTime(2024, 5, 19, 16, 21, 16, 837, DateTimeKind.Local).AddTicks(2989), 1, 1, 15.5, "Completa", 50f },
                    { 2, 1002, 2002, new DateTime(2024, 5, 19, 16, 21, 16, 837, DateTimeKind.Local).AddTicks(3006), 2, 2, 20.0, "Pendente", 75f }
                });

            migrationBuilder.InsertData(
                table: "TB_ECOPOINTS",
                columns: new[] { "IdMaterial", "EcoPointsTotais", "OrdemGrandeza", "Quantidade" },
                values: new object[,]
                {
                    { 1, 100, "A", 10 },
                    { 2, 200, "B", 20 }
                });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "ecoponto1@example.com", new byte[] { 250, 87, 23, 103, 224, 42, 127, 2, 17, 234, 86, 171, 154, 37, 182, 19, 217, 63, 113, 36, 179, 153, 81, 186, 108, 96, 37, 103, 152, 218, 240, 133, 50, 175, 103, 37, 85, 64, 53, 215, 182, 155, 77, 213, 22, 19, 207, 236, 169, 99, 75, 103, 28, 1, 28, 38, 122, 30, 174, 9, 115, 22, 97, 89 }, new byte[] { 74, 191, 138, 25, 203, 74, 81, 109, 240, 141, 34, 179, 53, 11, 55, 107, 202, 186, 190, 232, 110, 0, 210, 56, 252, 51, 24, 25, 33, 158, 126, 234, 30, 45, 191, 141, 121, 31, 253, 167, 216, 165, 9, 65, 64, 213, 8, 98, 35, 159, 147, 71, 29, 89, 122, 9, 36, 183, 106, 137, 93, 22, 182, 113, 129, 247, 250, 149, 159, 83, 107, 100, 178, 193, 152, 52, 190, 120, 221, 232, 246, 73, 101, 66, 182, 32, 45, 135, 42, 154, 238, 212, 255, 145, 136, 109, 95, 195, 30, 168, 47, 141, 126, 205, 164, 243, 116, 48, 190, 207, 6, 128, 43, 33, 35, 223, 186, 180, 40, 251, 225, 160, 24, 66, 186, 105, 110, 192 }, "Ecoponto1" });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "ecoponto2@example.com", new byte[] { 250, 87, 23, 103, 224, 42, 127, 2, 17, 234, 86, 171, 154, 37, 182, 19, 217, 63, 113, 36, 179, 153, 81, 186, 108, 96, 37, 103, 152, 218, 240, 133, 50, 175, 103, 37, 85, 64, 53, 215, 182, 155, 77, 213, 22, 19, 207, 236, 169, 99, 75, 103, 28, 1, 28, 38, 122, 30, 174, 9, 115, 22, 97, 89 }, new byte[] { 74, 191, 138, 25, 203, 74, 81, 109, 240, 141, 34, 179, 53, 11, 55, 107, 202, 186, 190, 232, 110, 0, 210, 56, 252, 51, 24, 25, 33, 158, 126, 234, 30, 45, 191, 141, 121, 31, 253, 167, 216, 165, 9, 65, 64, 213, 8, 98, 35, 159, 147, 71, 29, 89, 122, 9, 36, 183, 106, 137, 93, 22, 182, 113, 129, 247, 250, 149, 159, 83, 107, 100, 178, 193, 152, 52, 190, 120, 221, 232, 246, 73, 101, 66, 182, 32, 45, 135, 42, 154, 238, 212, 255, 145, 136, 109, 95, 195, 30, 168, 47, 141, 126, 205, 164, 243, 116, 48, 190, 207, 6, 128, 43, 33, 35, 223, 186, 180, 40, 251, 225, 160, 24, 66, 186, 105, 110, 192 }, "Ecoponto2" });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 1,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { null, new byte[] { 250, 87, 23, 103, 224, 42, 127, 2, 17, 234, 86, 171, 154, 37, 182, 19, 217, 63, 113, 36, 179, 153, 81, 186, 108, 96, 37, 103, 152, 218, 240, 133, 50, 175, 103, 37, 85, 64, 53, 215, 182, 155, 77, 213, 22, 19, 207, 236, 169, 99, 75, 103, 28, 1, 28, 38, 122, 30, 174, 9, 115, 22, 97, 89 }, new byte[] { 74, 191, 138, 25, 203, 74, 81, 109, 240, 141, 34, 179, 53, 11, 55, 107, 202, 186, 190, 232, 110, 0, 210, 56, 252, 51, 24, 25, 33, 158, 126, 234, 30, 45, 191, 141, 121, 31, 253, 167, 216, 165, 9, 65, 64, 213, 8, 98, 35, 159, 147, 71, 29, 89, 122, 9, 36, 183, 106, 137, 93, 22, 182, 113, 129, 247, 250, 149, 159, 83, 107, 100, 178, 193, 152, 52, 190, 120, 221, 232, 246, 73, 101, 66, 182, 32, 45, 135, 42, 154, 238, 212, 255, 145, 136, 109, 95, 195, 30, 168, 47, 141, 126, 205, 164, 243, 116, 48, 190, 207, 6, 128, 43, 33, 35, 223, 186, 180, 40, 251, 225, 160, 24, 66, 186, 105, 110, 192 }, "UsuarioJoao" });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 2,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { null, new byte[] { 250, 87, 23, 103, 224, 42, 127, 2, 17, 234, 86, 171, 154, 37, 182, 19, 217, 63, 113, 36, 179, 153, 81, 186, 108, 96, 37, 103, 152, 218, 240, 133, 50, 175, 103, 37, 85, 64, 53, 215, 182, 155, 77, 213, 22, 19, 207, 236, 169, 99, 75, 103, 28, 1, 28, 38, 122, 30, 174, 9, 115, 22, 97, 89 }, new byte[] { 74, 191, 138, 25, 203, 74, 81, 109, 240, 141, 34, 179, 53, 11, 55, 107, 202, 186, 190, 232, 110, 0, 210, 56, 252, 51, 24, 25, 33, 158, 126, 234, 30, 45, 191, 141, 121, 31, 253, 167, 216, 165, 9, 65, 64, 213, 8, 98, 35, 159, 147, 71, 29, 89, 122, 9, 36, 183, 106, 137, 93, 22, 182, 113, 129, 247, 250, 149, 159, 83, 107, 100, 178, 193, 152, 52, 190, 120, 221, 232, 246, 73, 101, 66, 182, 32, 45, 135, 42, 154, 238, 212, 255, 145, 136, 109, 95, 195, 30, 168, 47, 141, 126, 205, 164, 243, 116, 48, 190, 207, 6, 128, 43, 33, 35, 223, 186, 180, 40, 251, 225, 160, 24, 66, 186, 105, 110, 192 }, "UsuarioMaria" });

            migrationBuilder.InsertData(
                table: "TB_UTILIZADOR",
                columns: new[] { "IdUtilizador", "DataAcesso", "Email", "Nome", "PasswordHash", "PasswordSalt", "SituacaoEmail", "Username" },
                values: new object[] { 3, new DateTime(2024, 5, 19, 16, 21, 16, 837, DateTimeKind.Local).AddTicks(3072), "admin@example.com", "Admin", new byte[] { 250, 87, 23, 103, 224, 42, 127, 2, 17, 234, 86, 171, 154, 37, 182, 19, 217, 63, 113, 36, 179, 153, 81, 186, 108, 96, 37, 103, 152, 218, 240, 133, 50, 175, 103, 37, 85, 64, 53, 215, 182, 155, 77, 213, 22, 19, 207, 236, 169, 99, 75, 103, 28, 1, 28, 38, 122, 30, 174, 9, 115, 22, 97, 89 }, new byte[] { 74, 191, 138, 25, 203, 74, 81, 109, 240, 141, 34, 179, 53, 11, 55, 107, 202, 186, 190, 232, 110, 0, 210, 56, 252, 51, 24, 25, 33, 158, 126, 234, 30, 45, 191, 141, 121, 31, 253, 167, 216, 165, 9, 65, 64, 213, 8, 98, 35, 159, 147, 71, 29, 89, 122, 9, 36, 183, 106, 137, 93, 22, 182, 113, 129, 247, 250, 149, 159, 83, 107, 100, 178, 193, 152, 52, 190, 120, 221, 232, 246, 73, 101, 66, 182, 32, 45, 135, 42, 154, 238, 212, 255, 145, 136, 109, 95, 195, 30, 168, 47, 141, 126, 205, 164, 243, 116, 48, 190, 207, 6, 128, 43, 33, 35, 223, 186, 180, 40, 251, 225, 160, 24, 66, 186, 105, 110, 192 }, true, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DataAcesso",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TB_ECOPONTO");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TB_ECOPONTO");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TB_ECOPONTO");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TB_ECOPONTO");

            migrationBuilder.RenameColumn(
                name: "CodigoUtilizador",
                table: "TB_COLETA",
                newName: "CodigoUltilizador");
        }
    }
}
