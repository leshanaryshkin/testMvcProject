using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class InitialTableFurniture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    costPrice = table.Column<int>(type: "int", nullable: false),
                    pricePerOnce = table.Column<int>(type: "int", nullable: false),
                    onStock = table.Column<int>(type: "int", nullable: false),
                    isActualPosition = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_Name",
                table: "Furnitures",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");
        }
    }
}
