using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class InitialCreate2314 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Process",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicesListID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WindowID",
                table: "OrderContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_ServicesListID",
                table: "OrderContents",
                column: "ServicesListID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_WindowID",
                table: "OrderContents",
                column: "WindowID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_ServicesToPos_ServicesListID",
                table: "OrderContents",
                column: "ServicesListID",
                principalTable: "ServicesToPos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_Windows_WindowID",
                table: "OrderContents",
                column: "WindowID",
                principalTable: "Windows",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_ServicesToPos_ServicesListID",
                table: "OrderContents");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_Windows_WindowID",
                table: "OrderContents");

            migrationBuilder.DropIndex(
                name: "IX_OrderContents_ServicesListID",
                table: "OrderContents");

            migrationBuilder.DropIndex(
                name: "IX_OrderContents_WindowID",
                table: "OrderContents");

            migrationBuilder.DropColumn(
                name: "Process",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ServicesListID",
                table: "OrderContents");

            migrationBuilder.DropColumn(
                name: "WindowID",
                table: "OrderContents");
        }
    }
}
