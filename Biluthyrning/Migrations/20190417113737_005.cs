using Microsoft.EntityFrameworkCore.Migrations;

namespace Biluthyrning.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cleaning",
                table: "Car",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Dispose",
                table: "Car",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Service",
                table: "Car",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cleaning",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Dispose",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Car");
        }
    }
}
