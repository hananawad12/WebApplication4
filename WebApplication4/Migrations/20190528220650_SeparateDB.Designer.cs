﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WeddingGo.Models;

namespace WeddingGo.Migrations
{
    [DbContext(typeof(WeddingContext))]
    [Migration("20190528220650_SeparateDB")]
    partial class SeparateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeddingGo.Models.Atelier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("Password");

                    b.Property<int>("Phone");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Ateliers");
                });

            modelBuilder.Entity("WeddingGo.Models.MakeupArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("Password");

                    b.Property<int>("Phone");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.ToTable("MakeupArtists");
                });

            modelBuilder.Entity("WeddingGo.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtelierId");

                    b.Property<string>("Details");

                    b.Property<int?>("MakeupArtistId");

                    b.Property<string>("Name");

                    b.Property<int?>("PhotographerId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("WeddingGo.Models.Photographer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("Password");

                    b.Property<int>("Phone");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Photographers");
                });

            modelBuilder.Entity("WeddingGo.Models.WeddingHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("Password");

                    b.Property<int>("Phone");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.ToTable("WeddingHalls");
                });

            modelBuilder.Entity("WeddingGo.Models.Package", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier", "Atelier")
                        .WithMany("Packages")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist", "MakeupArtist")
                        .WithMany("Packages")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer", "Photographer")
                        .WithMany("Packages")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.WeddingHall", "WeddingHall")
                        .WithMany("Packages")
                        .HasForeignKey("WeddingHallId");
                });
#pragma warning restore 612, 618
        }
    }
}