using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
	public partial class TradeOffer : Offer
    {
        [Required]
        public int IdGame { get; set; }

        [ForeignKey(nameof(IdGame))]
        public Game ProposedGame { get; set; }
    }
}
