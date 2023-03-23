using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaporStore.Migrations
{
    public partial class initial20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesTags_Games_GameId",
                table: "GamesTags");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesTags_Tags_TagId",
                table: "GamesTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesTags",
                table: "GamesTags");

            migrationBuilder.RenameTable(
                name: "GamesTags",
                newName: "GameTags");

            migrationBuilder.RenameIndex(
                name: "IX_GamesTags_TagId",
                table: "GameTags",
                newName: "IX_GameTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameTags",
                table: "GameTags",
                columns: new[] { "GameId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameTags_Games_GameId",
                table: "GameTags",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTags_Tags_TagId",
                table: "GameTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameTags_Games_GameId",
                table: "GameTags");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTags_Tags_TagId",
                table: "GameTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameTags",
                table: "GameTags");

            migrationBuilder.RenameTable(
                name: "GameTags",
                newName: "GamesTags");

            migrationBuilder.RenameIndex(
                name: "IX_GameTags_TagId",
                table: "GamesTags",
                newName: "IX_GamesTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesTags",
                table: "GamesTags",
                columns: new[] { "GameId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamesTags_Games_GameId",
                table: "GamesTags",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesTags_Tags_TagId",
                table: "GamesTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
