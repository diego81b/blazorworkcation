using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Infrastructure.Migrations
{
    public partial class UpdateWeatherData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bracing", 20 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilly", 40 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cool", 60 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mild", 80 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warm", 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 28, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Cool", -8 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 29, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Warm", 48 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 30, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Sweltering", 43 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2019, 12, 31, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Scorching", 54 });

            migrationBuilder.UpdateData(
                table: "WeatherForecast",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2020, 1, 1, 16, 13, 19, 630, DateTimeKind.Local).AddTicks(1825), "Scorching", -8 });
        }
    }
}
