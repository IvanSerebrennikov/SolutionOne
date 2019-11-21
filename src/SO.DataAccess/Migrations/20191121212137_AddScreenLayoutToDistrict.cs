using Microsoft.EntityFrameworkCore.Migrations;

namespace SO.DataAccess.Migrations
{
    public partial class AddScreenLayoutToDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScreenLayout_PercentageX",
                table: "Districts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScreenLayout_PercentageY",
                table: "Districts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenLayout_PercentageX",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "ScreenLayout_PercentageY",
                table: "Districts");
        }
    }
}
