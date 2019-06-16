using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class mth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ClientId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PackageId",
                table: "Clients",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Packages_PackageId",
                table: "Clients",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Packages_PackageId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PackageId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ClientId",
                table: "Packages",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
