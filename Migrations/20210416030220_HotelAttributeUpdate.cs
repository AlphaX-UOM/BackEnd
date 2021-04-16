using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class HotelAttributeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Venue",
                table: "HotelsServices",
                newName: "RoomImgURL03");

            migrationBuilder.RenameColumn(
                name: "ImgURL",
                table: "HotelsServices",
                newName: "RoomImgURL02");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine01",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine02",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltPnumber",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BedType",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HotelImgURL",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumOfRooms",
                table: "HotelsServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomImgURL01",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine01",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "AddressLine02",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "AltPnumber",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "BedType",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "HotelImgURL",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "NumOfRooms",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "RoomImgURL01",
                table: "HotelsServices");

            migrationBuilder.RenameColumn(
                name: "RoomImgURL03",
                table: "HotelsServices",
                newName: "Venue");

            migrationBuilder.RenameColumn(
                name: "RoomImgURL02",
                table: "HotelsServices",
                newName: "ImgURL");
        }
    }
}
