using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderTrackingApp.Migrations
{
    public partial class UpdateItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Order_OrderId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_OrderId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Item",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_OrderId",
                table: "Item",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Order_OrderId",
                table: "Item",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
