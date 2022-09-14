using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorpaymentIntegration.Migrations
{
    public partial class PayMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderDetailss",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    razorpay_payment_id = table.Column<string>(nullable: true),
                    razorpay_order_id = table.Column<string>(nullable: true),
                    razorpay_signature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetailss", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetailss");
        }
    }
}
