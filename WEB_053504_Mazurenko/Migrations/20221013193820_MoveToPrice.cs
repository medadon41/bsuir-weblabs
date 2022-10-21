using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053504_Mazurenko.Migrations
{
    public partial class MoveToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlateSize",
                table: "Cakes",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cakes",
                newName: "PlateSize");
        }
    }
}
