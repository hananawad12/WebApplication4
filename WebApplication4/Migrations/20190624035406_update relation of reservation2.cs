using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updaterelationofreservation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Reservations_Clients_UsersId",
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
                name: "IX_Reservations_UsersId",
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
                name: "UsersId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "WeddingHallId",
                table: "Reservations",
                newName: "ClientsId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_WeddingHallId",
                table: "Reservations",
                newName: "IX_Reservations_ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientsId",
                table: "Reservations",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientsId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "Reservations",
                newName: "WeddingHallId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ClientsId",
                table: "Reservations",
                newName: "IX_Reservations_WeddingHallId");

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
                name: "UsersId",
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
                name: "IX_Reservations_UsersId",
                table: "Reservations",
                column: "UsersId");

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
                name: "FK_Reservations_Clients_UsersId",
                table: "Reservations",
                column: "UsersId",
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
    }
}
