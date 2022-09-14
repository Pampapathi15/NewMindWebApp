using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorpaymentIntegration.Migrations
{
    public partial class Pay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "razorpay_order_id",
                table: "orderDetailss");

            migrationBuilder.DropColumn(
                name: "razorpay_payment_id",
                table: "orderDetailss");

            migrationBuilder.AddColumn<string>(
                name: "rzp_orderid",
                table: "orderDetailss",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rzp_paymentid",
                table: "orderDetailss",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rzp_orderid",
                table: "orderDetailss");

            migrationBuilder.DropColumn(
                name: "rzp_paymentid",
                table: "orderDetailss");

            migrationBuilder.AddColumn<string>(
                name: "razorpay_order_id",
                table: "orderDetailss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "razorpay_payment_id",
                table: "orderDetailss",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
