using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreCrudWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_autores",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "newId()"),
                    nome_autor = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_generos",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "newId()"),
                    genero = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_livros",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "newId()"),
                    titulo = table.Column<string>(type: "varchar(150)", nullable: false),
                    quantidade_copias = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_livros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_genero_livros",
                columns: table => new
                {
                    livro_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    genero_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genero_livros", x => new { x.livro_id, x.genero_id });
                    table.ForeignKey(
                        name: "FK_tb_genero_livros_tb_generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "tb_generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_genero_livros_tb_livros_livro_id",
                        column: x => x.livro_id,
                        principalTable: "tb_livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_livros_autores",
                columns: table => new
                {
                    livro_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    autor_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_livros_autores", x => new { x.livro_id, x.autor_id });
                    table.ForeignKey(
                        name: "FK_tb_livros_autores_tb_autores_autor_id",
                        column: x => x.autor_id,
                        principalTable: "tb_autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_livros_autores_tb_livros_livro_id",
                        column: x => x.livro_id,
                        principalTable: "tb_livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_genero_livros_genero_id",
                table: "tb_genero_livros",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_livros_autores_autor_id",
                table: "tb_livros_autores",
                column: "autor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_genero_livros");

            migrationBuilder.DropTable(
                name: "tb_livros_autores");

            migrationBuilder.DropTable(
                name: "tb_generos");

            migrationBuilder.DropTable(
                name: "tb_autores");

            migrationBuilder.DropTable(
                name: "tb_livros");
        }
    }
}
