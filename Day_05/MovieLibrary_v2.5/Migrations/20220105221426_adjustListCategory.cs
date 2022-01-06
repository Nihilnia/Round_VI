using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary_v2._5.Migrations
{
    public partial class adjustListCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_MovieID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieID",
                table: "Movies",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_MovieID",
                table: "Movies",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
