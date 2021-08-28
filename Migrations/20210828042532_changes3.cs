using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_challenge.Migrations
{
    public partial class changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1635c3a8-0fc8-4a99-82bd-2481fad8a548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55cd99fe-bbb6-44d5-bd65-6b6c307821ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9911d88-60f3-490e-8eda-355204b5402e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4846bcf0-ef8a-4135-88c5-f45145e58a0e", "97581640-fdc8-44b5-97c7-ee5896c61f87", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4af2e299-2373-4b5f-93b7-c3786a4c8307", "3e1cdce6-f30b-4d38-ba31-d748f6b59778", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bcbefa32-4c74-4e3d-9b11-0553ef03275a", "890734d4-b6d3-47c7-b2be-31b1fb654c0f", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4846bcf0-ef8a-4135-88c5-f45145e58a0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4af2e299-2373-4b5f-93b7-c3786a4c8307");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcbefa32-4c74-4e3d-9b11-0553ef03275a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9911d88-60f3-490e-8eda-355204b5402e", "fe3ce273-e11f-474c-8fc3-6ef63bd828b5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1635c3a8-0fc8-4a99-82bd-2481fad8a548", "36d94d2c-e925-424d-a13b-e35f61abcb93", "Admin", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55cd99fe-bbb6-44d5-bd65-6b6c307821ec", "f5b7e1ac-20d8-4237-b14b-e6778bac3a96", "Employee", "EMPLOYEE" });
        }
    }
}
