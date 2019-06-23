using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updaterelationofreservationtable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_ReservationsId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Reservations_ReservationsId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Reservations_ReservationsId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ReservationsId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ReservationsId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ReservationsId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "OffersId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackagesId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OffersId",
                table: "Reservations",
                column: "OffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PackagesId",
                table: "Reservations",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UsersId",
                table: "Reservations",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Offers_OffersId",
                table: "Reservations",
                column: "OffersId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Packages_PackagesId",
                table: "Reservations",
                column: "PackagesId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_UsersId",
                table: "Reservations",
                column: "UsersId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Offers_OffersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Packages_PackagesId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_UsersId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_OffersId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PackagesId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UsersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "OffersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PackagesId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationsId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationsId",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationsId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ReservationsId",
                table: "Packages",
                column: "ReservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ReservationsId",
                table: "Offers",
                column: "ReservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReservationsId",
                table: "Clients",
                column: "ReservationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_ReservationsId",
                table: "Clients",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Reservations_ReservationsId",
                table: "Offers",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Reservations_ReservationsId",
                table: "Packages",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
