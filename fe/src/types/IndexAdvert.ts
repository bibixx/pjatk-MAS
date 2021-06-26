import { Game } from "./Game";

export interface IndexAdvert {
  idAdvert: number,
  gameCondition: number,
  category: string,
  games: Game[]
}
