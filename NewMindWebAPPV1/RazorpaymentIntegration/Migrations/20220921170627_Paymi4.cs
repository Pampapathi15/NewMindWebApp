using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorpaymentIntegration.Migrations
{
    public partial class Paymi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "orderDetailss",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "orderDetailss",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "orderDetailss",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhoneNumber",
                table: "orderDetailss",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "orderDetailss");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "orderDetailss");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "orderDetailss");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "orderDetailss");
        }
    }
}
