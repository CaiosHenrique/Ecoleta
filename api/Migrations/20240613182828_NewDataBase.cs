using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class NewDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ECOPOINTS_TB_UTILIZADOR_UtilizadorId",
                table: "TB_ECOPOINTS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ECOPOINTS_UtilizadorId",
                table: "TB_ECOPOINTS");

            migrationBuilder.RenameColumn(
                name: "UtilizadorId",
                table: "TB_ECOPOINTS",
                newName: "IdUtilizador");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TB_UTILIZADOR",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TB_UTILIZADOR",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "TB_ECOPONTO",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "TB_ECOPONTO",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 1,
                column: "Validade",
                value: new DateTime(2025, 6, 13, 15, 28, 27, 403, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 2,
                column: "Validade",
                value: new DateTime(2025, 6, 13, 15, 28, 27, 403, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "DataColeta",
                value: new DateTime(2024, 6, 13, 15, 28, 27, 403, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "DataColeta",
                value: new DateTime(2024, 6, 13, 15, 28, 27, 403, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 1,
                column: "IdUtilizador",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 2,
                column: "IdUtilizador",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { 192.0, 193.0, new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { 192.0, 193.0, new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "TotalEcoPoints" },
                values: new object[] { 0.0, 0.0, new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 }, 100 });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "TotalEcoPoints" },
                values: new object[] { 0.0, 0.0, new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 }, 100 });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 3,
                columns: new[] { "DataAcesso", "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 6, 13, 15, 28, 27, 403, DateTimeKind.Local).AddTicks(9231), 0.0, 0.0, new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_UTILIZADOR_TotalEcoPoints",
                table: "TB_UTILIZADOR",
                column: "TotalEcoPoints",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_UTILIZADOR_TB_ECOPOINTS_TotalEcoPoints",
                table: "TB_UTILIZADOR",
                column: "TotalEcoPoints",
                principalTable: "TB_ECOPOINTS",
                principalColumn: "IdMaterial",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_UTILIZADOR_TB_ECOPOINTS_TotalEcoPoints",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropIndex(
                name: "IX_TB_UTILIZADOR_TotalEcoPoints",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TB_UTILIZADOR");

            migrationBuilder.RenameColumn(
                name: "IdUtilizador",
                table: "TB_ECOPOINTS",
                newName: "UtilizadorId");

            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "TB_ECOPONTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "TB_ECOPONTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

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
                column: "UtilizadorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TB_ECOPOINTS",
                keyColumn: "IdMaterial",
                keyValue: 2,
                column: "UtilizadorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { 192, 193, new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 } });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { 192, 193, new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 } });

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
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 5, 25, 14, 35, 5, 11, DateTimeKind.Local).AddTicks(9249), new byte[] { 217, 179, 29, 140, 47, 63, 102, 128, 27, 26, 192, 11, 196, 26, 117, 237, 84, 89, 241, 122, 37, 0, 171, 19, 8, 93, 199, 89, 104, 212, 51, 71, 36, 53, 191, 159, 78, 67, 152, 168, 24, 13, 47, 220, 74, 238, 76, 189, 90, 6, 13, 86, 164, 46, 142, 241, 241, 202, 169, 6, 43, 112, 41, 35 }, new byte[] { 220, 8, 165, 88, 86, 202, 83, 155, 235, 91, 25, 120, 122, 251, 109, 59, 177, 2, 11, 17, 229, 197, 188, 126, 127, 241, 7, 35, 98, 69, 57, 90, 33, 129, 76, 26, 180, 174, 51, 79, 152, 238, 64, 193, 33, 8, 229, 185, 204, 8, 239, 181, 88, 165, 53, 109, 120, 50, 160, 64, 104, 130, 143, 81, 233, 187, 122, 252, 132, 26, 91, 170, 247, 93, 174, 45, 80, 7, 157, 128, 234, 115, 54, 115, 55, 142, 59, 215, 217, 122, 154, 245, 151, 62, 129, 57, 147, 129, 60, 103, 81, 211, 228, 58, 3, 239, 80, 144, 210, 90, 7, 18, 27, 86, 36, 139, 206, 75, 17, 181, 139, 226, 3, 15, 226, 127, 40, 14 } });

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
    }
}
