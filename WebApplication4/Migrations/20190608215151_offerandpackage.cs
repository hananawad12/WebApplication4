using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class offerandpackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_Clientid",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "Clientid",
                table: "Packages",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_Clientid",
                table: "Packages",
                newName: "IX_Packages_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Packages",
                newName: "Clientid");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ClientId",
                table: "Packages",
                newName: "IX_Packages_Clientid");

            migrationBuilder.AlterColumn<int>(
                name: "Clientid",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
