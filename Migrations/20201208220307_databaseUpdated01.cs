using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class databaseUpdated01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPlannerServiceComments_Users_UserID",
                table: "EventPlannerServiceComments");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "EventPlannerServiceComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlannerServiceComments_Users_UserID",
                table: "EventPlannerServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPlannerServiceComments_Users_UserID",
                table: "EventPlannerServiceComments");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "EventPlannerServiceComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlannerServiceComments_Users_UserID",
                table: "EventPlannerServiceComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
