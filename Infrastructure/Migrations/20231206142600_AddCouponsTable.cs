using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddCouponsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestNumbers = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d35f845-ec42-4100-8270-47e040011fd1", "AQAAAAEAACcQAAAAEKbZnJImKi+RfxMsMzPk//Uy03R5WYhcGPBH6HXwFrRMFfUGuM5x5frs5bgvTlPdtA==", "af8affed-bc0e-43e0-8b4c-f11f148eff19" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e8bc5b-d68c-4b30-97c7-4fadb619a3fe", "AQAAAAEAACcQAAAAEHgde1QVaMrnU9QSCDIsiH+V4nFCAt5+OXTBJaUG35LpvQON+ljbHglv7AVBrjXejg==", "21ff94bc-9b43-41a2-8652-92608bd4e274" });
        }
    }
}
