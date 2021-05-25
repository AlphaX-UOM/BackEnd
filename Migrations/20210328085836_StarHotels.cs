using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class StarHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "HotelsServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stars",
                table: "HotelsServices");
        }
    }
}
