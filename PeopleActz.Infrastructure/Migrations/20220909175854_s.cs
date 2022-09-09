using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleActz.Infrastructure.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "970eb166-8e4b-4052-a71d-51542d32e718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e476b24d-cf84-481d-bfba-6129a6d77b2b");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32e5c3fe-f4ca-4222-bd54-eafda06482ef", "8edb376d-6e85-4320-94fa-e401f8b9b30f", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8f81786-a93f-45ae-b0bc-0eb7bc34b5d8", "f346dffa-d2cb-4c70-a64a-2afbc2f5a1f4", "AppUser", "APPUSER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32e5c3fe-f4ca-4222-bd54-eafda06482ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8f81786-a93f-45ae-b0bc-0eb7bc34b5d8");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "970eb166-8e4b-4052-a71d-51542d32e718", "30082872-4ff4-463b-8aaa-0d984e50272f", "AppUser", "APPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e476b24d-cf84-481d-bfba-6129a6d77b2b", "3155a72b-e1b7-4d55-a24b-f5616c572785", "Administrator", "ADMINISTRATOR" });
        }
    }
}
