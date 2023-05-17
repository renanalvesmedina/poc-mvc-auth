import { Hero } from "./Hero";
import { Player } from "./Player";

export type RankingScore = {
  player: Player;
  score: number;
  matchDate: Date;
  heroes: Hero[];
}