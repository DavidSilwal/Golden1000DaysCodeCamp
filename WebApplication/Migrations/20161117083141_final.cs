using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotherID1",
                table: "Examination",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examination_MotherID1",
                table: "Examination",
                column: "MotherID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Mothers_MotherID1",
                table: "Examination",
                column: "MotherID1",
                principalTable: "Mothers",
                principalColumn: "MotherID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examination_Mothers_MotherID1",
                table: "Examination");

            migrationBuilder.DropIndex(
                name: "IX_Examination_MotherID1",
                table: "Examination");

            migrationBuilder.DropColumn(
                name: "MotherID1",
                table: "Examination");
        }
    }
}
