using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class SeparateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Clients_AtelierId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_MakeupArtists_Clients_MakeupArtistId",
                table: "MakeupArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Photographers_Clients_PhotographerId",
                table: "Photographers");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHalls_Clients_WeddingHallId",
                table: "WeddingHalls");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_WeddingHalls_WeddingHallId",
                table: "WeddingHalls");

            migrationBuilder.DropIndex(
                name: "IX_Photographers_PhotographerId",
                table: "Photographers");

            migrationBuilder.DropIndex(
                name: "IX_MakeupArtists_MakeupArtistId",
                table: "MakeupArtists");

            migrationBuilder.DropIndex(
                name: "IX_Ateliers_AtelierId",
                table: "Ateliers");

            migrationBuilder.RenameColumn(
                name: "WeddingHallId",
                table: "WeddingHalls",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "PhotographerId",
                table: "Photographers",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Nmae",
                table: "Packages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Packages",
                newName: "WeddingHallId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ClientId",
                table: "Packages",
                newName: "IX_Packages_WeddingHallId");

            migrationBuilder.RenameColumn(
                name: "MakeupArtistId",
                table: "MakeupArtists",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "AtelierId",
                table: "Ateliers",
                newName: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "WeddingHalls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "WeddingHalls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Photographers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Photographers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtelierId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeupArtistId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotographerId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "MakeupArtists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "MakeupArtists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ateliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ateliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Ateliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ateliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Ateliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Ateliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_AtelierId",
                table: "Packages",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_MakeupArtistId",
                table: "Packages",
                column: "MakeupArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PhotographerId",
                table: "Packages",
                column: "PhotographerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Ateliers_AtelierId",
                table: "Packages",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_MakeupArtists_MakeupArtistId",
                table: "Packages",
                column: "MakeupArtistId",
                principalTable: "MakeupArtists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Photographers_PhotographerId",
                table: "Packages",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_WeddingHalls_WeddingHallId",
                table: "Packages",
                column: "WeddingHallId",
                principalTable: "WeddingHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Ateliers_AtelierId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_MakeupArtists_MakeupArtistId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Photographers_PhotographerId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_WeddingHalls_WeddingHallId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_AtelierId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_MakeupArtistId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PhotographerId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "AtelierId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "MakeupArtistId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Ateliers");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "WeddingHalls",
                newName: "WeddingHallId");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Photographers",
                newName: "PhotographerId");

            migrationBuilder.RenameColumn(
                name: "WeddingHallId",
                table: "Packages",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Packages",
                newName: "Nmae");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_WeddingHallId",
                table: "Packages",
                newName: "IX_Packages_ClientId");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "MakeupArtists",
                newName: "MakeupArtistId");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Ateliers",
                newName: "AtelierId");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHalls_WeddingHallId",
                table: "WeddingHalls",
                column: "WeddingHallId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photographers_PhotographerId",
                table: "Photographers",
                column: "PhotographerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MakeupArtists_MakeupArtistId",
                table: "MakeupArtists",
                column: "MakeupArtistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ateliers_AtelierId",
                table: "Ateliers",
                column: "AtelierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Clients_AtelierId",
                table: "Ateliers",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MakeupArtists_Clients_MakeupArtistId",
                table: "MakeupArtists",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_ClientId",
                table: "Packages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photographers_Clients_PhotographerId",
                table: "Photographers",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHalls_Clients_WeddingHallId",
                table: "WeddingHalls",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
