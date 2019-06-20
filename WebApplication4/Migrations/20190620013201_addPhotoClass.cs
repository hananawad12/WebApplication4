using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class addPhotoClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Clients");

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

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ClientId",
                table: "Photo",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photo_PhotoId",
                table: "Clients",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photo_MakeupArtist_PhotoId",
                table: "Clients",
                column: "MakeupArtist_PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photo_Photographer_PhotoId",
                table: "Clients",
                column: "Photographer_PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Photo_WeddingHall_PhotoId",
                table: "Clients",
                column: "WeddingHall_PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photo_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photo_MakeupArtist_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photo_Photographer_PhotoId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Photo_WeddingHall_PhotoId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Photo");

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

            migrationBuilder.DropColumn(
                name: "WeddingHall_PhotoId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Clients",
                nullable: true);
        }
    }
}
