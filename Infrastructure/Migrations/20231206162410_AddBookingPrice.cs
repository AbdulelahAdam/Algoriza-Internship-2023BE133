using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddBookingPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BookingPrice",
                table: "Bookings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5d18038-d0c1-4a41-80ec-9b76e4959486", "AQAAAAEAACcQAAAAEM6DNVf9U/L1uOZuHVAjIVZOP4COs6nTnOdiCgJ/lbEaUfRVRSYa4qlEbdnqXkHpBw==", "2402c152-80b9-4579-85c2-26c93bf9e410" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingPrice",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e16d4d15-e3b2-4c4a-b2e2-e4588330686b", "AQAAAAEAACcQAAAAED5PNn6pCaAGiFdnK76TD0pXTDN7C+wEIE4RWp9iMu5rO6H4oPUuwsxfsug3Yjtnfg==", "1ac53c80-395b-4432-9022-27b5e9b34227" });
        }
    }
}
