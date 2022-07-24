using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 72, 214, 98, 45, 234, 64, 171, 110, 171, 77, 191, 86, 163, 213, 152, 141, 67, 2, 9, 157, 219, 175, 106, 246, 82, 41, 74, 236, 232, 11, 220, 240, 99, 245, 87, 127, 78, 198, 51, 12, 247, 154, 38, 182, 219, 178, 4, 136, 219, 146, 244, 211, 176, 196, 0, 139, 80, 134, 166, 181, 81, 36, 223, 90 }, new byte[] { 66, 185, 80, 66, 29, 113, 225, 216, 251, 236, 221, 228, 159, 254, 35, 90, 21, 37, 183, 156, 103, 145, 224, 70, 118, 130, 50, 53, 32, 94, 87, 0, 133, 181, 14, 52, 218, 209, 98, 183, 189, 237, 249, 154, 139, 146, 32, 84, 200, 132, 59, 34, 30, 254, 250, 95, 206, 58, 96, 159, 52, 44, 106, 50, 66, 220, 73, 113, 239, 112, 104, 240, 210, 117, 210, 169, 109, 57, 195, 222, 45, 71, 104, 30, 59, 185, 195, 236, 163, 131, 42, 49, 94, 11, 85, 3, 230, 224, 94, 65, 81, 160, 56, 14, 59, 115, 153, 52, 189, 150, 252, 38, 160, 152, 29, 139, 7, 196, 230, 178, 41, 44, 95, 64, 84, 145, 163, 199 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 220, 149, 29, 195, 169, 103, 33, 247, 157, 222, 254, 197, 158, 211, 132, 71, 37, 16, 232, 129, 51, 77, 61, 178, 76, 136, 181, 132, 222, 193, 230, 252, 198, 170, 8, 184, 147, 91, 86, 75, 195, 35, 212, 50, 168, 28, 109, 173, 202, 82, 121, 7, 92, 59, 122, 211, 15, 33, 56, 132, 48, 64, 114, 239 }, new byte[] { 251, 163, 36, 238, 210, 186, 11, 186, 74, 23, 250, 90, 132, 114, 157, 226, 112, 187, 42, 63, 18, 195, 142, 207, 142, 236, 155, 24, 135, 29, 234, 12, 241, 233, 160, 133, 150, 200, 202, 16, 91, 26, 57, 187, 140, 58, 119, 1, 232, 225, 166, 104, 60, 44, 227, 101, 113, 223, 27, 225, 95, 153, 10, 215, 164, 87, 250, 3, 150, 114, 5, 69, 172, 212, 47, 48, 120, 76, 138, 247, 49, 112, 51, 196, 71, 42, 224, 36, 184, 136, 24, 165, 225, 98, 54, 199, 88, 8, 128, 226, 8, 18, 207, 149, 77, 208, 153, 135, 192, 151, 149, 163, 6, 101, 142, 147, 198, 20, 117, 184, 247, 65, 15, 180, 103, 193, 189, 132 } });
        }
    }
}
