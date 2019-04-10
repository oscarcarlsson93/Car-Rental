using Microsoft.EntityFrameworkCore.Migrations;

namespace Biluthyrning.Migrations
{
    public partial class ForRentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForRent",
                table: "Car",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForRent",
                table: "Car");
        }
    }
}
