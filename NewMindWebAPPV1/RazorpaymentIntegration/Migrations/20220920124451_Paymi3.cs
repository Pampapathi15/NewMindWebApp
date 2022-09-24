using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorpaymentIntegration.Migrations
{
    public partial class Paymi3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rzp_amount",
                table: "orderDetailss");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rzp_amount",
                table: "orderDetailss",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
