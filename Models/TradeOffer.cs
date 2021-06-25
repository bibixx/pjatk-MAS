using System.Collections.Generic;

namespace mas_project.Models
{
	public partial class TradeOffer : Offer
    {
        public ICollection<TradeOfferGame> ProposedGames { get; set; }
    }
}
