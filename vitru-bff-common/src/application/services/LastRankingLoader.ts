import { RankingScore } from "@/domain/entities";
import { ILastRankingLoader } from "@/domain/usecases";
import { LoadLastRankingClient } from "@/application/contracts";
import { RankingUnavailableError } from "@/domain/catalogs";

export class LastRankingLoaderService implements ILastRankingLoader {
  private readonly loadLastRankingClient: LoadLastRankingClient;

  constructor(loadLastRankingClient: LoadLastRankingClient) {
    this.loadLastRankingClient = loadLastRankingClient
  }

  async load(): Promise<RankingScore[]> {
    if(new Date().getHours() > 21) {
      throw new RankingUnavailableError();
    }
    
    return this.loadLastRankingClient.loadLastRanking();
  }
}