using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetcore_asp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarkers_Bookmarkers_BookmarkerId",
                table: "Bookmarkers");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarkers_Bookmarkers_BookmarkerId",
                table: "Bookmarkers",
                column: "BookmarkerId",
                principalTable: "Bookmarkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarkers_Bookmarkers_BookmarkerId",
                table: "Bookmarkers");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarkers_Bookmarkers_BookmarkerId",
                table: "Bookmarkers",
                column: "BookmarkerId",
                principalTable: "Bookmarkers",
                principalColumn: "Id");
        }
    }
}
