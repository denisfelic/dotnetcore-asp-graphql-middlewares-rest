using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetcore_asp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAtCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookmarkers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Bookmarkers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bookmarkers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Bookmarkers");
        }
    }
}
