using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halhatatlanok.Migrations
{
    /// <inheritdoc />
    public partial class javit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tagok_Kategoriak_KatidId",
                table: "Tagok");

            migrationBuilder.RenameColumn(
                name: "KatidId",
                table: "Tagok",
                newName: "KategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tagok_KatidId",
                table: "Tagok",
                newName: "IX_Tagok_KategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tagok_Kategoriak_KategoriaId",
                table: "Tagok",
                column: "KategoriaId",
                principalTable: "Kategoriak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tagok_Kategoriak_KategoriaId",
                table: "Tagok");

            migrationBuilder.RenameColumn(
                name: "KategoriaId",
                table: "Tagok",
                newName: "KatidId");

            migrationBuilder.RenameIndex(
                name: "IX_Tagok_KategoriaId",
                table: "Tagok",
                newName: "IX_Tagok_KatidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tagok_Kategoriak_KatidId",
                table: "Tagok",
                column: "KatidId",
                principalTable: "Kategoriak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
