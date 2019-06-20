using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class updatePhotoClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photo_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Clients_AtelierId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Clients_PhotographerId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Clients_WeddingHallId",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AtelierId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PhotographerId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_WeddingHallId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AtelierId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "WeddingHallId",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Clients",
                newName: "WeddingHall_PhotoId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

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
                name: "PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MakeupArtist_PhotoId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Photographer_PhotoId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "WeddingHall_PhotoId",
                table: "Clients",
                newName: "PhotoId");

            migrationBuilder.AddColumn<int>(
                name: "AtelierId",
                table: "Photo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotographerId",
                table: "Photo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingHallId",
                table: "Photo",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AtelierId",
                table: "Photo",
                column: "AtelierId",
                unique: true,
                filter: "[AtelierId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PhotographerId",
                table: "Photo",
                column: "PhotographerId",
                unique: true,
                filter: "[PhotographerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_WeddingHallId",
                table: "Photo",
                column: "WeddingHallId",
                unique: true,
                filter: "[WeddingHallId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PhotoId",
                table: "Clients",
                column: "PhotoId",
                unique: true,
                filter: "[PhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photo_PhotoId",
                table: "Clients",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Clients_AtelierId",
                table: "Photo",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Clients_PhotographerId",
                table: "Photo",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Clients_WeddingHallId",
                table: "Photo",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
