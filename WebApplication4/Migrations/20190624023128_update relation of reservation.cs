using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updaterelationofreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtelierId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeupArtistId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotographerId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingHallId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AtelierId",
                table: "Reservations",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MakeupArtistId",
                table: "Reservations",
                column: "MakeupArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PhotographerId",
                table: "Reservations",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_WeddingHallId",
                table: "Reservations",
                column: "WeddingHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_AtelierId",
                table: "Reservations",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_MakeupArtistId",
                table: "Reservations",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_PhotographerId",
                table: "Reservations",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_WeddingHallId",
                table: "Reservations",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_AtelierId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_MakeupArtistId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_PhotographerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_WeddingHallId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AtelierId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MakeupArtistId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PhotographerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_WeddingHallId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AtelierId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MakeupArtistId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WeddingHallId",
                table: "Reservations");
        }
    }
}
