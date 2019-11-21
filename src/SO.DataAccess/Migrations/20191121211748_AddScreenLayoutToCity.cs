using Microsoft.EntityFrameworkCore.Migrations;

namespace SO.DataAccess.Migrations
{
    public partial class AddScreenLayoutToCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScreenLayout_PercentageX",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScreenLayout_PercentageY",
                table: "Cities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenLayout_PercentageX",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ScreenLayout_PercentageY",
                table: "Cities");
        }
    }
}
