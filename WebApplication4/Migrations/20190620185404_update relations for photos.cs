using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updaterelationsforphotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photos_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photos_MakeupArtist_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photos_Photographer_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photos_WeddingHall_PhotoId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PhotoId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MakeupArtist_PhotoId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Photographer_PhotoId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_WeddingHall_PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MakeupArtist_PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Photographer_PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "WeddingHall_PhotoId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ClientId",
                table: "Photos",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_OfferId",
                table: "Photos",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PackageId",
                table: "Photos",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PostId",
                table: "Photos",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Clients_ClientId",
                table: "Photos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Offers_OfferId",
                table: "Photos",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Packages_PackageId",
                table: "Photos",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Clients_ClientId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Offers_OfferId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Packages_PackageId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ClientId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_OfferId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PackageId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PostId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeupArtist_PhotoId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Photographer_PhotoId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingHall_PhotoId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PhotoId",
                table: "Clients",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MakeupArtist_PhotoId",
                table: "Clients",
                column: "MakeupArtist_PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Photographer_PhotoId",
                table: "Clients",
                column: "Photographer_PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_WeddingHall_PhotoId",
                table: "Clients",
                column: "WeddingHall_PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photos_PhotoId",
                table: "Clients",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photos_MakeupArtist_PhotoId",
                table: "Clients",
                column: "MakeupArtist_PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photos_Photographer_PhotoId",
                table: "Clients",
                column: "Photographer_PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photos_WeddingHall_PhotoId",
                table: "Clients",
                column: "WeddingHall_PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
