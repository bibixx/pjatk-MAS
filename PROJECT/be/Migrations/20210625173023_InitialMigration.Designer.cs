﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mas_project.Models;

namespace mas_project.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210625173023_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mas_project.Models.Advert", b =>
                {
                    b.Property<int>("IdAdvert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("IdSeller")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UserIdUser")
                        .HasColumnType("int");

                    b.HasKey("IdAdvert");

                    b.HasIndex("IdSeller");

                    b.HasIndex("UserIdUser");

                    b.ToTable("Adverts");

                    b.HasData(
                        new
                        {
                            IdAdvert = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 1",
                            IdSeller = 2,
                            IsActive = true
                        });
                });

            modelBuilder.Entity("mas_project.Models.AdvertGameCanBeTradedFor", b =>
                {
                    b.Property<int>("IdAdvertGameCanBeTradedFor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAdvert")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.HasKey("IdAdvertGameCanBeTradedFor");

                    b.HasIndex("IdAdvert");

                    b.ToTable("AdvertGameCanBeTradedFors");

                    b.HasData(
                        new
                        {
                            IdAdvertGameCanBeTradedFor = 1,
                            IdAdvert = 1,
                            IdGame = 2
                        });
                });

            modelBuilder.Entity("mas_project.Models.AdvertGameSubject", b =>
                {
                    b.Property<int>("IdAdvertGameSubject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAdvert")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.HasKey("IdAdvertGameSubject");

                    b.HasIndex("IdAdvert");

                    b.ToTable("AdvertGameSubjects");

                    b.HasData(
                        new
                        {
                            IdAdvertGameSubject = 1,
                            IdAdvert = 1,
                            IdGame = 1
                        });
                });

            modelBuilder.Entity("mas_project.Models.Game", b =>
                {
                    b.Property<int>("IdGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGame");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            IdGame = 1,
                            Description = "Description 1",
                            Title = "Game 1"
                        },
                        new
                        {
                            IdGame = 2,
                            Description = "Description 2",
                            Title = "Game 2"
                        });
                });

            modelBuilder.Entity("mas_project.Models.Offer", b =>
                {
                    b.Property<int>("IdOffer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAdvert")
                        .HasColumnType("int");

                    b.Property<int>("IdBuyer")
                        .HasColumnType("int");

                    b.HasKey("IdOffer");

                    b.HasIndex("IdBuyer");

                    b.ToTable("Offers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Offer");
                });

            modelBuilder.Entity("mas_project.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdUser");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdUser = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("mas_project.Models.BuyoutOffer", b =>
                {
                    b.HasBaseType("mas_project.Models.Offer");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasIndex("IdAdvert");

                    b.HasDiscriminator().HasValue("BuyoutOffer");

                    b.HasData(
                        new
                        {
                            IdOffer = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAdvert = 1,
                            IdBuyer = 1,
                            Price = 20f
                        });
                });

            modelBuilder.Entity("mas_project.Models.TradeOffer", b =>
                {
                    b.HasBaseType("mas_project.Models.Offer");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.HasIndex("IdAdvert");

                    b.HasIndex("IdGame");

                    b.HasDiscriminator().HasValue("TradeOffer");

                    b.HasData(
                        new
                        {
                            IdOffer = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAdvert = 1,
                            IdBuyer = 1,
                            IdGame = 2
                        });
                });

            modelBuilder.Entity("mas_project.Models.Advert", b =>
                {
                    b.HasOne("mas_project.Models.User", "Seller")
                        .WithMany()
                        .HasForeignKey("IdSeller")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("mas_project.Models.User", null)
                        .WithMany("CreatedAdverts")
                        .HasForeignKey("UserIdUser");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("mas_project.Models.AdvertGameCanBeTradedFor", b =>
                {
                    b.HasOne("mas_project.Models.Advert", "Advert")
                        .WithMany("AdvertGamesCanBeTradedFor")
                        .HasForeignKey("IdAdvert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Game", "Game")
                        .WithMany("AdvertGamesCanBeTradedFor")
                        .HasForeignKey("IdAdvert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("mas_project.Models.AdvertGameSubject", b =>
                {
                    b.HasOne("mas_project.Models.Advert", "Advert")
                        .WithMany("AdvertGameSubjects")
                        .HasForeignKey("IdAdvert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Game", "Game")
                        .WithMany("AdvertGameSubjects")
                        .HasForeignKey("IdAdvert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("mas_project.Models.Offer", b =>
                {
                    b.HasOne("mas_project.Models.User", "Buyer")
                        .WithMany("CreatedOffers")
                        .HasForeignKey("IdBuyer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("mas_project.Models.BuyoutOffer", b =>
                {
                    b.HasOne("mas_project.Models.Advert", "Advert")
                        .WithMany("BuyoutOffers")
                        .HasForeignKey("IdAdvert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");
                });

            modelBuilder.Entity("mas_project.Models.TradeOffer", b =>
                {
                    b.HasOne("mas_project.Models.Advert", "Advert")
                        .WithMany("TradeOffers")
                        .HasForeignKey("IdAdvert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Game", "ProposedGame")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");

                    b.Navigation("ProposedGame");
                });

            modelBuilder.Entity("mas_project.Models.Advert", b =>
                {
                    b.Navigation("AdvertGamesCanBeTradedFor");

                    b.Navigation("AdvertGameSubjects");

                    b.Navigation("BuyoutOffers");

                    b.Navigation("TradeOffers");
                });

            modelBuilder.Entity("mas_project.Models.Game", b =>
                {
                    b.Navigation("AdvertGamesCanBeTradedFor");

                    b.Navigation("AdvertGameSubjects");
                });

            modelBuilder.Entity("mas_project.Models.User", b =>
                {
                    b.Navigation("CreatedAdverts");

                    b.Navigation("CreatedOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
