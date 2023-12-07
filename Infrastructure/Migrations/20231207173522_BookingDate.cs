using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class BookingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df716a31-c5c9-41cf-987f-0e1f27d5c527", "AQAAAAEAACcQAAAAECTiOByxAFS4gJ/8AtvwonpgZ1zyOqx9IbWcGTvIc77vbLweuPVbesRRYbvZn7yEng==", "4e366cb6-d341-4ae4-9dda-1122cd3a2a2b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66b68227-6be9-448e-8503-e25f880ba865", "AQAAAAEAACcQAAAAEGcBRRsqltwLFTt6jB+u1OyMMqSbYOxNTm3nhxK0Qj0poDDcVIe9BKhTATbg9jL0Vg==", "346ec06c-1e5d-430c-9109-3565fd018684" });
        }
    }
}
