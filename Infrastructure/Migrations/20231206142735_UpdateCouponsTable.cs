using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateCouponsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestNumbers",
                table: "Coupons",
                newName: "RequestsNumber");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d74862f-eac4-4d20-9b9d-5330766a0286", "AQAAAAEAACcQAAAAEEUIGvykQOUCz1kSK7VEu8qR9SjOmXxb2hwTEIT8hEf3Jq+BBx0y6tSCT5qi39TY6Q==", "9b2eab94-1f00-4fd9-b3ec-1d9a01656638" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestsNumber",
                table: "Coupons",
                newName: "RequestNumbers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d35f845-ec42-4100-8270-47e040011fd1", "AQAAAAEAACcQAAAAEKbZnJImKi+RfxMsMzPk//Uy03R5WYhcGPBH6HXwFrRMFfUGuM5x5frs5bgvTlPdtA==", "af8affed-bc0e-43e0-8b4c-f11f148eff19" });
        }
    }
}
