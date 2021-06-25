using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
    public enum GameConditionType {
        BrandNew,
        Perfect,
        VeryGood,
        UsageVisible
    }

	public partial class Advert
    {
        [Key]
        public int IdAdvert { get; set; }

        [Required]
        public GameConditionType GameCondition { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int IdSeller { get; set; }

        [Required]
        [ForeignKey(nameof(IdSeller))]
        public User Seller { get; set; }

        public string Category {
            get {
                return this.Seller.SelfPickupAddress;
            }
        }

        [Required]
        public ICollection<AdvertGameSubject> AdvertGameSubjects { get; set; }

        public ICollection<AdvertGameCanBeTradedFor> AdvertGamesCanBeTradedFor { get; set; }

        // TODO: Composition
        public ICollection<TradeOffer> TradeOffers { get; set; }

        // TODO: Composition
        public ICollection<BuyoutOffer> BuyoutOffers { get; set; }
    }
}
