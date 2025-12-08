using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLib.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditUsers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrefAge",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrefAge",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
