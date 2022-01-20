using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Partners.Migrations
{
    public partial class addByOgPostnummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "alder",
                table: "Medarbejdere",
                newName: "Alder");

            migrationBuilder.AddColumn<string>(
                name: "By",
                table: "Medarbejdere",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postnummer",
                table: "Medarbejdere",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "By",
                table: "Medarbejdere");

            migrationBuilder.DropColumn(
                name: "Postnummer",
                table: "Medarbejdere");

            migrationBuilder.RenameColumn(
                name: "Alder",
                table: "Medarbejdere",
                newName: "alder");
        }
    }
}
