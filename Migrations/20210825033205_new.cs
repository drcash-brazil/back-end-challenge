using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_challenge.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Category_GeneroId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GeneroId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "GenerosId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenerosId",
                table: "Books",
                column: "GenerosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Category_GenerosId",
                table: "Books",
                column: "GenerosId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Category_GenerosId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenerosId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenerosId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GeneroId",
                table: "Books",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Category_GeneroId",
                table: "Books",
                column: "GeneroId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
