using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingProject.Infrastucture.Data.Migrations
{
    public partial class addingregplateprop5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Cars");

           
        }
    }
}
