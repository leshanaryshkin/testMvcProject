using Microsoft.EntityFrameworkCore.Migrations;

namespace testMvcProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersLoginsPasswords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Is_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLoginsPasswords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersLoginsPasswords_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersLoginsPasswords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
