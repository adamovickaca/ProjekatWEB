using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWEB.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxBrMesta",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Clan");

            migrationBuilder.RenameColumn(
                name: "BrZauzetih",
                table: "Termin",
                newName: "SlobodnaMesta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SlobodnaMesta",
                table: "Termin",
                newName: "BrZauzetih");

            migrationBuilder.AddColumn<int>(
                name: "MaxBrMesta",
                table: "Trening",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Clan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
