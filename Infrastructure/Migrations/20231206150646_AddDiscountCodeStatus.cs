using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddDiscountCodeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeStatus",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e16d4d15-e3b2-4c4a-b2e2-e4588330686b", "AQAAAAEAACcQAAAAED5PNn6pCaAGiFdnK76TD0pXTDN7C+wEIE4RWp9iMu5rO6H4oPUuwsxfsug3Yjtnfg==", "1ac53c80-395b-4432-9022-27b5e9b34227" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCodeStatus",
                table: "Coupons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d4c7e7-1f74-47d7-bf73-af4f369aaddf", "AQAAAAEAACcQAAAAEFyKE2Fs4c8JnVI+T0S5g4z9AvagOyux8pApCyivKmCfRJYR4O6IzP1GWs9/t/uLyw==", "0fa39656-fe9f-4148-a1dd-74798cb99217" });
        }
    }
}
