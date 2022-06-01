using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class WorkingwOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_OrderID",
                table: "OrderContents",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_Orders_OrderID",
                table: "OrderContents",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_Orders_OrderID",
                table: "OrderContents");

            migrationBuilder.DropIndex(
                name: "IX_OrderContents_OrderID",
                table: "OrderContents");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderContents");
        }
    }
}
