using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class removeimageattributefrompackageandpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Packages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Packages",
                nullable: true);
        }
    }
}
