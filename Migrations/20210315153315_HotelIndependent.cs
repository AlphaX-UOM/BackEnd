using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class HotelIndependent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                table: "HotelsServices");

            migrationBuilder.DropIndex(
                name: "IX_HotelsServices_RoomTypeID",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "RoomTypeID",
                table: "HotelsServices");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "HotelsServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "HotelsServices");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomTypeID",
                table: "HotelsServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServices_RoomTypeID",
                table: "HotelsServices",
                column: "RoomTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                table: "HotelsServices",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
