using Microsoft.EntityFrameworkCore.Migrations;

namespace Biluthyrning.Migrations
{
    public partial class Events003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Car_CarId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Customer_CustomerId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Car_CarId",
                table: "Events",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Customer_CustomerId",
                table: "Events",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Car_CarId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Customer_CustomerId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Car_CarId",
                table: "Events",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Customer_CustomerId",
                table: "Events",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
