using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCleanArch.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedIsFavoriteProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "MoviesUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AppUserId",
                table: "Movies",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AspNetUsers_AppUserId",
                table: "Movies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AspNetUsers_AppUserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_AppUserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "MoviesUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Movies");
        }
    }
}
