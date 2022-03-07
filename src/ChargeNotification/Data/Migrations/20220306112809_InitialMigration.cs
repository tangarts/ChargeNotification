using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChargeNotification.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customernumber = table.Column<int>(type: "integer", nullable: false),
                    customername = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "gamecharge",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    totalcost = table.Column<int>(type: "integer", nullable: false),
                    chargedate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "gamecharge");
        }
    }
}
