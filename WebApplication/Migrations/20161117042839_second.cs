using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Patients",
                table: "CheckupsDone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patients",
                table: "Checkups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Patients",
                table: "CheckupsDone",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Patients",
                table: "Checkups",
                nullable: false);
        }
    }
}
