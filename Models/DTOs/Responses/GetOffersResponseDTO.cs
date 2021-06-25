using System;
using System.Collections.Generic;

namespace mas_project.Models.DTOs.Requests
{
    public class GetOffersResponseDTOBuyer {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
    }

    public abstract class GetOffersResponseDTOOffer {
        public GetOffersResponseDTOBuyer Buyer { get; set; }
        public DateTime CreationDate { get; set; }
        public OfferStatus Status { get; set; }
    }

    public class GetOffersResponseDTOTradeOffers : GetOffersResponseDTOOffer {
        public List<GameDTO> Games { get; set; }
    }

    public class GetOffersResponseDTOBuyoutOffers : GetOffersResponseDTOOffer {
        public float Price { get; set; }
    }

    public class GetOffersResponseDTO {
        public List<GetOffersResponseDTOTradeOffers> TradeOffers { get; set; }
        public List<GetOffersResponseDTOBuyoutOffers> BuyoutOffers { get; set; }
    }
}
