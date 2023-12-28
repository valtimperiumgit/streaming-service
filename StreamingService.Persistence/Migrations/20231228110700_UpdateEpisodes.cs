using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEpisodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShowActors_TVShows_TVShowId",
                table: "TVShowActors");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowCreators_TVShows_TVShowId",
                table: "TVShowCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowGenres_TVShows_TVShowId",
                table: "TVShowGenres");

            migrationBuilder.RenameColumn(
                name: "TVShowId",
                table: "TVShowGenres",
                newName: "TvShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowGenres_TVShowId",
                table: "TVShowGenres",
                newName: "IX_TVShowGenres_TvShowId");

            migrationBuilder.RenameColumn(
                name: "TVShowId",
                table: "TVShowCreators",
                newName: "TvShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowCreators_TVShowId",
                table: "TVShowCreators",
                newName: "IX_TVShowCreators_TvShowId");

            migrationBuilder.RenameColumn(
                name: "TVShowId",
                table: "TVShowActors",
                newName: "TvShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowActors_TVShowId",
                table: "TVShowActors",
                newName: "IX_TVShowActors_TvShowId");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "TVShowEpisodes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowActors_TVShows_TvShowId",
                table: "TVShowActors",
                column: "TvShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowCreators_TVShows_TvShowId",
                table: "TVShowCreators",
                column: "TvShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowGenres_TVShows_TvShowId",
                table: "TVShowGenres",
                column: "TvShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShowActors_TVShows_TvShowId",
                table: "TVShowActors");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowCreators_TVShows_TvShowId",
                table: "TVShowCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowGenres_TVShows_TvShowId",
                table: "TVShowGenres");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "TVShowEpisodes");

            migrationBuilder.RenameColumn(
                name: "TvShowId",
                table: "TVShowGenres",
                newName: "TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowGenres_TvShowId",
                table: "TVShowGenres",
                newName: "IX_TVShowGenres_TVShowId");

            migrationBuilder.RenameColumn(
                name: "TvShowId",
                table: "TVShowCreators",
                newName: "TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowCreators_TvShowId",
                table: "TVShowCreators",
                newName: "IX_TVShowCreators_TVShowId");

            migrationBuilder.RenameColumn(
                name: "TvShowId",
                table: "TVShowActors",
                newName: "TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowActors_TvShowId",
                table: "TVShowActors",
                newName: "IX_TVShowActors_TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowActors_TVShows_TVShowId",
                table: "TVShowActors",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowCreators_TVShows_TVShowId",
                table: "TVShowCreators",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowGenres_TVShows_TVShowId",
                table: "TVShowGenres",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
