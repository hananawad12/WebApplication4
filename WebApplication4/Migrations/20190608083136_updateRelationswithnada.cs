using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updateRelationswithnada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Clients_ClientId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_Clientid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_Clientid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Busies_ClientId",
                table: "Busies");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Busies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Busies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Clientid",
                table: "Packages",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_Busies_ClientId",
                table: "Busies",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Clients_ClientId",
                table: "Busies",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_Clientid",
                table: "Packages",
                column: "Clientid",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
