using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingProject.Infrastucture.Data.Migrations
{
    public partial class NewcarPROPnullableLastModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
