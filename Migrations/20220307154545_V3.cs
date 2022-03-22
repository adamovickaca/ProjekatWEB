using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWEB.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vrsta_Teretana_TeretanaID",
                table: "Vrsta");

            migrationBuilder.DropColumn(
                name: "MaxBrMesta",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "Vlasnik",
                table: "Teretana");

            migrationBuilder.RenameColumn(
                name: "TeretanaID",
                table: "Vrsta",
                newName: "teretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Vrsta_TeretanaID",
                table: "Vrsta",
                newName: "IX_Vrsta_teretanaID");

            migrationBuilder.AddColumn<int>(
                name: "MaxBrMesta",
                table: "Trening",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Trening",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SlikaPath",
                table: "Trening",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Trajanje",
                table: "Trening",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Trener",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Trener",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrZauzetih",
                table: "Termin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Zauzeto",
                table: "Termin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trener",
                table: "Clan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Vrsta_Teretana_teretanaID",
                table: "Vrsta",
                column: "teretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vrsta_Teretana_teretanaID",
                table: "Vrsta");

            migrationBuilder.DropColumn(
                name: "MaxBrMesta",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "SlikaPath",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "Trajanje",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "Zauzeto",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "trener",
                table: "Clan");

            migrationBuilder.RenameColumn(
                name: "teretanaID",
                table: "Vrsta",
                newName: "TeretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Vrsta_teretanaID",
                table: "Vrsta",
                newName: "IX_Vrsta_TeretanaID");

            migrationBuilder.AlterColumn<string>(
                name: "BrZauzetih",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaxBrMesta",
                table: "Termin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Vlasnik",
                table: "Teretana",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vrsta_Teretana_TeretanaID",
                table: "Vrsta",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
