using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtfulAdventures.Data.Migrations
{
    public partial class addingmutepropertytouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MuteUntil",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "d7260595-5e72-4ab4-b8c9-44eb082432d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "981562f1-de24-4227-a2b9-3df2d49853ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1374e658-515c-45f9-91e4-2d1ee96c958b", "AQAAAAEAACcQAAAAEJz5q9r94FcQhhrzALnriWyegF1k9yuh4LT7jpUsXmPleb+FntCJ5SOkju0QQjmWSQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7aab2d74-8ae4-4cb4-ba64-0fa904a4834a", "AQAAAAEAACcQAAAAEPAOiMaCQpD3S1lripVGEqYxSYQKaB2nZEIYE5t7GQIDlqcm183jAVoMfqku1M7IMw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e56a2f6c-ae98-4e51-bd6e-3565fb9cb8e8", "AQAAAAEAACcQAAAAEA/YcLGcx2HIXz43t/NP5QjCwjE8epztMtHETs8M0fkZln+ypyTxBEbR9yJQPOhLuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb0ab896-4294-46fb-ba2e-cd350f249891", "AQAAAAEAACcQAAAAEDtMmrbhOQHvkDwZSxGB22/+kZRLxopAxQRgzQPcC6dN0Nn7oeWteDpCKQNxu8q7cw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MuteUntil",
                table: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e09351ef-6000-473c-b4d8-1e088cf888b0", "AQAAAAEAACcQAAAAEDKDoGP36zLtDNuRMVj1w8VRbvkPe0XlFj0Nt0vy46YJACjkUibd6zH0D3MpFGgIcg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "608affe4-75ba-487e-8a3a-fc138de073da", "AQAAAAEAACcQAAAAELXP2T8nYf3/Kz6Z1547VjSvY/78TaJgJEi1yu7gOn7N7srqFi8Gfuga2fdVFYpfrA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6502a18e-13a1-4d62-8137-b182b6ff4ac5", "AQAAAAEAACcQAAAAEGsm9/nKOLG1FfpoX/dXuGpXbdy6/hXR77MQLDcHw/C4WqpaBKoLLienLZtiylUWRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad6240b4-5fb7-4c42-a48f-d65bfb7d2968", "AQAAAAEAACcQAAAAEJ9vlrAkwOUvinPlTA0TjFU2wW/v4JgSGSBjKuV9sXjEx91ssdZeiifSxYpT30W9Xg==" });
        }
    }
}
