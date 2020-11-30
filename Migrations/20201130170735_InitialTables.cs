using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfGuests = table.Column<int>(type: "int", nullable: false),
                    Specs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransportTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventPlannerServices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlannerServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPlannerServices_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelsServices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelsServices_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourGuideServices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourGuideServices_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportServices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransportServices_TransportTypes_TransportTypeID",
                        column: x => x.TransportTypeID,
                        principalTable: "TransportTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportServices_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventPlannerServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventPlannerServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlannerServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceComments_EventPlannerServices_EventPlannerServiceID",
                        column: x => x.EventPlannerServiceID,
                        principalTable: "EventPlannerServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelsServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelsServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HotelsServiceComments_HotelsServices_HotelsServiceID",
                        column: x => x.HotelsServiceID,
                        principalTable: "HotelsServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelsServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumOfTravellers = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourGuideServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourGuideServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourGuideServiceComments_TourGuideServices_TourGuideServiceID",
                        column: x => x.TourGuideServiceID,
                        principalTable: "TourGuideServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourGuideServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransportServiceComments_TransportServices_TransportServiceID",
                        column: x => x.TransportServiceID,
                        principalTable: "TransportServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cancellations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cancellations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cancellations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventPlannerServiceReservations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventPlannerServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlannerServiceReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceReservations_EventPlannerServices_EventPlannerServiceID",
                        column: x => x.EventPlannerServiceID,
                        principalTable: "EventPlannerServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelsServiceReservations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelsServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsServiceReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HotelsServiceReservations_HotelsServices_HotelsServiceID",
                        column: x => x.HotelsServiceID,
                        principalTable: "HotelsServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelsServiceReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourGuideServiceReservations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourGuideServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideServiceReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourGuideServiceReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourGuideServiceReservations_TourGuideServices_TourGuideServiceID",
                        column: x => x.TourGuideServiceID,
                        principalTable: "TourGuideServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportServiceReservations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropOffLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServiceReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransportServiceReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportServiceReservations_TransportServices_TransportServiceID",
                        column: x => x.TransportServiceID,
                        principalTable: "TransportServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_ReservationID",
                table: "Cancellations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_UserID",
                table: "Cancellations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServiceComments_EventPlannerServiceID",
                table: "EventPlannerServiceComments",
                column: "EventPlannerServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServiceComments_UserID",
                table: "EventPlannerServiceComments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServiceReservations_EventPlannerServiceID",
                table: "EventPlannerServiceReservations",
                column: "EventPlannerServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServiceReservations_ReservationID",
                table: "EventPlannerServiceReservations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlannerServices_UserID",
                table: "EventPlannerServices",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceComments_HotelsServiceID",
                table: "HotelsServiceComments",
                column: "HotelsServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceComments_UserID",
                table: "HotelsServiceComments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceReservations_HotelsServiceID",
                table: "HotelsServiceReservations",
                column: "HotelsServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceReservations_ReservationID",
                table: "HotelsServiceReservations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServices_RoomTypeID",
                table: "HotelsServices",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServices_UserID",
                table: "HotelsServices",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserID",
                table: "Payments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentID",
                table: "Reservations",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServiceComments_TourGuideServiceID",
                table: "TourGuideServiceComments",
                column: "TourGuideServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServiceComments_UserID",
                table: "TourGuideServiceComments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServiceReservations_ReservationID",
                table: "TourGuideServiceReservations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServiceReservations_TourGuideServiceID",
                table: "TourGuideServiceReservations",
                column: "TourGuideServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideServices_UserID",
                table: "TourGuideServices",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServiceComments_TransportServiceID",
                table: "TransportServiceComments",
                column: "TransportServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServiceComments_UserID",
                table: "TransportServiceComments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServiceReservations_ReservationID",
                table: "TransportServiceReservations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServiceReservations_TransportServiceID",
                table: "TransportServiceReservations",
                column: "TransportServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_TransportTypeID",
                table: "TransportServices",
                column: "TransportTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_UserID",
                table: "TransportServices",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancellations");

            migrationBuilder.DropTable(
                name: "EventPlannerServiceComments");

            migrationBuilder.DropTable(
                name: "EventPlannerServiceReservations");

            migrationBuilder.DropTable(
                name: "HotelsServiceComments");

            migrationBuilder.DropTable(
                name: "HotelsServiceReservations");

            migrationBuilder.DropTable(
                name: "TourGuideServiceComments");

            migrationBuilder.DropTable(
                name: "TourGuideServiceReservations");

            migrationBuilder.DropTable(
                name: "TransportServiceComments");

            migrationBuilder.DropTable(
                name: "TransportServiceReservations");

            migrationBuilder.DropTable(
                name: "EventPlannerServices");

            migrationBuilder.DropTable(
                name: "HotelsServices");

            migrationBuilder.DropTable(
                name: "TourGuideServices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "TransportServices");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TransportTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
