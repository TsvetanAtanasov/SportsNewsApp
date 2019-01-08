using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsNews.Data.Migrations
{
    public partial class ChangedUrlNamesInImagesAndVideos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Videos",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Videos",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "ImageUrl");
        }
    }
}
