using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updaterelationofreservationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Reservations_ReservationId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Reservations_ReservationId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Packages",
                newName: "ReservationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ReservationId",
                table: "Packages",
                newName: "IX_Packages_ReservationsId");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Offers",
                newName: "ReservationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ReservationId",
                table: "Offers",
                newName: "IX_Offers_ReservationsId");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Clients",
                newName: "ReservationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients",
                newName: "IX_Clients_ReservationsId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ReservationsId",
                table: "Packages",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ReservationsId",
                table: "Packages",
                newName: "IX_Packages_ReservationId");

            migrationBuilder.RenameColumn(
                name: "ReservationsId",
                table: "Offers",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ReservationsId",
                table: "Offers",
                newName: "IX_Offers_ReservationId");

            migrationBuilder.RenameColumn(
                name: "ReservationsId",
                table: "Clients",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_ReservationsId",
                table: "Clients",
                newName: "IX_Clients_ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Reservations_ReservationId",
                table: "Offers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Reservations_ReservationId",
                table: "Packages",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
