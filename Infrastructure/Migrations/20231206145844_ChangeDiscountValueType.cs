using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeDiscountValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiscountValue",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d4c7e7-1f74-47d7-bf73-af4f369aaddf", "AQAAAAEAACcQAAAAEFyKE2Fs4c8JnVI+T0S5g4z9AvagOyux8pApCyivKmCfRJYR4O6IzP1GWs9/t/uLyw==", "0fa39656-fe9f-4148-a1dd-74798cb99217" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DiscountValue",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d74862f-eac4-4d20-9b9d-5330766a0286", "AQAAAAEAACcQAAAAEEUIGvykQOUCz1kSK7VEu8qR9SjOmXxb2hwTEIT8hEf3Jq+BBx0y6tSCT5qi39TY6Q==", "9b2eab94-1f00-4fd9-b3ec-1d9a01656638" });
        }
    }
}
