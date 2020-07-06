using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderTrackingApp.Migrations
{
    public partial class DeleteWrongData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM OrderStatus", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
