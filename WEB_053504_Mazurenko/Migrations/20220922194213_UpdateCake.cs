using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053504_Mazurenko.Migrations
{
    public partial class UpdateCake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "Cakes",
                newName: "PlateSize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlateSize",
                table: "Cakes",
                newName: "Calories");
        }
    }
}
