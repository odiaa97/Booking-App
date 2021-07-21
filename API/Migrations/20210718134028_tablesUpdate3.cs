using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class tablesUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Available", "reserved_toId", "status" },
                values: new object[] { 1, true, null, "Available" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Available", "reserved_toId", "status" },
                values: new object[] { 2, false, null, "Unavailable" });
        }
    }
}
