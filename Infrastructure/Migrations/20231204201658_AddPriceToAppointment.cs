using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddPriceToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Day",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Appointments",
                type: "real",
                nullable: true,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e8bc5b-d68c-4b30-97c7-4fadb619a3fe", "AQAAAAEAACcQAAAAEHgde1QVaMrnU9QSCDIsiH+V4nFCAt5+OXTBJaUG35LpvQON+ljbHglv7AVBrjXejg==", "21ff94bc-9b43-41a2-8652-92608bd4e274" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointments");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "AspNetUsers",
                type: "real",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Day",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ba24aed-155b-436a-ab81-f76160b10a98", "AQAAAAEAACcQAAAAEC958O9EY5ein0KlXepTFRNHSx2sNAej5VmH3qIY/aoGsiC7IRCOcBGsIl1bg0W0lg==", "58287c9d-600f-4b71-a259-e0917644b60e" });
        }
    }
}
