using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherData.Migrations
{
    public partial class SeedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "TimeStamp" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 17, 15, 40, 27, 173, DateTimeKind.Local).AddTicks(2683) },
                    { 2, new DateTime(2021, 2, 17, 15, 40, 27, 182, DateTimeKind.Local).AddTicks(67) },
                    { 3, new DateTime(2021, 2, 17, 15, 40, 27, 182, DateTimeKind.Local).AddTicks(225) },
                    { 4, new DateTime(2021, 2, 17, 15, 40, 27, 182, DateTimeKind.Local).AddTicks(233) }
                });

            migrationBuilder.InsertData(
                table: "Enviornments",
                columns: new[] { "Id", "DateId", "InsideOrOutside" },
                values: new object[,]
                {
                    { 1, 1, "Outside" },
                    { 2, 2, "Inside" },
                    { 3, 3, "Outside" },
                    { 4, 4, "Inside" }
                });

            migrationBuilder.InsertData(
                table: "Humidities",
                columns: new[] { "Id", "AirHumidity", "EnviornmentId", "MoldId" },
                values: new object[,]
                {
                    { 1, 85, 1, null },
                    { 2, 39, 2, null },
                    { 3, 73, 3, null },
                    { 4, 35, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Temperatures",
                columns: new[] { "Id", "EnviornmentId", "MoldId", "Temp" },
                values: new object[,]
                {
                    { 1, 1, null, -5f },
                    { 2, 2, null, 25f },
                    { 3, 3, null, -2f },
                    { 4, 4, null, 22f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
