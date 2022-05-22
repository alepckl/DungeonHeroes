using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class heroUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hero_HeroId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HeroId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "AspNetUsers",
                newName: "HeroForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HeroForeignKey",
                table: "AspNetUsers",
                column: "HeroForeignKey",
                unique: true,
                filter: "[HeroForeignKey] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hero_HeroForeignKey",
                table: "AspNetUsers",
                column: "HeroForeignKey",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hero_HeroForeignKey",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HeroForeignKey",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HeroForeignKey",
                table: "AspNetUsers",
                newName: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HeroId",
                table: "AspNetUsers",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hero_HeroId",
                table: "AspNetUsers",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
