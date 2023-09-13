using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2DataAccessLayer.Migrations
{
    public partial class create_car_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarBuildYear = table.Column<int>(type: "int", nullable: false),
                    CarColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarOdometer = table.Column<int>(type: "int", nullable: false),
                    CarSeat = table.Column<int>(type: "int", nullable: false),
                    CarRentPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
