using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class WorkingwOrders509 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_Orders_OrderID",
                table: "OrderContents");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_ServicesToPos_ServicesListID",
                table: "OrderContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderContents",
                table: "OrderContents");

            migrationBuilder.DropIndex(
                name: "IX_OrderContents_OrderID",
                table: "OrderContents");

            migrationBuilder.DropIndex(
                name: "IX_OrderContents_ServicesListID",
                table: "OrderContents");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "OrderContents");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderContents");

            migrationBuilder.RenameColumn(
                name: "ServicesListID",
                table: "OrderContents",
                newName: "order_ID");

            migrationBuilder.AlterColumn<int>(
                name: "order_ID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderContents",
                table: "OrderContents",
                column: "order_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderContents",
                table: "OrderContents");

            migrationBuilder.RenameColumn(
                name: "order_ID",
                table: "OrderContents",
                newName: "ServicesListID");

            migrationBuilder.AlterColumn<int>(
                name: "ServicesListID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderContents",
                table: "OrderContents",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_OrderID",
                table: "OrderContents",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_ServicesListID",
                table: "OrderContents",
                column: "ServicesListID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_Orders_OrderID",
                table: "OrderContents",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_ServicesToPos_ServicesListID",
                table: "OrderContents",
                column: "ServicesListID",
                principalTable: "ServicesToPos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
