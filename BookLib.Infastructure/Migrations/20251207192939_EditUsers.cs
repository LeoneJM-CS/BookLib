using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLib.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavGenre1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavGenre2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavGenre3",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NoGenre1",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "NoGenre3",
                table: "Users",
                newName: "NoGenre");

            migrationBuilder.RenameColumn(
                name: "NoGenre2",
                table: "Users",
                newName: "FavGenre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoGenre",
                table: "Users",
                newName: "NoGenre3");

            migrationBuilder.RenameColumn(
                name: "FavGenre",
                table: "Users",
                newName: "NoGenre2");

            migrationBuilder.AddColumn<int>(
                name: "FavGenre1",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavGenre2",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavGenre3",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoGenre1",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
