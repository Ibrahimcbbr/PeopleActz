using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleActz.Infrastructure.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0da8619-da2a-4bfe-8733-0b03a1f28d55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af185661-a42a-4d6f-b3c1-b79e6259d60f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ea950b9-f518-4028-8dc3-f08c49396c9a", "51be1ed7-4be5-4ee3-a1a3-b129208a8231", "AppUser", "APPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edcd3890-0310-47c3-a604-7db464a98f9d", "79f6fd09-0b41-4489-81e1-8da4ba273b12", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea950b9-f518-4028-8dc3-f08c49396c9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edcd3890-0310-47c3-a604-7db464a98f9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0da8619-da2a-4bfe-8733-0b03a1f28d55", "489e846d-eb84-443a-b6d6-55270ea99cf8", "AppUser", "APPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af185661-a42a-4d6f-b3c1-b79e6259d60f", "0fab7f25-debb-4c91-86ce-053051d6ddad", "Administrator", "ADMINISTRATOR" });
        }
    }
}
