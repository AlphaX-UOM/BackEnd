using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class databaseUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancellations_Reservations_ReservationID",
                table: "Cancellations");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancellations_Users_UserID",
                table: "Cancellations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPlannerServiceComments_EventPlannerServices_EventPlannerServiceID",
                table: "EventPlannerServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPlannerServices_Users_UserID",
                table: "EventPlannerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServiceComments_HotelsServices_HotelsServiceID",
                table: "HotelsServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServiceComments_Users_UserID",
                table: "HotelsServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                table: "HotelsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices_Users_UserID",
                table: "HotelsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_HotelsServices_HotelsServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payments_PaymentID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TourGuideServices_TourGuideServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TransportServices_TransportServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TourGuideServiceComments_TourGuideServices_TourGuideServiceID",
                table: "TourGuideServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourGuideServiceComments_Users_UserID",
                table: "TourGuideServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourGuideServices_Users_UserID",
                table: "TourGuideServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportServiceComments_TransportServices_TransportServiceID",
                table: "TransportServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportServiceComments_Users_UserID",
                table: "TransportServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportServices_Users_UserID",
                table: "TransportServices");

            migrationBuilder.DropIndex(
                name: "IX_Cancellations_ReservationID",
                table: "Cancellations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TransportServices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TransportServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransportServiceID",
                table: "TransportServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TourGuideServices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TourGuideServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourGuideServiceID",
                table: "TourGuideServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "HotelsServices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeID",
                table: "HotelsServices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "HotelsServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelsServiceID",
                table: "HotelsServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "EventPlannerServices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventPlannerServiceID",
                table: "EventPlannerServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Cancellations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReservationID",
                table: "Cancellations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_ReservationID",
                table: "Cancellations",
                column: "ReservationID",
                unique: true,
                filter: "[ReservationID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cancellations_Reservations_ReservationID",
                table: "Cancellations",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancellations_Users_UserID",
                table: "Cancellations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlannerServiceComments_EventPlannerServices_EventPlannerServiceID",
                table: "EventPlannerServiceComments",
                column: "EventPlannerServiceID",
                principalTable: "EventPlannerServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlannerServices_Users_UserID",
                table: "EventPlannerServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServiceComments_HotelsServices_HotelsServiceID",
                table: "HotelsServiceComments",
                column: "HotelsServiceID",
                principalTable: "HotelsServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServiceComments_Users_UserID",
                table: "HotelsServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                table: "HotelsServices",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices_Users_UserID",
                table: "HotelsServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserID",
                table: "Payments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_HotelsServices_HotelsServiceID",
                table: "Reservations",
                column: "HotelsServiceID",
                principalTable: "HotelsServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payments_PaymentID",
                table: "Reservations",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TourGuideServices_TourGuideServiceID",
                table: "Reservations",
                column: "TourGuideServiceID",
                principalTable: "TourGuideServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TransportServices_TransportServiceID",
                table: "Reservations",
                column: "TransportServiceID",
                principalTable: "TransportServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserID",
                table: "Reservations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourGuideServiceComments_TourGuideServices_TourGuideServiceID",
                table: "TourGuideServiceComments",
                column: "TourGuideServiceID",
                principalTable: "TourGuideServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourGuideServiceComments_Users_UserID",
                table: "TourGuideServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourGuideServices_Users_UserID",
                table: "TourGuideServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportServiceComments_TransportServices_TransportServiceID",
                table: "TransportServiceComments",
                column: "TransportServiceID",
                principalTable: "TransportServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportServiceComments_Users_UserID",
                table: "TransportServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportServices_Users_UserID",
                table: "TransportServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancellations_Reservations_ReservationID",
                table: "Cancellations");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancellations_Users_UserID",
                table: "Cancellations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPlannerServiceComments_EventPlannerServices_EventPlannerServiceID",
                table: "EventPlannerServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPlannerServices_Users_UserID",
                table: "EventPlannerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServiceComments_HotelsServices_HotelsServiceID",
                table: "HotelsServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServiceComments_Users_UserID",
                table: "HotelsServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                table: "HotelsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices_Users_UserID",
                table: "HotelsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_HotelsServices_HotelsServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payments_PaymentID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TourGuideServices_TourGuideServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TransportServices_TransportServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TourGuideServiceComments_TourGuideServices_TourGuideServiceID",
                table: "TourGuideServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourGuideServiceComments_Users_UserID",
                table: "TourGuideServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourGuideServices_Users_UserID",
                table: "TourGuideServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportServiceComments_TransportServices_TransportServiceID",
                table: "TransportServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportServiceComments_Users_UserID",
                table: "TransportServiceComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportServices_Users_UserID",
                table: "TransportServices");

            migrationBuilder.DropIndex(
                name: "IX_Cancellations_ReservationID",
                table: "Cancellations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TransportServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TransportServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TransportServiceID",
                table: "TransportServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TourGuideServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "TourGuideServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TourGuideServiceID",
                table: "TourGuideServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "HotelsServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeID",
                table: "HotelsServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "HotelsServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelsServiceID",
                table: "HotelsServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "EventPlannerServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventPlannerServiceID",
                table: "EventPlannerServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Cancellations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReservationID",
                table: "Cancellations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_ReservationID",
                table: "Cancellations",
                column: "ReservationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancellations_Reservations_ReservationID",
                table: "Cancellations",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancellations_Users_UserID",
                table: "Cancellations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlannerServiceComments_EventPlannerServices_EventPlannerServiceID",
                table: "EventPlannerServiceComments",
                column: "EventPlannerServiceID",
                principalTable: "EventPlannerServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlannerServices_Users_UserID",
                table: "EventPlannerServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServiceComments_HotelsServices_HotelsServiceID",
                table: "HotelsServiceComments",
                column: "HotelsServiceID",
                principalTable: "HotelsServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServiceComments_Users_UserID",
                table: "HotelsServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices_RoomTypes_RoomTypeID",
                table: "HotelsServices",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices_Users_UserID",
                table: "HotelsServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserID",
                table: "Payments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_HotelsServices_HotelsServiceID",
                table: "Reservations",
                column: "HotelsServiceID",
                principalTable: "HotelsServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payments_PaymentID",
                table: "Reservations",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TourGuideServices_TourGuideServiceID",
                table: "Reservations",
                column: "TourGuideServiceID",
                principalTable: "TourGuideServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TransportServices_TransportServiceID",
                table: "Reservations",
                column: "TransportServiceID",
                principalTable: "TransportServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserID",
                table: "Reservations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourGuideServiceComments_TourGuideServices_TourGuideServiceID",
                table: "TourGuideServiceComments",
                column: "TourGuideServiceID",
                principalTable: "TourGuideServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourGuideServiceComments_Users_UserID",
                table: "TourGuideServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourGuideServices_Users_UserID",
                table: "TourGuideServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportServiceComments_TransportServices_TransportServiceID",
                table: "TransportServiceComments",
                column: "TransportServiceID",
                principalTable: "TransportServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportServiceComments_Users_UserID",
                table: "TransportServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportServices_Users_UserID",
                table: "TransportServices",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
