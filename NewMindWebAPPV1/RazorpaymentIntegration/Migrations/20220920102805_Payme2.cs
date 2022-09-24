using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorpaymentIntegration.Migrations
{
    public partial class Payme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rzp_amount",
                table: "orderDetailss",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rzp_amount",
                table: "orderDetailss");
        }
    }
}
