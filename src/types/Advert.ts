import { Game } from "./Game";

export interface Advert {
  idAdvert: number,
  gameCondition: number,
  category: string,
  description: string,
  creationDate: string,
  isActive: boolean,
  seller: {
    idUser: number,
    firstName: string,
    lastName: string,
    userName: string,
    email: string,
    selfPickupAddress: string,
    phoneNumber: string
  },
  games: Game[],
  gamesThatCanBeTraded: Game[]
}
