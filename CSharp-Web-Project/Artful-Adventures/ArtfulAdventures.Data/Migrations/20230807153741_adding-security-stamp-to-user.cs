using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtfulAdventures.Data.Migrations
{
    public partial class addingsecuritystamptouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "26cc6fc5-8174-4988-b8ef-652868caa726");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "2913c449-55f8-4343-b747-b0f2a9909469");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b04c7301-c0c6-4a05-a8ba-8bec078cb212"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b30c6ee9-6fcd-49cb-a301-b4c71335654b", "AQAAAAEAACcQAAAAEJHF9+ZOKmTSGNKADhGjTZ5L7wT0ciWIqvzFtFd65zD+QQZ2aT5Yq6lbCkfMKuV7aQ==", "SecurityStampTest01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1081e470-ea3d-4c50-a151-861892176093", "AQAAAAEAACcQAAAAEOncT1Pk4nJ4dbiTFhFqhmqf196XRcokype6B8JPFuhM64hDmZ2dsGlOnfjLWMfknA==", "SecurityStampAdmin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39a416e-1c54-415e-bccc-219d91ce3fc9", "AQAAAAEAACcQAAAAEETtmtvoShtGtj9NXeDLB6H6X5TG+Ysl1axUfPT/PSgsBs3w755wa/+myjsIQc9yUQ==", "SecurityStampTest02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b9de94c-0581-4c0e-b0b0-f3c76c542df6", "AQAAAAEAACcQAAAAEBZgpJvUptAM+0ybOOZ/VItIxA6wxs1miV3MaQWv6j8r4kCEZCLu0A3b6NJowGHBOA==", "SecurityStampTest03" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1374e658-515c-45f9-91e4-2d1ee96c958b", "AQAAAAEAACcQAAAAEJz5q9r94FcQhhrzALnriWyegF1k9yuh4LT7jpUsXmPleb+FntCJ5SOkju0QQjmWSQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aab2d74-8ae4-4cb4-ba64-0fa904a4834a", "AQAAAAEAACcQAAAAEPAOiMaCQpD3S1lripVGEqYxSYQKaB2nZEIYE5t7GQIDlqcm183jAVoMfqku1M7IMw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e56a2f6c-ae98-4e51-bd6e-3565fb9cb8e8", "AQAAAAEAACcQAAAAEA/YcLGcx2HIXz43t/NP5QjCwjE8epztMtHETs8M0fkZln+ypyTxBEbR9yJQPOhLuQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb0ab896-4294-46fb-ba2e-cd350f249891", "AQAAAAEAACcQAAAAEDtMmrbhOQHvkDwZSxGB22/+kZRLxopAxQRgzQPcC6dN0Nn7oeWteDpCKQNxu8q7cw==", null });
        }
    }
}
