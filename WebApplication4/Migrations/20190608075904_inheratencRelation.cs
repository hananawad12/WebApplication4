using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class inheratencRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clients_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Clients_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_AtelierId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_MakeupArtistId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_PhotographerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_WeddingHallId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AtelierId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MakeupArtistId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_PhotographerId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_WeddingHallId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AtelierId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MakeupArtistId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "WeddingHallId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                newName: "IX_Likes_ClientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Clients_ClientId",
                table: "Comments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Clients_ClientId",
                table: "Likes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clients_ClientId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Clients_ClientId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ClientId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ClientId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddColumn<int>(
                name: "AtelierId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeupArtistId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotographerId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingHallId",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AtelierId",
                table: "Messages",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MakeupArtistId",
                table: "Messages",
                column: "MakeupArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PhotographerId",
                table: "Messages",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_WeddingHallId",
                table: "Messages",
                column: "WeddingHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Clients_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Clients_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_AtelierId",
                table: "Messages",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_MakeupArtistId",
                table: "Messages",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_PhotographerId",
                table: "Messages",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_WeddingHallId",
                table: "Messages",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
