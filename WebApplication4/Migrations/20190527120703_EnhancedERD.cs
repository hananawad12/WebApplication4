using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class EnhancedERD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_MakeupArtists_MakeupArtistId",
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

            migrationBuilder.RenameColumn(
                name: "MakeupArtistId",
                table: "Packages",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_MakeupArtistId",
                table: "Packages",
                newName: "IX_Packages_ClientId");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "MakeupArtists",
                newName: "MakeupArtistId");

            migrationBuilder.CreateTable(
                name: "Client",
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
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ateliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtelierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ateliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ateliers_Client_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotographerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographers_Client_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeddingHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeddingHallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeddingHalls_Client_WeddingHallId",
                        column: x => x.WeddingHallId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Photographers_PhotographerId",
                table: "Photographers",
                column: "PhotographerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHalls_WeddingHallId",
                table: "WeddingHalls",
                column: "WeddingHallId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MakeupArtists_Client_MakeupArtistId",
                table: "MakeupArtists",
                column: "MakeupArtistId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Client_ClientId",
                table: "Packages",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MakeupArtists_Client_MakeupArtistId",
                table: "MakeupArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Client_ClientId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Ateliers");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropTable(
                name: "WeddingHalls");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_MakeupArtists_MakeupArtistId",
                table: "MakeupArtists");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Packages",
                newName: "MakeupArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ClientId",
                table: "Packages",
                newName: "IX_Packages_MakeupArtistId");

            migrationBuilder.RenameColumn(
                name: "MakeupArtistId",
                table: "MakeupArtists",
                newName: "Rating");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_MakeupArtists_MakeupArtistId",
                table: "Packages",
                column: "MakeupArtistId",
                principalTable: "MakeupArtists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
