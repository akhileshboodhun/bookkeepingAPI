using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookkeepingAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashbook",
                columns: table => new
                {
                    receipt_no = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    details = table.Column<string>(nullable: true),
                    salesCount = table.Column<int>(nullable: false),
                    cashInHand = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashbook", x => x.receipt_no);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    contact_no = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contact_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.contact_no);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    item_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    item_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.item_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cashbook");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
