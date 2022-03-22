using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWEB.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teretana",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontakTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vlasnik = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teretana", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxBrojMesta = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clanarina = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojZauzetihMesta = table.Column<int>(type: "int", nullable: false),
                    teretanaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Treninzi_Teretana_teretanaID",
                        column: x => x.teretanaID,
                        principalTable: "Teretana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vezbaci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojPartnera = table.Column<int>(type: "int", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JMBG = table.Column<int>(type: "int", nullable: false),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teretanaID = table.Column<int>(type: "int", nullable: true),
                    TreningID = table.Column<int>(type: "int", nullable: true)
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
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_Treninzi_teretanaID",
                table: "Treninzi",
                column: "teretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vezbaci_teretanaID",
                table: "Vezbaci",
                column: "teretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vezbaci_TreningID",
                table: "Vezbaci",
                column: "TreningID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partneri");

            migrationBuilder.DropTable(
                name: "Vezbaci");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropTable(
                name: "Teretana");
        }
    }
}
