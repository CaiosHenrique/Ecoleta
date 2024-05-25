using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoUtilizadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EcoPointsTotais",
                table: "TB_ECOPOINTS",
                newName: "UtilizadorId");

            migrationBuilder.AddColumn<int>(
                name: "TotalEcoPoints",
                table: "TB_UTILIZADOR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalEcoPoints",
                table: "TB_ECOPOINTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 1,
                column: "Validade",
                value: new DateTime(2025, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 2,
                column: "Validade",
                value: new DateTime(2025, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "DataColeta",
                value: new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "DataColeta",
                value: new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 1,
                columns: new[] { "TotalEcoPoints", "UtilizadorId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 2,
                columns: new[] { "TotalEcoPoints", "UtilizadorId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 } });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "TotalEcoPoints" },
                values: new object[] { new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 }, 0 });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt", "TotalEcoPoints" },
                values: new object[] { new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 }, 0 });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 3,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt", "TotalEcoPoints" },
                values: new object[] { new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9249), new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 }, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ECOPOINTS_UtilizadorId",
                table: "TB_ECOPOINTS",
                column: "UtilizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ECOPOINTS_TB_UTILIZADOR_UtilizadorId",
                table: "TB_ECOPOINTS",
                column: "UtilizadorId",
                principalTable: "TB_UTILIZADOR",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ECOPOINTS_TB_UTILIZADOR_UtilizadorId",
                table: "TB_ECOPOINTS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ECOPOINTS_UtilizadorId",
                table: "TB_ECOPOINTS");

            migrationBuilder.DropColumn(
                name: "TotalEcoPoints",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "TotalEcoPoints",
                table: "TB_ECOPOINTS");

            migrationBuilder.RenameColumn(
                name: "UtilizadorId",
                table: "TB_ECOPOINTS",
                newName: "EcoPointsTotais");

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 1,
                column: "Validade",
                value: new DateTime(2025, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 2,
                column: "Validade",
                value: new DateTime(2025, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "DataColeta",
                value: new DateTime(2024, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "DataColeta",
                value: new DateTime(2024, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 1,
                column: "EcoPointsTotais",
                value: 100);

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 2,
                column: "EcoPointsTotais",
                value: 200);

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 }, new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 } });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 }, new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 }, new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 }, new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 3,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 5, 19, 16, 51, 58, 950, DateTimeKind.Local).AddTicks(1560), new byte[] { 76, 186, 42, 249, 136, 181, 59, 114, 197, 125, 60, 115, 236, 181, 77, 246, 135, 212, 57, 42, 70, 163, 249, 202, 74, 117, 94, 101, 248, 141, 32, 18, 128, 75, 186, 247, 125, 148, 254, 83, 64, 107, 211, 199, 144, 166, 190, 96, 140, 231, 6, 10, 142, 239, 78, 42, 51, 245, 11, 177, 131, 103, 110, 56 }, new byte[] { 161, 51, 60, 69, 93, 193, 130, 236, 192, 161, 179, 72, 215, 217, 104, 180, 162, 250, 90, 33, 118, 124, 207, 212, 182, 103, 122, 125, 233, 143, 18, 213, 149, 78, 241, 103, 126, 201, 29, 175, 59, 95, 100, 142, 245, 86, 14, 116, 254, 239, 186, 121, 194, 98, 19, 20, 75, 11, 57, 249, 25, 62, 232, 1, 246, 84, 116, 5, 254, 241, 26, 4, 96, 211, 109, 91, 242, 27, 187, 97, 80, 151, 45, 78, 203, 231, 154, 209, 43, 154, 217, 147, 8, 239, 86, 2, 121, 176, 194, 196, 4, 242, 21, 119, 254, 105, 35, 72, 12, 70, 107, 185, 190, 168, 156, 50, 156, 37, 207, 222, 56, 248, 166, 16, 221, 72, 83, 158 } });
        }
    }
}
