using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "onStock",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "onStock",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
