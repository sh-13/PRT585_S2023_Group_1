using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2DataAccessLayer.Migrations
{
    public partial class AddCarModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarName",
                table: "Cars",
                newName: "CarModelName");

            migrationBuilder.RenameColumn(
                name: "CarModel",
                table: "Cars",
                newName: "CarCompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarModelName",
                table: "Cars",
                newName: "CarName");

            migrationBuilder.RenameColumn(
                name: "CarCompanyName",
                table: "Cars",
                newName: "CarModel");
        }
    }
}
