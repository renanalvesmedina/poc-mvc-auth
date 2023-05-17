import { HeroModel } from "./HeroModel";
import { PlayerModel } from "./PlayerModel";

export class RankingScoreModel {
  player: PlayerModel;
  score: number;
  matchDate: Date;
  heroes: HeroModel[];
}