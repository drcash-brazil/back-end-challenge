using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_challenge.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Category_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Category_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "GeneroId");

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
    }
}
