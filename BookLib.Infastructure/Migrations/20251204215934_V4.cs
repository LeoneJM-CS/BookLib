using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLib.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FavGenre1 = table.Column<int>(type: "int", nullable: false),
                    FavGenre2 = table.Column<int>(type: "int", nullable: false),
                    FavGenre3 = table.Column<int>(type: "int", nullable: false),
                    NoGenre1 = table.Column<int>(type: "int", nullable: false),
                    NoGenre2 = table.Column<int>(type: "int", nullable: false),
                    NoGenre3 = table.Column<int>(type: "int", nullable: false),
                    PrefAge = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
