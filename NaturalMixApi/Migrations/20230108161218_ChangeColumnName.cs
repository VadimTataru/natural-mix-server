using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalMixApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naturalness",
                table: "ComponentItems",
                newName: "Safety");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Safety",
                table: "ComponentItems",
                newName: "Naturalness");
        }
    }
}
