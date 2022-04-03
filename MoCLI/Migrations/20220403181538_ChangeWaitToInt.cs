using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoCLI.Migrations
{
    public partial class ChangeWaitToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastWait",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "LastWaitDays",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastWaitDays",
                table: "Cards");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LastWait",
                table: "Cards",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
