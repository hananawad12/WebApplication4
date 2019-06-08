using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class inhertance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Ateliers_AtelierId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Busies_MakeupArtists_MakeupArtistId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Photographers_PhotographerId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Busies_WeddingHalls_WeddingHallId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Ateliers_AtelierId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MakeupArtists_MakeupArtistId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Photographers_PhotographerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_WeddingHalls_WeddingHallId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Ateliers_AtelierId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_MakeupArtists_MakeupArtistId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Photographers_PhotographerId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_WeddingHalls_WeddingHallId",
                table: "Offers");

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

            migrationBuilder.DropTable(
                name: "Ateliers");

            migrationBuilder.DropTable(
                name: "MakeupArtists");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingHalls",
                table: "WeddingHalls");

            migrationBuilder.RenameTable(
                name: "WeddingHalls",
                newName: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Clients_AtelierId",
                table: "Busies",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Clients_MakeupArtistId",
                table: "Busies",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Clients_PhotographerId",
                table: "Busies",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Clients_WeddingHallId",
                table: "Busies",
                column: "WeddingHallId",
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
                name: "FK_Messages_Clients_WeddingHallId",
                table: "Messages",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Clients_AtelierId",
                table: "Offers",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Clients_MakeupArtistId",
                table: "Offers",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Clients_PhotographerId",
                table: "Offers",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Clients_WeddingHallId",
                table: "Offers",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_AtelierId",
                table: "Packages",
                column: "AtelierId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_MakeupArtistId",
                table: "Packages",
                column: "MakeupArtistId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_PhotographerId",
                table: "Packages",
                column: "PhotographerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Clients_WeddingHallId",
                table: "Packages",
                column: "WeddingHallId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Clients_AtelierId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Clients_MakeupArtistId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Clients_PhotographerId",
                table: "Busies");

            migrationBuilder.DropForeignKey(
                name: "FK_Busies_Clients_WeddingHallId",
                table: "Busies");

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
                name: "FK_Messages_Clients_WeddingHallId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Clients_AtelierId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Clients_MakeupArtistId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Clients_PhotographerId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Clients_WeddingHallId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_AtelierId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_MakeupArtistId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_PhotographerId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Clients_WeddingHallId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "WeddingHalls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingHalls",
                table: "WeddingHalls",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Ateliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ateliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MakeupArtists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeupArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Ateliers_AtelierId",
                table: "Busies",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_MakeupArtists_MakeupArtistId",
                table: "Busies",
                column: "MakeupArtistId",
                principalTable: "MakeupArtists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_Photographers_PhotographerId",
                table: "Busies",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Busies_WeddingHalls_WeddingHallId",
                table: "Busies",
                column: "WeddingHallId",
                principalTable: "WeddingHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Ateliers_AtelierId",
                table: "Messages",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MakeupArtists_MakeupArtistId",
                table: "Messages",
                column: "MakeupArtistId",
                principalTable: "MakeupArtists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Photographers_PhotographerId",
                table: "Messages",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_WeddingHalls_WeddingHallId",
                table: "Messages",
                column: "WeddingHallId",
                principalTable: "WeddingHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Ateliers_AtelierId",
                table: "Offers",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_MakeupArtists_MakeupArtistId",
                table: "Offers",
                column: "MakeupArtistId",
                principalTable: "MakeupArtists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Photographers_PhotographerId",
                table: "Offers",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_WeddingHalls_WeddingHallId",
                table: "Offers",
                column: "WeddingHallId",
                principalTable: "WeddingHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
