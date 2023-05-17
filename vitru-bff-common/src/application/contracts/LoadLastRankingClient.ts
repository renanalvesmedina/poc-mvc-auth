import { RankingScoreModel } from "@/application/models";

export interface LoadLastRankingClient {
  loadLastRanking:() => Promise<RankingScoreModel[]>
}