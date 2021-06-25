using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
    public enum OfferStatus {
        Open,
        Rejected,
        Accepted,
        SellerCounteroffer,
        BuyerCounteroffer,
    }

	public partial class Offer
    {
        [Key]
        public int IdOffer { get; set; }

        [Required]
        public int IdBuyer { get; set; }

        [Required]
        [ForeignKey(nameof(IdBuyer))]
        public User Buyer { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public OfferStatus Status { get; set; }

        [Required]
        public int IdAdvert { get; set; }

        [ForeignKey(nameof(IdAdvert))]
        public Advert Advert { get; set; }

        public int? IdTransaction { get; set; }

        [ForeignKey(nameof(IdTransaction))]
        public Transaction Transaction { get; set; }
    }
}
