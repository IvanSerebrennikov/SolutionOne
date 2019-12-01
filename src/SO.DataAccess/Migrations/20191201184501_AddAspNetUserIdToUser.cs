using Microsoft.EntityFrameworkCore.Migrations;

namespace SO.DataAccess.Migrations
{
    public partial class AddAspNetUserIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "SolutionOneUsers",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolutionOneUsers_AspNetUserId",
                table: "SolutionOneUsers",
                column: "AspNetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SolutionOneUsers_AspNetUserId",
                table: "SolutionOneUsers");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "SolutionOneUsers");
        }
    }
}
