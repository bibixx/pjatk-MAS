﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mas_project.Models;

namespace mas_project.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("GameCondition")
                        .HasColumnType("int");

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
                            GameCondition = 0,
                            IdSeller = 2,
                            IsActive = true
                        },
                        new
                        {
                            IdAdvert = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 2",
                            GameCondition = 3,
                            IdSeller = 2,
                            IsActive = true
                        },
                        new
                        {
                            IdAdvert = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 3",
                            GameCondition = 1,
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
                        },
                        new
                        {
                            IdAdvertGameSubject = 2,
                            IdAdvert = 2,
                            IdGame = 2
                        },
                        new
                        {
                            IdAdvertGameSubject = 3,
                            IdAdvert = 3,
                            IdGame = 3
                        });
                });

            modelBuilder.Entity("mas_project.Models.CollectionMethod", b =>
                {
                    b.Property<int>("IdCollectionMethod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCollectionMethod");

                    b.ToTable("CollectionMethods");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CollectionMethod");
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

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGame");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            IdGame = 1,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Super Smash Bros: For Wii U"
                        },
                        new
                        {
                            IdGame = 2,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Elder Scrolls V: Skyrim"
                        },
                        new
                        {
                            IdGame = 3,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Call of Duty: Black Ops II"
                        },
                        new
                        {
                            IdGame = 4,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man (2018)"
                        },
                        new
                        {
                            IdGame = 5,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Legend of Zelda: Breath Of The Wild"
                        },
                        new
                        {
                            IdGame = 6,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Super Mario Odyssey"
                        },
                        new
                        {
                            IdGame = 7,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Call of Duty: Black Ops IIII"
                        },
                        new
                        {
                            IdGame = 8,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Counter-Strike: Global Offensive"
                        },
                        new
                        {
                            IdGame = 9,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "PlayerUnknown’s Battlegrounds (PUBG)"
                        },
                        new
                        {
                            IdGame = 10,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "League of Legends"
                        },
                        new
                        {
                            IdGame = 11,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Roblox"
                        },
                        new
                        {
                            IdGame = 12,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Rocket League"
                        },
                        new
                        {
                            IdGame = 13,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Overwatch"
                        },
                        new
                        {
                            IdGame = 14,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Red Dead Redemption II"
                        },
                        new
                        {
                            IdGame = 15,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Super Smash Bros: Ultimate"
                        },
                        new
                        {
                            IdGame = 16,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Tom Clancy’s Rainbow Six Siege"
                        },
                        new
                        {
                            IdGame = 17,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Grand Theft Auto V"
                        },
                        new
                        {
                            IdGame = 18,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fortnite"
                        },
                        new
                        {
                            IdGame = 19,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Minecraft"
                        },
                        new
                        {
                            IdGame = 20,
                            Description = "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Summary"
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

                    b.Property<int?>("IdTransaction")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdOffer");

                    b.HasIndex("IdBuyer");

                    b.HasIndex("IdTransaction");

                    b.ToTable("Offers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Offer");
                });

            modelBuilder.Entity("mas_project.Models.PaymentMethod", b =>
                {
                    b.Property<int>("IdPaymentMethod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaymentMethod");

                    b.ToTable("PaymentMethods");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PaymentMethod");
                });

            modelBuilder.Entity("mas_project.Models.Transaction", b =>
                {
                    b.Property<int>("IdTransaction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCollectionMethod")
                        .HasColumnType("int");

                    b.Property<int>("IdPaymentMethod")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTransaction");

                    b.HasIndex("IdCollectionMethod");

                    b.HasIndex("IdPaymentMethod");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("mas_project.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBuyer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeller")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<string>("_SelfPickupAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelfPickupAddress");

                    b.HasKey("IdUser");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            IsBuyer = true,
                            IsSeller = false,
                            LastName = "Doe",
                            UserName = "jDoe"
                        },
                        new
                        {
                            IdUser = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.doe@example.com",
                            FirstName = "Jane",
                            IsBuyer = false,
                            IsSeller = true,
                            LastName = "Doe",
                            UserName = "janeDoe",
                            _PhoneNumber = "000 000 000",
                            _SelfPickupAddress = "Long Street 1"
                        });
                });

            modelBuilder.Entity("mas_project.Models.Delivery", b =>
                {
                    b.HasBaseType("mas_project.Models.CollectionMethod");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Delivery");
                });

            modelBuilder.Entity("mas_project.Models.SelfPickup", b =>
                {
                    b.HasBaseType("mas_project.Models.CollectionMethod");

                    b.Property<DateTime>("EstimatedPickupDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("SelfPickup");
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
                            Status = 0,
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
                            Status = 0,
                            IdGame = 2
                        });
                });

            modelBuilder.Entity("mas_project.Models.PaymentOnDelivery", b =>
                {
                    b.HasBaseType("mas_project.Models.PaymentMethod");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PaymentOnDelivery");
                });

            modelBuilder.Entity("mas_project.Models.Prepayment", b =>
                {
                    b.HasBaseType("mas_project.Models.PaymentMethod");

                    b.HasDiscriminator().HasValue("Prepayment");
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

                    b.HasOne("mas_project.Models.Transaction", "Transaction")
                        .WithMany("Offers")
                        .HasForeignKey("IdTransaction");

                    b.Navigation("Buyer");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("mas_project.Models.Transaction", b =>
                {
                    b.HasOne("mas_project.Models.CollectionMethod", "CollectionMethod")
                        .WithMany("Transactions")
                        .HasForeignKey("IdCollectionMethod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Transactions")
                        .HasForeignKey("IdPaymentMethod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollectionMethod");

                    b.Navigation("PaymentMethod");
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

            modelBuilder.Entity("mas_project.Models.CollectionMethod", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("mas_project.Models.Game", b =>
                {
                    b.Navigation("AdvertGamesCanBeTradedFor");

                    b.Navigation("AdvertGameSubjects");
                });

            modelBuilder.Entity("mas_project.Models.PaymentMethod", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("mas_project.Models.Transaction", b =>
                {
                    b.Navigation("Offers");
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
