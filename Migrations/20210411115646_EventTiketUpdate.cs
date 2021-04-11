using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class EventTiketUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdultTikets",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KidTikets",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdultTickets",
                table: "EventPlannerServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KidTickets",
                table: "EventPlannerServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultTikets",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "KidTikets",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AdultTickets",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "KidTickets",
                table: "EventPlannerServices");
        }
    }
}
