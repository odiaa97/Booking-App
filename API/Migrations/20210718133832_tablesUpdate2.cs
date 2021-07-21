using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class tablesUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "Tables",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Available", "reserved_toId", "status" },
                values: new object[] { 3, true, null, "Available" });
        }
    }
}
