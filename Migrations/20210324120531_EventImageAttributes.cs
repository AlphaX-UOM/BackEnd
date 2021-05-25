using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class EventImageAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL02",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL03",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerKid",
                table: "EventPlannerServices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL02",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "ImgURL03",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "PricePerKid",
                table: "EventPlannerServices");
        }
    }
}
