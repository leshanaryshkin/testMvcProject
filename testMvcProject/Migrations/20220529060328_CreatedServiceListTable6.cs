using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class CreatedServiceListTable6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "added");

            migrationBuilder.CreateTable(
                name: "servicesToPos",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servicesToPos");

            migrationBuilder.CreateTable(
                name: "added",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }
    }
}
