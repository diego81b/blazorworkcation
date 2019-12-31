using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Infrastructure.Migrations
{
    public partial class AddWeatherForecastModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TemperatureC = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecast",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 28, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Cool", -8 },
                    { 2, new DateTime(2019, 12, 29, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Warm", 48 },
                    { 3, new DateTime(2019, 12, 30, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Sweltering", 43 },
                    { 4, new DateTime(2019, 12, 31, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Scorching", 54 },
                    { 5, new DateTime(2020, 1, 1, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Scorching", -8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecast");
        }
    }
}
