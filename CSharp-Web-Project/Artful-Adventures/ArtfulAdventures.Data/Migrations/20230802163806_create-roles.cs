using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtfulAdventures.Data.Migrations
{
    public partial class createroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), "7a8aac2f-6188-41a4-8ca5-51f9b5ff15be", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "58caf414-ce94-4b9f-8f51-b7678a99ed71", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"));
        }
    }
}
