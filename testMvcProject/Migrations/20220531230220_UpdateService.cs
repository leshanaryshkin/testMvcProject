using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class UpdateService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActual",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActual",
                table: "Services");
        }
    }
}
