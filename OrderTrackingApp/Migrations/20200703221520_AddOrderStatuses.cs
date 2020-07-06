using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderTrackingApp.Migrations
{
    public partial class AddOrderStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new string[] { "Code", "Fullname", "HungarianTranslation" },
                values: new string[] { "WfPU", "Waiting for Pick Up", "Csomag a feladónál. Futárra vár." });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new string[] { "Code", "Fullname", "HungarianTranslation" },
                values: new string[] { "PU", "Picked Up", "Csomag a futárnál. Depóba tart." });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new string[] { "Code", "Fullname", "HungarianTranslation" },
                values: new string[] { "ID", "In Depot", "Depóban van. Kiszállításra vár." });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new string[] { "Code", "Fullname", "HungarianTranslation" },
                values: new string[] { "OD", "On Delivery", "Kiszállítás alatt áll. Célba tart." });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new string[] { "Code", "Fullname", "HungarianTranslation" },
                values: new string[] { "DD", "Delivered", "Kiszállítva" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
