using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "generous",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generous", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    username = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    role = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    title = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    authorId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    genreId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    quantity = table.Column<long>(type: "BIGINT", nullable: false),
                    price = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_books_authors_authorId",
                        column: x => x.authorId,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_generous_genreId",
                        column: x => x.genreId,
                        principalTable: "generous",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movement",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    value = table.Column<double>(type: "FLOAT", nullable: false),
                    quantity = table.Column<long>(type: "BIGINT", nullable: false),
                    bookId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    operation = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    dateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movement", x => x.id);
                    table.ForeignKey(
                        name: "FK_movement_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderBooks",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    bookId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValue: "In process"),
                    orderDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    orderQuantity = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderBooks", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderBooks_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_authorId",
                table: "books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_genreId",
                table: "books",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_movement_bookId",
                table: "movement",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_orderBooks_bookId",
                table: "orderBooks",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movement");

            migrationBuilder.DropTable(
                name: "orderBooks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "generous");
        }
    }
}
