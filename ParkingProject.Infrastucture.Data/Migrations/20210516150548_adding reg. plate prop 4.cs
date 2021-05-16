using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingProject.Infrastucture.Data.Migrations
{
    public partial class addingregplateprop4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationPlates",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationPlate",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationPlate",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationPlates",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
