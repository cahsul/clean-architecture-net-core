using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.DbContexts.Identity.Migrations
{
    public partial class MenuAddAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuAction",
                schema: "Identity",
                table: "Menu",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuAction",
                schema: "Identity",
                table: "Menu");
        }
    }
}
