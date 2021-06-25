using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace mas_project.Models
{
	public class MainDbContext : DbContext
	{
		public MainDbContext()
		{
		}

		public MainDbContext(DbContextOptions opt)
			: base(opt)
		{

		}

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertGameCanBeTradedFor> AdvertGameCanBeTradedFors { get; set; }
        public DbSet<AdvertGameSubject> AdvertGameSubjects { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<TradeOffer> TradeOffers  { get; set; }
        public DbSet<BuyoutOffer> BuyoutOffers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<CollectionMethod> CollectionMethods { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<SelfPickup> SelfPickups { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Prepayment> Prepayments { get; set; }
        public DbSet<PaymentOnDelivery> PaymentOnDelivery { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advert>()
                .HasOne(ad => ad.Seller)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            // Seeds
            modelBuilder.Entity<User>(builder => {
                builder.HasData(new User {
                    IdUser = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "jDoe",
                    Email = "john.doe@example.com",
                    CreationDate = new DateTime(),
                    IsBuyer = true
                });

                builder.HasData(new User {
                    IdUser = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    UserName = "janeDoe",
                    Email = "jane.doe@example.com",
                    CreationDate = new DateTime(),
                    IsSeller = true,
                    SelfPickupAddress = "Long Street 1",
                    PhoneNumber = "000 000 000",
                });
            });

            modelBuilder.Entity<Game>(builder => {
                builder.HasData(new Game {
                    IdGame = 1,
                    Title = "Game 1",
                    Description = "Description 1",
                    ReleaseDate = new DateTime()
                });

                builder.HasData(new Game {
                    IdGame = 2,
                    Title = "Game 2",
                    Description = "Description 2",
                    ReleaseDate = new DateTime()
                });
            });

            modelBuilder.Entity<Advert>(builder => {
                builder.HasData(new Advert {
                    IdAdvert = 1,
                    GameCondition = GameConditionType.BrandNew,
                    Description = "Description 1",
                    CreationDate = new DateTime(),
                    IsActive = true,
                    IdSeller = 2
                });
            });

            modelBuilder.Entity<AdvertGameSubject>(builder => {
                builder.HasData(new AdvertGameSubject {
                    IdAdvertGameSubject = 1,
                    IdAdvert = 1,
                    IdGame = 1,
                });
            });

            modelBuilder.Entity<AdvertGameCanBeTradedFor>(builder => {
                builder.HasData(new AdvertGameCanBeTradedFor {
                    IdAdvertGameCanBeTradedFor = 1,
                    IdAdvert = 1,
                    IdGame = 2,
                });
            });

            modelBuilder.Entity<TradeOffer>(builder => {
                builder.HasData(new TradeOffer {
                    IdOffer = 1,
                    IdBuyer = 1,
                    IdAdvert = 1,
                    IdGame = 2,
                    CreationDate = new DateTime(),
                    Status = OfferStatus.Open
                });
            });

            modelBuilder.Entity<BuyoutOffer>(builder => {
                builder.HasData(new BuyoutOffer {
                    IdOffer = 2,
                    IdBuyer = 1,
                    IdAdvert = 1,
                    Price = 20,
                    CreationDate = new DateTime(),
                    Status = OfferStatus.Open
                });
            });
		}
	}
}
