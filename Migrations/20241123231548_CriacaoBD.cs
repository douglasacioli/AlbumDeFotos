using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbumDeFotos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotoTopo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.AlbumID);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    ImagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.ImagemId);
                    table.ForeignKey(
                        name: "FK_Imagens_Albuns_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albuns",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_AlbumID",
                table: "Imagens",
                column: "AlbumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Albuns");
        }
    }
}
