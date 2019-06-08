using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class finalRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusyId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Clientid",
                table: "Packages",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BusyId",
                table: "Clients",
                column: "BusyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Busies_BusyId",
                table: "Clients",
                column: "BusyId",
                principalTable: "Busies",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Busies_BusyId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_Clientid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_Clientid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BusyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BusyId",
                table: "Clients");
        }
    }
}
