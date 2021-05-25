using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class TransportModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "TransportServices");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AirCondition",
                table: "TransportServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfSeats",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricePer1KM",
                table: "TransportServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfPassengers",
                table: "Reservations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "AirCondition",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "NoOfSeats",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "PricePer1KM",
                table: "TransportServices");

            migrationBuilder.DropColumn(
                name: "NoOfPassengers",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "TransportServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
