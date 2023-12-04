using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddBookingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ba24aed-155b-436a-ab81-f76160b10a98", "AQAAAAEAACcQAAAAEC958O9EY5ein0KlXepTFRNHSx2sNAej5VmH3qIY/aoGsiC7IRCOcBGsIl1bg0W0lg==", "58287c9d-600f-4b71-a259-e0917644b60e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a2257e6-bdcd-4919-bf6b-d59ebe0e4f59", "AQAAAAEAACcQAAAAEFsnt4VPWYPK53fviWNU5h+frhBniEKB7EEUFKiD9+BdA6tjagykRdQzJk658RHfMQ==", "e96201ad-93e2-4946-a194-aa5a1902edee" });
        }
    }
}
