using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class ratingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TransportServiceComments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TourGuideServiceComments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "HotelsServiceComments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "EventPlannerServiceComments");

            migrationBuilder.CreateTable(
                name: "EventPlannerServiceRatings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventPlannerServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlannerServiceRatings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceRatings_EventPlannerServices_EventPlannerServiceID",
                        column: x => x.EventPlannerServiceID,
                        principalTable: "EventPlannerServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceRatings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HotelsServiceRatings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HotelsServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsServiceRatings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HotelsServiceRatings_HotelsServices_HotelsServiceID",
                        column: x => x.HotelsServiceID,
                        principalTable: "HotelsServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HotelsServiceRatings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TourGuideServiceRatings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TourGuideServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideServiceRatings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourGuideServiceRatings_TourGuideServices_TourGuideServiceID",
                        column: x => x.TourGuideServiceID,
                        principalTable: "TourGuideServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TourGuideServiceRatings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TransportServiceRatings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransportServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServiceRatings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransportServiceRatings_TransportServices_TransportServiceID",
                        column: x => x.TransportServiceID,
                        principalTable: "TransportServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TransportServiceRatings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServiceRatings_EventPlannerServiceID",
                table: "EventPlannerServiceRatings",
                column: "EventPlannerServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServiceRatings_UserID",
                table: "EventPlannerServiceRatings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceRatings_HotelsServiceID",
                table: "HotelsServiceRatings",
                column: "HotelsServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceRatings_UserID",
                table: "HotelsServiceRatings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServiceRatings_TourGuideServiceID",
                table: "TourGuideServiceRatings",
                column: "TourGuideServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServiceRatings_UserID",
                table: "TourGuideServiceRatings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServiceRatings_TransportServiceID",
                table: "TransportServiceRatings",
                column: "TransportServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServiceRatings_UserID",
                table: "TransportServiceRatings",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPlannerServiceRatings");

            migrationBuilder.DropTable(
                name: "HotelsServiceRatings");

            migrationBuilder.DropTable(
                name: "TourGuideServiceRatings");

            migrationBuilder.DropTable(
                name: "TransportServiceRatings");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "TransportServiceComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "TourGuideServiceComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "HotelsServiceComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "EventPlannerServiceComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
