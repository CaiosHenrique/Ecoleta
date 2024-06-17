using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMetodos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_UTILIZADOR_TB_ECOPOINTS_TotalEcoPoints",
                table: "TB_UTILIZADOR");

            migrationBuilder.DropTable(
                name: "TB_ECOPOINTS");

            migrationBuilder.DropIndex(
                name: "IX_TB_UTILIZADOR_TotalEcoPoints",
                table: "TB_UTILIZADOR");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "TB_ECOPONTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 1,
                column: "Validade",
                value: new DateTime(2025, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "TB_BRINDE",
                keyColumn: "IdBrinde",
                keyValue: 2,
                column: "Validade",
                value: new DateTime(2025, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "DataColeta",
                value: new DateTime(2024, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "TB_COLETA",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "DataColeta",
                value: new DateTime(2024, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "Numero", "PasswordHash", "PasswordSalt" },
                values: new object[] { 3149, new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 }, new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 } });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "Numero", "PasswordHash", "PasswordSalt" },
                values: new object[] { 319, new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 }, new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 }, new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 }, new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 3,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 6, 16, 21, 58, 35, 30, DateTimeKind.Local).AddTicks(3866), new byte[] { 162, 230, 189, 225, 126, 211, 19, 244, 144, 154, 84, 249, 14, 203, 180, 88, 106, 53, 153, 91, 90, 249, 111, 3, 238, 210, 69, 18, 176, 128, 210, 67, 244, 216, 144, 29, 6, 242, 155, 214, 187, 154, 202, 116, 180, 156, 193, 71, 75, 178, 79, 12, 218, 216, 157, 240, 221, 33, 151, 201, 31, 121, 178, 88 }, new byte[] { 38, 105, 195, 81, 216, 5, 0, 22, 146, 35, 219, 67, 45, 116, 137, 9, 80, 197, 211, 104, 98, 252, 126, 143, 198, 189, 207, 154, 234, 153, 141, 134, 241, 87, 76, 125, 21, 7, 49, 125, 173, 144, 49, 141, 235, 248, 179, 55, 13, 211, 200, 178, 204, 186, 92, 70, 150, 175, 24, 17, 248, 108, 33, 40, 238, 205, 50, 204, 87, 139, 18, 46, 106, 238, 62, 3, 232, 2, 78, 44, 150, 36, 63, 148, 254, 7, 249, 15, 28, 163, 199, 27, 27, 52, 32, 251, 224, 38, 74, 155, 64, 185, 192, 193, 194, 32, 73, 175, 151, 150, 159, 200, 168, 169, 6, 193, 157, 91, 81, 179, 90, 240, 251, 175, 6, 135, 215, 53 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "TB_ECOPONTO");

            migrationBuilder.CreateTable(
                name: "TB_ECOPOINTS",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilizador = table.Column<int>(type: "int", nullable: false),
                    OrdemGrandeza = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    TotalEcoPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ECOPOINTS", x => x.IdMaterial);
                });

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

            migrationBuilder.InsertData(
                table: "TB_ECOPOINTS",
                columns: new[] { "IdMaterial", "IdUtilizador", "OrdemGrandeza", "Quantidade", "TotalEcoPoints" },
                values: new object[,]
                {
                    { 1, 1, "A", 10, 0 },
                    { 2, 2, "B", 20, 0 }
                });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.UpdateData(
                table: "TB_ECOPONTO",
                keyColumn: "IdEcoponto",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

            migrationBuilder.UpdateData(
                table: "TB_UTILIZADOR",
                keyColumn: "IdUtilizador",
                keyValue: 3,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 6, 13, 15, 28, 27, 403, DateTimeKind.Local).AddTicks(9231), new byte[] { 173, 43, 174, 141, 219, 146, 59, 146, 26, 217, 58, 253, 53, 180, 79, 59, 26, 145, 209, 166, 57, 195, 226, 75, 43, 115, 102, 217, 21, 8, 121, 103, 196, 187, 162, 57, 56, 213, 111, 88, 109, 226, 124, 231, 137, 108, 212, 36, 222, 118, 172, 65, 68, 47, 34, 172, 241, 164, 18, 155, 118, 178, 11, 82 }, new byte[] { 117, 43, 242, 236, 225, 127, 114, 99, 253, 9, 43, 4, 79, 234, 20, 102, 136, 162, 31, 75, 36, 170, 125, 0, 209, 205, 66, 66, 21, 170, 98, 15, 152, 15, 50, 129, 90, 100, 4, 4, 232, 236, 21, 253, 232, 122, 146, 199, 49, 9, 103, 195, 222, 23, 67, 98, 231, 96, 2, 33, 179, 4, 130, 230, 91, 123, 233, 28, 118, 60, 98, 150, 124, 85, 86, 91, 122, 66, 242, 201, 181, 194, 217, 157, 74, 232, 112, 110, 1, 207, 68, 209, 33, 64, 1, 242, 202, 245, 83, 66, 237, 33, 165, 113, 67, 79, 127, 167, 253, 186, 85, 67, 7, 80, 188, 88, 24, 89, 144, 11, 68, 252, 151, 75, 10, 47, 14, 94 } });

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
    }
}
