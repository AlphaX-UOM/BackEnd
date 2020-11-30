using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuggestorCodeFirstAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "Contact", "DateTime", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "N0:198/3, Airport Road, Minuwangoda", "0715510491", "1996/07/27", "gdsudam@gmail.com", "Sudam", "Yasodya", "123", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "Contact", "DateTime", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871"), "N0:198/3, Airport Road, Minuwangoda, Gampaha", "0112294169", "1996/07/28", "gdsudam@gmail.com.com", "Sudama", "Yasodyaa", "1234", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871"));
        }
    }
}
