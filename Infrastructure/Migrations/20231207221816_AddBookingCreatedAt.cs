using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddBookingCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efedf18f-0d59-4b74-b8b3-3f670ea8a56e", "AQAAAAEAACcQAAAAEOkw7PvoN9BklRtBqVCzmlSJ5zgcAl1BemhHNz2zp8T7pg1QAVtvVP/4ycLlO4THDw==", "0b0fc9d3-e245-4f41-92c8-2b4eeb4b07af" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df716a31-c5c9-41cf-987f-0e1f27d5c527", "AQAAAAEAACcQAAAAECTiOByxAFS4gJ/8AtvwonpgZ1zyOqx9IbWcGTvIc77vbLweuPVbesRRYbvZn7yEng==", "4e366cb6-d341-4ae4-9dda-1122cd3a2a2b" });
        }
    }
}
