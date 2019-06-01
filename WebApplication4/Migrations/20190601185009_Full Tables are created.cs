using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class FullTablesarecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)

        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WeddingHalls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "WeddingHalls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Photographers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Photographers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Packages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MakeupArtists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "MakeupArtists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ateliers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Ateliers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Busies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtelierId = table.Column<int>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    MakeupArtistId = table.Column<int>(nullable: true),
                    PhotographerId = table.Column<int>(nullable: true),
                    WeddingHallId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Busies_Ateliers_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "Ateliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Busies_MakeupArtists_MakeupArtistId",
                        column: x => x.MakeupArtistId,
                        principalTable: "MakeupArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Busies_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Busies_WeddingHalls_WeddingHallId",
                        column: x => x.WeddingHallId,
                        principalTable: "WeddingHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtelierId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MakeupArtistId = table.Column<int>(nullable: true),
                    PhotographerId = table.Column<int>(nullable: true),
                    Read = table.Column<int>(nullable: false),
                    ReceiverId = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    WeddingHallId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Ateliers_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "Ateliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_MakeupArtists_MakeupArtistId",
                        column: x => x.MakeupArtistId,
                        principalTable: "MakeupArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_WeddingHalls_WeddingHallId",
                        column: x => x.WeddingHallId,
                        principalTable: "WeddingHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtelierId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    MakeupArtistId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PhotographerId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    WeddingHallId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Ateliers_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "Ateliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_MakeupArtists_MakeupArtistId",
                        column: x => x.MakeupArtistId,
                        principalTable: "MakeupArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_WeddingHalls_WeddingHallId",
                        column: x => x.WeddingHallId,
                        principalTable: "WeddingHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Busies_AtelierId",
                table: "Busies",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Busies_MakeupArtistId",
                table: "Busies",
                column: "MakeupArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Busies_PhotographerId",
                table: "Busies",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Busies_WeddingHallId",
                table: "Busies",
                column: "WeddingHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AtelierId",
                table: "Offers",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MakeupArtistId",
                table: "Offers",
                column: "MakeupArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PhotographerId",
                table: "Offers",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_WeddingHallId",
                table: "Offers",
                column: "WeddingHallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Busies");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WeddingHalls",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "WeddingHalls",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Photographers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Photographers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MakeupArtists",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "MakeupArtists",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ateliers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Ateliers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
