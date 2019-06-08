using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class inhertanc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
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
                name: "FK_Messages_Users_UserId",
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

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

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
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
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
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
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
    }
}
