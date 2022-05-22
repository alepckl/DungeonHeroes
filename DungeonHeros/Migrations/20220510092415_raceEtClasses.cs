using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class raceEtClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "Classe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Race",
                table: "Monsters",
                newName: "RaceId");

            migrationBuilder.AddColumn<int>(
                name: "ClasseClassId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName" },
                values: new object[] { 1, "Magician" });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "RaceId", "Name" },
                values: new object[] { 1, "Human" });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_RaceId",
                table: "Monsters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClasseClassId",
                table: "AspNetUsers",
                column: "ClasseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RaceId",
                table: "AspNetUsers",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_ClasseClassId",
                table: "AspNetUsers",
                column: "ClasseClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Races_RaceId",
                table: "AspNetUsers",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Races_RaceId",
                table: "Monsters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_ClasseClassId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Races_RaceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Races_RaceId",
                table: "Monsters");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_RaceId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClasseClassId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RaceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClasseClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "Monsters",
                newName: "Race");

            migrationBuilder.AddColumn<string>(
                name: "Classe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "MonsterId", "MonsterName", "Race", "Stamina", "Strength" },
                values: new object[,]
                {
                    { 1, "Spider", 4, 2, 2 },
                    { 2, "Ogre", 5, 3, 1 },
                    { 3, "Grougaloragran", 6, 12, 4 },
                    { 4, "Serwaul", 7, 1, 7 },
                    { 5, "Bat", 4, 2, 1 },
                    { 6, "Giant Wolf", 4, 3, 4 },
                    { 7, "Efrit", 5, 4, 4 },
                    { 8, "Bone Golem", 5, 3, 5 },
                    { 9, "Hydra", 5, 11, 5 },
                    { 10, "Kobold", 5, 4, 2 },
                    { 11, "Fafnir", 6, 7, 9 },
                    { 12, "Dark Lord", 7, 20, 20 },
                    { 13, "Vouivre", 6, 15, 10 }
                });
        }
    }
}
