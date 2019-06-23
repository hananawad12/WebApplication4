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
    [Migration("20190623212513_add reservation tablle")]
    partial class addreservationtablle
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

                    b.Property<int?>("BusyId");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OfferId");

                    b.Property<int?>("PackageId");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("Phone");

                    b.Property<int?>("Rating");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BusyId");

                    b.HasIndex("OfferId");

                    b.HasIndex("PackageId");

                    b.ToTable("Clients");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Client");
                });

            modelBuilder.Entity("WeddingGo.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WeddingGo.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PostId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("WeddingGo.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Read");

                    b.Property<string>("ReceiverId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

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

                    b.Property<int?>("MakeupArtistId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PhotographerId");

                    b.Property<int?>("ReservationId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("ReservationId");

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

                    b.Property<int?>("MakeupArtistId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PhotographerId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ReservationId");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("WeddingGo.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<int?>("OfferId");

                    b.Property<int?>("PackageId");

                    b.Property<int?>("PostId");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OfferId");

                    b.HasIndex("PackageId");

                    b.HasIndex("PostId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WeddingGo.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtelierId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("MakeupArtistId");

                    b.Property<int?>("PhotographerId");

                    b.Property<int?>("WeddingHallId");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("MakeupArtistId");

                    b.HasIndex("PhotographerId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WeddingGo.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WeddingGo.Models.Atelier", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("Ateliers");

                    b.HasDiscriminator().HasValue("Atelier");
                });

            modelBuilder.Entity("WeddingGo.Models.MakeupArtist", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("MakeupArtists");

                    b.HasDiscriminator().HasValue("MakeupArtist");
                });

            modelBuilder.Entity("WeddingGo.Models.Photographer", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("Photographers");

                    b.HasDiscriminator().HasValue("Photographer");
                });

            modelBuilder.Entity("WeddingGo.Models.User", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");

                    b.Property<int?>("ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("WeddingGo.Models.WeddingHall", b =>
                {
                    b.HasBaseType("WeddingGo.Models.Client");


                    b.ToTable("WeddingHalls");

                    b.HasDiscriminator().HasValue("WeddingHall");
                });

            modelBuilder.Entity("WeddingGo.Models.Busy", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier")
                        .WithMany("Busies")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist")
                        .WithMany("Busies")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer")
                        .WithMany("Busies")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.WeddingHall")
                        .WithMany("Busies")
                        .HasForeignKey("WeddingHallId");
                });

            modelBuilder.Entity("WeddingGo.Models.Client", b =>
                {
                    b.HasOne("WeddingGo.Models.Busy")
                        .WithMany("Clients")
                        .HasForeignKey("BusyId");

                    b.HasOne("WeddingGo.Models.Offer")
                        .WithMany("Clients")
                        .HasForeignKey("OfferId");

                    b.HasOne("WeddingGo.Models.Package")
                        .WithMany("Clients")
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("WeddingGo.Models.Comment", b =>
                {
                    b.HasOne("WeddingGo.Models.Client", "Client")
                        .WithMany("Comments")
                        .HasForeignKey("ClientId");

                    b.HasOne("WeddingGo.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("WeddingGo.Models.Like", b =>
                {
                    b.HasOne("WeddingGo.Models.Client", "Client")
                        .WithMany("Likes")
                        .HasForeignKey("ClientId");

                    b.HasOne("WeddingGo.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("WeddingGo.Models.Message", b =>
                {
                    b.HasOne("WeddingGo.Models.Client", "Client")
                        .WithMany("Messages")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("WeddingGo.Models.Offer", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier")
                        .WithMany("Offers")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist")
                        .WithMany("Offers")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer")
                        .WithMany("Offers")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.Reservation")
                        .WithMany("Offers")
                        .HasForeignKey("ReservationId");

                    b.HasOne("WeddingGo.Models.WeddingHall")
                        .WithMany("Offers")
                        .HasForeignKey("WeddingHallId");
                });

            modelBuilder.Entity("WeddingGo.Models.Package", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier")
                        .WithMany("Packages")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist")
                        .WithMany("Packages")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer")
                        .WithMany("Packages")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.Reservation")
                        .WithMany("Packages")
                        .HasForeignKey("ReservationId");

                    b.HasOne("WeddingGo.Models.WeddingHall")
                        .WithMany("Packages")
                        .HasForeignKey("WeddingHallId");
                });

            modelBuilder.Entity("WeddingGo.Models.Photo", b =>
                {
                    b.HasOne("WeddingGo.Models.Client", "Client")
                        .WithMany("Photos")
                        .HasForeignKey("ClientId");

                    b.HasOne("WeddingGo.Models.Offer")
                        .WithMany("Photos")
                        .HasForeignKey("OfferId");

                    b.HasOne("WeddingGo.Models.Package")
                        .WithMany("Photos")
                        .HasForeignKey("PackageId");

                    b.HasOne("WeddingGo.Models.Post")
                        .WithMany("Photos")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("WeddingGo.Models.Post", b =>
                {
                    b.HasOne("WeddingGo.Models.Atelier")
                        .WithMany("Posts")
                        .HasForeignKey("AtelierId");

                    b.HasOne("WeddingGo.Models.MakeupArtist")
                        .WithMany("Posts")
                        .HasForeignKey("MakeupArtistId");

                    b.HasOne("WeddingGo.Models.Photographer")
                        .WithMany("Posts")
                        .HasForeignKey("PhotographerId");

                    b.HasOne("WeddingGo.Models.WeddingHall")
                        .WithMany("Posts")
                        .HasForeignKey("WeddingHallId");
                });

            modelBuilder.Entity("WeddingGo.Models.User", b =>
                {
                    b.HasOne("WeddingGo.Models.Reservation")
                        .WithMany("Users")
                        .HasForeignKey("ReservationId");
                });
#pragma warning restore 612, 618
        }
    }
}
