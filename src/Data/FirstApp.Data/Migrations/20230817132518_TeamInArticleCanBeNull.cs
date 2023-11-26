using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations
{
    public partial class TeamInArticleCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Teams_TeamId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Articles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Teams_TeamId",
                table: "Articles",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Teams_TeamId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Teams_TeamId",
                table: "Articles",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
