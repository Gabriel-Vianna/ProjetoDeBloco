using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMusic.Infrastructure.Migrations
{
    public partial class musicstyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusicStyle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicStyle",
                table: "Users");
        }
    }
}
