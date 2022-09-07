using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleActz.Infrastructure.Migrations
{
    public partial class new_user_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "590bfafc-89fc-4ba3-a063-098d08354935", "ecb6d999-b0a8-4cda-bc91-2fe7ed76d652", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0d19fb6-a564-4e6f-a845-98adc500f7ad", "b5d7a3c1-9fb2-4f18-9821-f1544bd6476a", "AppUser", "APPUSER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "590bfafc-89fc-4ba3-a063-098d08354935");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0d19fb6-a564-4e6f-a845-98adc500f7ad");
        }
    }
}
