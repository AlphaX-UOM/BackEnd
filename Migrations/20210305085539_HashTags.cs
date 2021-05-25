using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class HashTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Audience",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "EventPlannerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HashTags",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostHashTags",
                columns: table => new
                {
                    EventPlannerServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HashTagID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHashTags", x => new { x.EventPlannerServiceID, x.HashTagID });
                    table.ForeignKey(
                        name: "FK_PostHashTags_EventPlannerServices_EventPlannerServiceID",
                        column: x => x.EventPlannerServiceID,
                        principalTable: "EventPlannerServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHashTags_HashTags_HashTagID",
                        column: x => x.HashTagID,
                        principalTable: "HashTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostHashTags_HashTagID",
                table: "PostHashTags",
                column: "HashTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostHashTags");

            migrationBuilder.DropTable(
                name: "HashTags");

            migrationBuilder.DropColumn(
                name: "Audience",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "District",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "EventPlannerServices");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "EventPlannerServices");
        }
    }
}
