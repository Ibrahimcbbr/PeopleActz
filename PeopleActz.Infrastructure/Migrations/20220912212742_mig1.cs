using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleActz.Infrastructure.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952c7b43-a26d-46e3-b569-a09eb78a08e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd27a1b4-7cb8-44aa-9485-78d4a4915658");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0da8619-da2a-4bfe-8733-0b03a1f28d55", "489e846d-eb84-443a-b6d6-55270ea99cf8", "AppUser", "APPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af185661-a42a-4d6f-b3c1-b79e6259d60f", "0fab7f25-debb-4c91-86ce-053051d6ddad", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "952c7b43-a26d-46e3-b569-a09eb78a08e2", "c8ab26ec-a4e2-442b-a457-794ffa12e4a4", "AppUser", "APPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd27a1b4-7cb8-44aa-9485-78d4a4915658", "940301d0-f12a-4472-8eab-3a66e78d5540", "Administrator", "ADMINISTRATOR" });
        }
    }
}
