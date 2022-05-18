using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tanulok_proba.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diakok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diakok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanarok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanarok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TanarDiak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiakId = table.Column<int>(type: "int", nullable: false),
                    TanarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TanarDiak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TanarDiak_Diakok_DiakId",
                        column: x => x.DiakId,
                        principalTable: "Diakok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TanarDiak_Tanarok_TanarId",
                        column: x => x.TanarId,
                        principalTable: "Tanarok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TanarDiak_DiakId",
                table: "TanarDiak",
                column: "DiakId");

            migrationBuilder.CreateIndex(
                name: "IX_TanarDiak_TanarId",
                table: "TanarDiak",
                column: "TanarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TanarDiak");

            migrationBuilder.DropTable(
                name: "Diakok");

            migrationBuilder.DropTable(
                name: "Tanarok");
        }
    }
}
