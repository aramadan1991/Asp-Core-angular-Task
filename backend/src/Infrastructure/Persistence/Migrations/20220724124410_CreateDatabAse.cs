using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CreateDatabAse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("43db034a-98cc-42ee-8fff-c57016484f4d"), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmailConfirmationCode", "EmailConfirmed", "EmailConfirmedCode", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "ResetPasswordCode", "UserName" },
                values: new object[] { new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "defaultadmin@gmail.com", null, true, null, "Default", "Admin", new byte[] { 220, 149, 29, 195, 169, 103, 33, 247, 157, 222, 254, 197, 158, 211, 132, 71, 37, 16, 232, 129, 51, 77, 61, 178, 76, 136, 181, 132, 222, 193, 230, 252, 198, 170, 8, 184, 147, 91, 86, 75, 195, 35, 212, 50, 168, 28, 109, 173, 202, 82, 121, 7, 92, 59, 122, 211, 15, 33, 56, 132, 48, 64, 114, 239 }, new byte[] { 251, 163, 36, 238, 210, 186, 11, 186, 74, 23, 250, 90, 132, 114, 157, 226, 112, 187, 42, 63, 18, 195, 142, 207, 142, 236, 155, 24, 135, 29, 234, 12, 241, 233, 160, 133, 150, 200, 202, 16, 91, 26, 57, 187, 140, 58, 119, 1, 232, 225, 166, 104, 60, 44, 227, 101, 113, 223, 27, 225, 95, 153, 10, 215, 164, 87, 250, 3, 150, 114, 5, 69, 172, 212, 47, 48, 120, 76, 138, 247, 49, 112, 51, 196, 71, 42, 224, 36, 184, 136, 24, 165, 225, 98, 54, 199, 88, 8, 128, 226, 8, 18, 207, 149, 77, 208, 153, 135, 192, 151, 149, 163, 6, 101, 142, 147, 198, 20, 117, 184, 247, 65, 15, 180, 103, 193, 189, 132 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("43db034a-98cc-42ee-8fff-c57016484f4d"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
