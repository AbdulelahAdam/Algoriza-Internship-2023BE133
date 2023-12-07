using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddOriginalAndCurrentRequestsNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestsNumber",
                table: "Coupons",
                newName: "OriginalRequestsNumber");

            migrationBuilder.AddColumn<int>(
                name: "CurrentRequestsNumber",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "FinalBookingPrice",
                table: "Bookings",
                type: "real",
                nullable: true,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66b68227-6be9-448e-8503-e25f880ba865", "AQAAAAEAACcQAAAAEGcBRRsqltwLFTt6jB+u1OyMMqSbYOxNTm3nhxK0Qj0poDDcVIe9BKhTATbg9jL0Vg==", "346ec06c-1e5d-430c-9109-3565fd018684" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentRequestsNumber",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "FinalBookingPrice",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "OriginalRequestsNumber",
                table: "Coupons",
                newName: "RequestsNumber");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5d18038-d0c1-4a41-80ec-9b76e4959486", "AQAAAAEAACcQAAAAEM6DNVf9U/L1uOZuHVAjIVZOP4COs6nTnOdiCgJ/lbEaUfRVRSYa4qlEbdnqXkHpBw==", "2402c152-80b9-4579-85c2-26c93bf9e410" });
        }
    }
}
