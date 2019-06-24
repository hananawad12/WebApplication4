using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updaterelationofreservation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientsId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "Reservations",
                newName: "WeddingHallsId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ClientsId",
                table: "Reservations",
                newName: "IX_Reservations_WeddingHallsId");

            migrationBuilder.AddColumn<int>(
                name: "AteliersId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeupArtistsId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotographersId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AteliersId",
                table: "Reservations",
                column: "AteliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MakeupArtistsId",
                table: "Reservations",
                column: "MakeupArtistsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PhotographersId",
                table: "Reservations",
                column: "PhotographersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UsersId",
                table: "Reservations",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_AteliersId",
                table: "Reservations",
                column: "AteliersId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_MakeupArtistsId",
                table: "Reservations",
                column: "MakeupArtistsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_PhotographersId",
                table: "Reservations",
                column: "PhotographersId",
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
                name: "FK_Reservations_Clients_WeddingHallsId",
                table: "Reservations",
                column: "WeddingHallsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_AteliersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_MakeupArtistsId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_PhotographersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_UsersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_WeddingHallsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AteliersId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MakeupArtistsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PhotographersId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UsersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AteliersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MakeupArtistsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PhotographersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "WeddingHallsId",
                table: "Reservations",
                newName: "ClientsId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_WeddingHallsId",
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
    }
}
