using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_challenge.Migrations
{
    public partial class Models1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellBooks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98804ef9-e39e-409a-b62d-0bc3ad02ff06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67ca6b0-23d0-4d8a-ba55-7b3303a05fcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ecc148-bd9c-4dbd-b654-ea90a3bfc36f");

            migrationBuilder.CreateTable(
                name: "BookSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantityToReduce = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSales_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d647fce2-ac56-408c-b1e7-348048f5c9db", "54cebbc4-da64-48a7-8e5b-bc873ef22f3c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fbd8c36-2967-47df-a7c7-9beef1fe0bc5", "a13123f1-1d95-4c39-8296-ed72b85bc38e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a62c5a06-a26a-4393-89d6-499c6613e778", "5c0cf121-e15e-40bf-96d0-9464052917a5", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_BookSales_BookId",
                table: "BookSales",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSales");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fbd8c36-2967-47df-a7c7-9beef1fe0bc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a62c5a06-a26a-4393-89d6-499c6613e778");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d647fce2-ac56-408c-b1e7-348048f5c9db");

            migrationBuilder.CreateTable(
                name: "SellBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantityToReduce = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7ecc148-bd9c-4dbd-b654-ea90a3bfc36f", "bc3eefe6-f0e8-4687-b641-704318b1a4e8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98804ef9-e39e-409a-b62d-0bc3ad02ff06", "8388f379-10e6-40a1-bcf6-b5d41f62bdbb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d67ca6b0-23d0-4d8a-ba55-7b3303a05fcf", "d1c222d7-aa76-4929-9ed5-e1f20fcfbda3", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_SellBooks_BookId",
                table: "SellBooks",
                column: "BookId");
        }
    }
}
