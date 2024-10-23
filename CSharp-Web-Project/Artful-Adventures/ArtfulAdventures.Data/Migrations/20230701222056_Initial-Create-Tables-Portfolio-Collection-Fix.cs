using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtfulAdventures.Data.Migrations
{
    public partial class InitialCreateTablesPortfolioCollectionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_ApplicationUserId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_ApplicationUserId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pictures");

            migrationBuilder.CreateTable(
                name: "ApplicationUsersPictures",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersPictures", x => new { x.UserId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersPictures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersPictures_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersPictures_PictureId",
                table: "ApplicationUsersPictures",
                column: "PictureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersPictures");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ApplicationUserId",
                table: "Pictures",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_ApplicationUserId",
                table: "Pictures",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
