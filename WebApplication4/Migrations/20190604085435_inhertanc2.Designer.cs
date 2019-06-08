﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using WeddingGo.Models;

namespace WeddingGo.Migrations
{
    [DbContext(typeof(WeddingContext))]
    [Migration("20190604085435_inhertanc2")]
    partial class inhertanc2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeddingGo.Models.Busy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtelierId");

                    b.Property<DateTime>("Day");

                    b.Property<int?>("MakeupArtistId");

                    b.Property<int?>("PhotographerId");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Busies");
                });

            modelBuilder.Entity("WeddingGo.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("Phone");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Client");
                });

            modelBuilder.Entity("WeddingGo.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PostId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WeddingGo.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PostId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("WeddingGo.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtelierId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("MakeupArtistId");

                    b.Property<int?>("PhotographerId");

                    b.Property<int>("Read");

                    b.Property<string>("ReceiverId")
                        .IsRequired();

                    b.Property<int?>("UserId");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("WeddingGo.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtelierId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Image");

                    b.Property<int?>("MakeupArtistId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PhotographerId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("WeddingGo.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtelierId");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<int?>("MakeupArtistId");

                    b.Property<string>("Name")
                        .IsRequired();

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

            modelBuilder.Entity("WeddingGo.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Image");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WeddingGo.Models.Atelier", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("Atelier");

                    b.HasDiscriminator().HasValue("Atelier");
                });

            modelBuilder.Entity("WeddingGo.Models.MakeupArtist", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("MakeupArtist");

                    b.HasDiscriminator().HasValue("MakeupArtist");
                });

            modelBuilder.Entity("WeddingGo.Models.Photographer", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("Photographer");

                    b.HasDiscriminator().HasValue("Photographer");
                });

            modelBuilder.Entity("WeddingGo.Models.User", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("WeddingGo.Models.WeddingHall", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("WeddingHall");

                    b.HasDiscriminator().HasValue("WeddingHall");
                });

            modelBuilder.Entity("WeddingGo.Models.Busy", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier", "Atelier")
                        .WithMany("Busy")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist", "MakeupArtist")
                        .WithMany("Busy")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer", "Photographer")
                        .WithMany("Busy")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.WeddingHall", "WeddingHall")
                        .WithMany("Busy")
                        .HasForeignKey("WeddingHallId");
                });

            modelBuilder.Entity("WeddingGo.Models.Comment", b =>
                {
                    b.HasOne("WeddingGo.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("WeddingGo.Models.User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WeddingGo.Models.Like", b =>
                {
                    b.HasOne("WeddingGo.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId");

                    b.HasOne("WeddingGo.Models.User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WeddingGo.Models.Message", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier", "Atelier")
                        .WithMany("Messages")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist", "MakeupArtist")
                        .WithMany("Messages")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer", "Photographer")
                        .WithMany("Messages")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.HasOne("WeddingGo.Models.WeddingHall", "WeddingHall")
                        .WithMany("Messages")
                        .HasForeignKey("WeddingHallId");
                });

            modelBuilder.Entity("WeddingGo.Models.Offer", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier", "Atelier")
                        .WithMany("Offers")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist", "MakeupArtist")
                        .WithMany("Offers")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer", "Photographer")
                        .WithMany("Offers")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.WeddingHall", "WeddingHall")
                        .WithMany("Offers")
                        .HasForeignKey("WeddingHallId");
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
