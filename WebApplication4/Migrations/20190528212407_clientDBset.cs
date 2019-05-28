using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class clientDBset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Client_AtelierId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_MakeupArtists_Client_MakeupArtistId",
                table: "MakeupArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Client_ClientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Photographers_Client_PhotographerId",
                table: "Photographers");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHalls_Client_WeddingHallId",
                table: "WeddingHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Clients_AtelierId",
                table: "Ateliers",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MakeupArtists_Clients_MakeupArtistId",
                table: "MakeupArtists",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photographers_Clients_PhotographerId",
                table: "Photographers",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHalls_Clients_WeddingHallId",
                table: "WeddingHalls",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Clients_AtelierId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_MakeupArtists_Clients_MakeupArtistId",
                table: "MakeupArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Photographers_Clients_PhotographerId",
                table: "Photographers");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHalls_Clients_WeddingHallId",
                table: "WeddingHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Client_AtelierId",
                table: "Ateliers",
                column: "AtelierId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MakeupArtists_Client_MakeupArtistId",
                table: "MakeupArtists",
                column: "MakeupArtistId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Client_ClientId",
                table: "Packages",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photographers_Client_PhotographerId",
                table: "Photographers",
                column: "PhotographerId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHalls_Client_WeddingHallId",
                table: "WeddingHalls",
                column: "WeddingHallId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
