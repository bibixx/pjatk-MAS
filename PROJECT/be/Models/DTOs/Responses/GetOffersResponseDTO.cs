using System;
using System.Collections.Generic;

namespace mas_project.Models.DTOs.Responses
{
    public class GetOffersResponseDTOAdvert {
        public int IdAdvert { get; set; }
        public GameConditionType GameCondition { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public List<GameDTO> Games { get; set; }
	}

    public class GetOffersResponseDTOBuyer {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
    }

    public abstract class GetOffersResponseDTOOffer {
        public int IdOffer { get; set; }
        public GetOffersResponseDTOAdvert Advert { get; set; }
        public GetOffersResponseDTOBuyer Buyer { get; set; }
        public DateTime CreationDate { get; set; }
        public OfferStatus Status { get; set; }
    }

    public class GetOffersResponseDTOTradeOffers : GetOffersResponseDTOOffer {
        public List<GameDTO> ProposedGames { get; set; }
    }

    public class GetOffersResponseDTOBuyoutOffers : GetOffersResponseDTOOffer {
        public float Price { get; set; }
    }

    public class GetOffersResponseDTO {
        public List<GetOffersResponseDTOTradeOffers> TradeOffers { get; set; }
        public List<GetOffersResponseDTOBuyoutOffers> BuyoutOffers { get; set; }
    }
}
