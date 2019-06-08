using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtelierId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeupArtistId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotographerId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingHallId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clientid",
                table: "Packages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Busies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AtelierId",
                table: "Posts",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MakeupArtistId",
                table: "Posts",
                column: "MakeupArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PhotographerId",
                table: "Posts",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WeddingHallId",
                table: "Posts",
                column: "WeddingHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Clientid",
                table: "Packages",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ClientId",
                table: "Messages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OfferId",
                table: "Clients",
                column: "OfferId");

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
                name: "FK_Clients_Offers_OfferId",
                table: "Clients",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Clients_AtelierId",
                table: "Posts",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Clients_MakeupArtistId",
                table: "Posts",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Clients_PhotographerId",
                table: "Posts",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Clients_WeddingHallId",
                table: "Posts",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Clients_ClientId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Offers_OfferId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_Clientid",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Clients_AtelierId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Clients_MakeupArtistId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Clients_PhotographerId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Clients_WeddingHallId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AtelierId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_MakeupArtistId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PhotographerId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_WeddingHallId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Packages_Clientid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ClientId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Clients_OfferId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Busies_ClientId",
                table: "Busies");

            migrationBuilder.DropColumn(
                name: "AtelierId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MakeupArtistId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WeddingHallId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Clientid",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Busies");
        }
    }
}
