using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWEB.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_Teretana_teretanaID",
                table: "Treninzi");

            migrationBuilder.DropTable(
                name: "Partneri");

            migrationBuilder.DropTable(
                name: "Vezbaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treninzi",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "BrojZauzetihMesta",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "Clanarina",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "DatumIsteka",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "DatumUplate",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "MaxBrojMesta",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Treninzi");

            migrationBuilder.RenameTable(
                name: "Treninzi",
                newName: "Trening");

            migrationBuilder.RenameColumn(
                name: "teretanaID",
                table: "Trening",
                newName: "vrstaID");

            migrationBuilder.RenameIndex(
                name: "IX_Treninzi_teretanaID",
                table: "Trening",
                newName: "IX_Trening_vrstaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trening",
                table: "Trening",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teretanaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clan_Teretana_teretanaID",
                        column: x => x.teretanaID,
                        principalTable: "Teretana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vrsta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeretanaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrsta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vrsta_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxBrMesta = table.Column<int>(type: "int", nullable: false),
                    BrZauzetih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trenerID = table.Column<int>(type: "int", nullable: true),
                    teretanaID = table.Column<int>(type: "int", nullable: true),
                    treningID = table.Column<int>(type: "int", nullable: true),
                    ClanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Termin_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termin_Teretana_teretanaID",
                        column: x => x.teretanaID,
                        principalTable: "Teretana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termin_Trener_trenerID",
                        column: x => x.trenerID,
                        principalTable: "Trener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termin_Trening_treningID",
                        column: x => x.treningID,
                        principalTable: "Trening",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clan_teretanaID",
                table: "Clan",
                column: "teretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_ClanID",
                table: "Termin",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_teretanaID",
                table: "Termin",
                column: "teretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_trenerID",
                table: "Termin",
                column: "trenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_treningID",
                table: "Termin",
                column: "treningID");

            migrationBuilder.CreateIndex(
                name: "IX_Vrsta_TeretanaID",
                table: "Vrsta",
                column: "TeretanaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_Vrsta_vrstaID",
                table: "Trening",
                column: "vrstaID",
                principalTable: "Vrsta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trening_Vrsta_vrstaID",
                table: "Trening");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "Vrsta");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trening",
                table: "Trening");

            migrationBuilder.RenameTable(
                name: "Trening",
                newName: "Treninzi");

            migrationBuilder.RenameColumn(
                name: "vrstaID",
                table: "Treninzi",
                newName: "teretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Trening_vrstaID",
                table: "Treninzi",
                newName: "IX_Treninzi_teretanaID");

            migrationBuilder.AddColumn<int>(
                name: "BrojZauzetihMesta",
                table: "Treninzi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Clanarina",
                table: "Treninzi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIsteka",
                table: "Treninzi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumUplate",
                table: "Treninzi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaxBrojMesta",
                table: "Treninzi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Treninzi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Treninzi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treninzi",
                table: "Treninzi",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Vezbaci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojPartnera = table.Column<int>(type: "int", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<int>(type: "int", nullable: false),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreningID = table.Column<int>(type: "int", nullable: true),
                    teretanaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vezbaci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vezbaci_Teretana_teretanaID",
                        column: x => x.teretanaID,
                        principalTable: "Teretana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vezbaci_Treninzi_TreningID",
                        column: x => x.TreningID,
                        principalTable: "Treninzi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partneri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vezbacID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partneri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partneri_Vezbaci_vezbacID",
                        column: x => x.vezbacID,
                        principalTable: "Vezbaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partneri_vezbacID",
                table: "Partneri",
                column: "vezbacID");

            migrationBuilder.CreateIndex(
                name: "IX_Vezbaci_teretanaID",
                table: "Vezbaci",
                column: "teretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vezbaci_TreningID",
                table: "Vezbaci",
                column: "TreningID");

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_Teretana_teretanaID",
                table: "Treninzi",
                column: "teretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
