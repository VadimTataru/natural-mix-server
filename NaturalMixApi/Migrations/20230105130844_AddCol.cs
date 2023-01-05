using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalMixApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "ComponentItems",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "ComponentItems");
        }
    }
}
