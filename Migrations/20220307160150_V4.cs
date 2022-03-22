using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWEB.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Clan_ClanID",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Trener_trenerID",
                table: "Termin");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropIndex(
                name: "IX_Termin_ClanID",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "ClanID",
                table: "Termin");

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Clan_trenerID",
                table: "Termin",
                column: "trenerID",
                principalTable: "Clan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Clan_trenerID",
                table: "Termin");

            migrationBuilder.AddColumn<int>(
                name: "ClanID",
                table: "Termin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termin_ClanID",
                table: "Termin",
                column: "ClanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Clan_ClanID",
                table: "Termin",
                column: "ClanID",
                principalTable: "Clan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Trener_trenerID",
                table: "Termin",
                column: "trenerID",
                principalTable: "Trener",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
