import { Game } from "../../types/Game";
import { GameCondition } from "../../utils/mapConditionToString";

enum OfferStatus {
  Open,
  Rejected,
  Accepted,
  SellerCounteroffer,
  BuyerCounteroffer,
}

interface Advert {
  idAdvert: number;
  gameCondition: GameCondition;
  category: string;
  description: string;
  creationDate: Date;
  isActive: boolean;
  games: Game[]
}

interface Buyer {
  idUser: number;
  firstName: string;
  userName: string;
}

interface Offer {
  idOffer: number;
  advert: Advert;
  buyer: Buyer;
  creationDate: Date;
  status: OfferStatus;
}

interface TradeOffer extends Offer {
  proposedGames: Game[]
}

interface BuyoutOffer extends Offer {
  price: number;
}

export interface OffersResponse {
  tradeOffers: TradeOffer[];
  buyoutOffers: BuyoutOffer[];
}
