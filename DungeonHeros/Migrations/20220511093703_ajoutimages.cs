using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class ajoutimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isForUser",
                table: "Races",
                newName: "IsForUser");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 4,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 5,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 6,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 7,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 8,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 9,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 10,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 11,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 12,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 13,
                column: "ImagePath",
                value: "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsForUser",
                table: "Races",
                newName: "isForUser");
        }
    }
}
