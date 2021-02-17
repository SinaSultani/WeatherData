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
                name: "Molds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskForMold = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enviornments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsideOrOutside = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    EnviornmentId = table.Column<int>(type: "int", nullable: false),
                    MoldId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Humidities_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temp = table.Column<float>(type: "real", nullable: false),
                    EnviornmentId = table.Column<int>(type: "int", nullable: false),
                    MoldId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Temperatures_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enviornments_DateId",
                table: "Enviornments",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Humidities_EnviornmentId",
                table: "Humidities",
                column: "EnviornmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Humidities_MoldId",
                table: "Humidities",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_EnviornmentId",
                table: "Temperatures",
                column: "EnviornmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_MoldId",
                table: "Temperatures",
                column: "MoldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humidities");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Enviornments");

            migrationBuilder.DropTable(
                name: "Molds");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
