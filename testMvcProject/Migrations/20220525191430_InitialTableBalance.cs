using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class InitialTableBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currencyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    currencyBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_telephone",
                table: "Users",
                column: "telephone",
                unique: true,
                filter: "[telephone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_currencyName",
                table: "Balances",
                column: "currencyName",
                unique: true,
                filter: "[currencyName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Users_telephone",
                table: "Users");
        }
    }
}
