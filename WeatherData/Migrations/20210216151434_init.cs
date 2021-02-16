using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enviornments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inside = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outside = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enviornments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enviornments_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humidities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirHumidity = table.Column<int>(type: "int", nullable: false),
                    EnviornmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humidities_Enviornments_EnviornmentId",
                        column: x => x.EnviornmentId,
                        principalTable: "Enviornments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temp = table.Column<float>(type: "real", nullable: false),
                    EnviornmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_Enviornments_EnviornmentId",
                        column: x => x.EnviornmentId,
                        principalTable: "Enviornments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Molds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskForMold = table.Column<float>(type: "real", nullable: false),
                    TemperatureId = table.Column<int>(type: "int", nullable: false),
                    HumidityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Molds_Humidities_HumidityId",
                        column: x => x.HumidityId,
                        principalTable: "Humidities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Molds_Temperatures_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Temperatures",
                columns: new[] { "Id", "EnviornmentId", "Temp" },
                values: new object[] { 1, 0, 0f });

            migrationBuilder.CreateIndex(
                name: "IX_Enviornments_DateId",
                table: "Enviornments",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Humidities_EnviornmentId",
                table: "Humidities",
                column: "EnviornmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_HumidityId",
                table: "Molds",
                column: "HumidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_TemperatureId",
                table: "Molds",
                column: "TemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_EnviornmentId",
                table: "Temperatures",
                column: "EnviornmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Molds");

            migrationBuilder.DropTable(
                name: "Humidities");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Enviornments");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
