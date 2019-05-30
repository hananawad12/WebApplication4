using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingGo.Migrations
{
    public partial class UpdateUsersPasswordandToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Ateliers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "WeddingHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "MakeupArtists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ateliers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Ateliers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Ateliers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "WeddingHalls");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "MakeupArtists");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Ateliers");

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "WeddingHalls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Photographers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "MakeupArtists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Ateliers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
