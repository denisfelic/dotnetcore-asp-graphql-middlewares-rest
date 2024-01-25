using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetcore_asp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharInTodoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "completed",
                table: "Todos",
                newName: "Completed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "Todos",
                newName: "completed");
        }
    }
}
