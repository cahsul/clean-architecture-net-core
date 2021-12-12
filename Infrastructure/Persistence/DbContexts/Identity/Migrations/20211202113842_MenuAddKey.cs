using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.DbContexts.Identity.Migrations
{
    public partial class MenuAddKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                schema: "Identity",
                table: "Menu",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuKey",
                schema: "Identity",
                table: "Menu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuKey",
                schema: "Identity",
                table: "Menu",
                column: "MenuKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Menu_MenuKey",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuKey",
                schema: "Identity",
                table: "Menu");

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                schema: "Identity",
                table: "Menu",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
