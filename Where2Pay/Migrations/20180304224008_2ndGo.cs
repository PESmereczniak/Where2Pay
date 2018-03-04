using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Where2Pay.Migrations
{
    public partial class _2ndGo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billers_Agents_AgentID",
                table: "Billers");

            migrationBuilder.DropIndex(
                name: "IX_Billers_AgentID",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "AgentID",
                table: "Billers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentID",
                table: "Billers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Billers_AgentID",
                table: "Billers",
                column: "AgentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Billers_Agents_AgentID",
                table: "Billers",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
