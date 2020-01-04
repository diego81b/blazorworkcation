using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Infrastructure.Migrations
{
    public partial class AddUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "438B1BE9-79AD-4F56-8249-55380AF05BDC", "cefa1d46-c4dc-4f51-8d9b-f9483bde382f", "ADMIN", "ADMIN" },
                    { "E5C52454-11F9-4486-BF9F-9A841C76BC77", "52b5edfd-e2b1-499e-82fa-879d0b493315", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6B6C81F4-19FD-4D2F-BC5F-052BF87FE152", 0, "9cf3864a-288c-4753-bf91-775869c8b1ae", "baldeschidiego@gmail.com", true, "Diego", "Baldeschi", false, null, null, null, "AQAAAAEAACcQAAAAEDmb7GZEEfOd/8wDCgIBT6vgbOS3+WnIfVBIYI8QmJ2rpwQzx2gSD4V8bovC+S5cGA==", null, false, "c2df12a7-8c34-4191-8d9e-c2367b6d8d41", false, "diego.baldeschi" },
                    { "9ADF9CD9-858A-47B6-8399-E3D09B790D1F", 0, "c520049c-e027-4724-a19d-cad643467178", "admin@mail.com", true, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEBa4UwdHG60ClC8V99YbSvdAM4UsRuPrwZnnE5PN9RYutmD8TXXK6x8t8P8bnEs9gg==", null, false, "aafdfdf7-4edb-41b6-9200-c2c2e960ea69", false, "administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[] { "6B6C81F4-19FD-4D2F-BC5F-052BF87FE152", "E5C52454-11F9-4486-BF9F-9A841C76BC77", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[] { "9ADF9CD9-858A-47B6-8399-E3D09B790D1F", "438B1BE9-79AD-4F56-8249-55380AF05BDC", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6B6C81F4-19FD-4D2F-BC5F-052BF87FE152", "E5C52454-11F9-4486-BF9F-9A841C76BC77" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9ADF9CD9-858A-47B6-8399-E3D09B790D1F", "438B1BE9-79AD-4F56-8249-55380AF05BDC" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438B1BE9-79AD-4F56-8249-55380AF05BDC");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "E5C52454-11F9-4486-BF9F-9A841C76BC77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6B6C81F4-19FD-4D2F-BC5F-052BF87FE152");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ADF9CD9-858A-47B6-8399-E3D09B790D1F");
        }
    }
}
