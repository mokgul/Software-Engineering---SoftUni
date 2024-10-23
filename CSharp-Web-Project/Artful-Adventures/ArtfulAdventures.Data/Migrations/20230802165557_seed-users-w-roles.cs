using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtfulAdventures.Data.Migrations
{
    public partial class seeduserswroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "c0e19566-060a-41b5-a055-57f026041f1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "fdc25e60-4e41-49f4-bd84-31f5ed7f6336");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "Bio", "CityName", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Url", "UserName" },
                values: new object[,]
                {
                    { new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212"), null, 0, null, null, "e09351ef-6000-473c-b4d8-1e088cf888b0", "test-user-01@test.art", false, false, null, null, null, "TEST-USER-01", "AQAAAAEAACcQAAAAEDKDoGP36zLtDNuRMVj1w8VRbvkPe0XlFj0Nt0vy46YJACjkUibd6zH0D3MpFGgIcg==", null, false, null, false, null, "test-user-01" },
                    { new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"), null, 0, null, null, "608affe4-75ba-487e-8a3a-fc138de073da", "admin@art-adv.com", false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAELXP2T8nYf3/Kz6Z1547VjSvY/78TaJgJEi1yu7gOn7N7srqFi8Gfuga2fdVFYpfrA==", null, false, null, false, null, "admin" },
                    { new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"), null, 0, null, null, "6502a18e-13a1-4d62-8137-b182b6ff4ac5", "test-user-02@test.art", false, false, null, null, null, "TEST-USER-02", "AQAAAAEAACcQAAAAEGsm9/nKOLG1FfpoX/dXuGpXbdy6/hXR77MQLDcHw/C4WqpaBKoLLienLZtiylUWRw==", null, false, null, false, null, "test-user-02" },
                    { new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"), null, 0, null, null, "ad6240b4-5fb7-4c42-a48f-d65bfb7d2968", "test-user-03@test.art", false, false, null, null, null, "TEST-USER-03", "AQAAAAEAACcQAAAAEJ9vlrAkwOUvinPlTA0TjFU2wW/v4JgSGSBjKuV9sXjEx91ssdZeiifSxYpT30W9Xg==", null, false, null, false, null, "test-user-03" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212") },
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb") },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a") },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "7a8aac2f-6188-41a4-8ca5-51f9b5ff15be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "58caf414-ce94-4b9f-8f51-b7678a99ed71");
        }
    }
}
