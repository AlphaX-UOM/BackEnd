using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class ImageUrlUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "TourGuideServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "HotelsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "TourGuideServices");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "HotelsServices");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "EventPlannerServices");
        }
    }
}
