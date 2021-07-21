using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class tablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Available", "reserved_toId", "status" },
                values: new object[] { 1, true, null, "Available" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Available", "reserved_toId", "status" },
                values: new object[] { 2, false, null, "Unavailable" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Available", "reserved_toId", "status" },
                values: new object[] { 3, true, null, "Available" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "status",
                table: "Tables");
        }
    }
}
