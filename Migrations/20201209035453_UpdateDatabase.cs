using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class UpdateDatabase : Migration
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
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    RoomTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServices", x => x.ID);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventPlannerServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlannerServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceComments_EventPlannerServices_EventPlannerServiceID",
                        column: x => x.EventPlannerServiceID,
                        principalTable: "EventPlannerServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EventPlannerServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HotelServiceRoomTypes",
                columns: table => new
                {
                    HotelServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelsServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelServiceRoomTypes", x => new { x.HotelServiceId, x.RoomTypeId });
                    table.ForeignKey(
                        name: "FK_HotelServiceRoomTypes_HotelsServices_HotelsServiceID",
                        column: x => x.HotelsServiceID,
                        principalTable: "HotelsServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelServiceRoomTypes_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelsServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HotelsServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HotelsServiceComments_HotelsServices_HotelsServiceID",
                        column: x => x.HotelsServiceID,
                        principalTable: "HotelsServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HotelsServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TourGuideServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TourGuideServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourGuideServiceComments_TourGuideServices_TourGuideServiceID",
                        column: x => x.TourGuideServiceID,
                        principalTable: "TourGuideServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TourGuideServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
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
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventPlannerServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfRooms = table.Column<int>(type: "int", nullable: true),
                    HotelsServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TourGuideServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropOffTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropOffLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_EventPlannerServices_EventPlannerServiceID",
                        column: x => x.EventPlannerServiceID,
                        principalTable: "EventPlannerServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_HotelsServices_HotelsServiceID",
                        column: x => x.HotelsServiceID,
                        principalTable: "HotelsServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_TourGuideServices_TourGuideServiceID",
                        column: x => x.TourGuideServiceID,
                        principalTable: "TourGuideServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_TransportServices_TransportServiceID",
                        column: x => x.TransportServiceID,
                        principalTable: "TransportServices",
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
                name: "TransportServiceComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransportServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServiceComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransportServiceComments_TransportServices_TransportServiceID",
                        column: x => x.TransportServiceID,
                        principalTable: "TransportServices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TransportServiceComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cancellations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cancellations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cancellations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "Contact", "DOB", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "N0:198/3, Airport Road, Minuwangoda", "0715510491", "1996/07/27", "gdsudam@gmail.com", "Sudam", "Yasodya", "123", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "Contact", "DOB", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871"), "N0:198/3, Airport Road, Minuwangoda, Gampaha", "0112294169", "1996/07/28", "gdsudam@gmail.com.com", "Sudama", "Yasodyaa", "1234", "Customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "Contact", "DOB", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991875"), "N0:198/3, Airport Road, Malabe", "071556223", "1997/03/31", "rasmi@gmail.com", "Rasmi", "Duli", "123123", "ServiceProvider" });

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_ReservationID",
                table: "Cancellations",
                column: "ReservationID",
                unique: true,
                filter: "[ReservationID] IS NOT NULL");

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
                name: "IX_EventPlannerServices_UserID",
                table: "EventPlannerServices",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServiceRoomTypes_HotelsServiceID",
                table: "HotelServiceRoomTypes",
                column: "HotelsServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServiceRoomTypes_RoomTypeId",
                table: "HotelServiceRoomTypes",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceComments_HotelsServiceID",
                table: "HotelsServiceComments",
                column: "HotelsServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServiceComments_UserID",
                table: "HotelsServiceComments",
                column: "UserID");

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
                name: "IX_Reservations_EventPlannerServiceID",
                table: "Reservations",
                column: "EventPlannerServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelsServiceID",
                table: "Reservations",
                column: "HotelsServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentID",
                table: "Reservations",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TourGuideServiceID",
                table: "Reservations",
                column: "TourGuideServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TransportServiceID",
                table: "Reservations",
                column: "TransportServiceID");

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
                name: "HotelServiceRoomTypes");

            migrationBuilder.DropTable(
                name: "HotelsServiceComments");

            migrationBuilder.DropTable(
                name: "TourGuideServiceComments");

            migrationBuilder.DropTable(
                name: "TransportServiceComments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "EventPlannerServices");

            migrationBuilder.DropTable(
                name: "HotelsServices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TourGuideServices");

            migrationBuilder.DropTable(
                name: "TransportServices");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
