using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class CreatedServiceListTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "added",
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
                name: "added");
        }
    }
}
