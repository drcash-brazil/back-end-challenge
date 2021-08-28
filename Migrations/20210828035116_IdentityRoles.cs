using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_challenge.Migrations
{
    public partial class IdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a1714ab-08d1-499f-b006-2b37ce635142", "e0d85b6d-c6e7-4d6d-865b-3a00756c4e8d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ce74ef8-0ad5-4953-bfe8-ddefe9586e39", "89c4192e-afe6-4e4b-9aa9-5b07644212cc", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b54133ad-38a1-4bc3-855b-2cc6b33e2df8", "82da42e2-38a6-4ddc-863a-d3c3e3993733", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1714ab-08d1-499f-b006-2b37ce635142");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ce74ef8-0ad5-4953-bfe8-ddefe9586e39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54133ad-38a1-4bc3-855b-2cc6b33e2df8");
        }
    }
}
