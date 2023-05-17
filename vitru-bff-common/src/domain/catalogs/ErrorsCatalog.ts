export class RankingUnavailableError extends Error {
  constructor() {
    super('Ranking Unavaible!')
    this.name = 'RankingUnavailableError';
  }
}