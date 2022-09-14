using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorpaymentIntegration.Migrations
{
    public partial class payme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MerchantOrders",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    RazorpayKey = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantOrders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequest",
                columns: table => new
                {
                    RequestID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequest", x => x.RequestID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchantOrders");

            migrationBuilder.DropTable(
                name: "PaymentRequest");
        }
    }
}
