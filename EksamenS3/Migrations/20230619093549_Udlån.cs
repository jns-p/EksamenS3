using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksamenS3.Migrations
{
    /// <inheritdoc />
    public partial class Udlån : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Udlånere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    LånerId = table.Column<int>(type: "int", nullable: false),
                    BogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udlånere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Udlånere_Bøger_BogId",
                        column: x => x.BogId,
                        principalTable: "Bøger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Udlånere_Lånere_LånerId",
                        column: x => x.LånerId,
                        principalTable: "Lånere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Udlånere_BogId",
                table: "Udlånere",
                column: "BogId");

            migrationBuilder.CreateIndex(
                name: "IX_Udlånere_LånerId",
                table: "Udlånere",
                column: "LånerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Udlånere");
        }
    }
}
