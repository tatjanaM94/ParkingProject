using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingProject.Infrastucture.Data.Migrations
{
    public partial class NewcarPROPnullablegarageIDnullableLastModified3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Garages",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Garages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
