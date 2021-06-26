using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
	public partial class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public ICollection<Offer> Offers { get; set; }

        [Required]
        public int IdCollectionMethod { get; set; }

        [ForeignKey(nameof(IdCollectionMethod))]
        public CollectionMethod CollectionMethod { get; set; }

        [Required]
        public int IdPaymentMethod { get; set; }

        [ForeignKey(nameof(IdPaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
