
export class Player {
  playerId: string;
  name: string;
  symbol: string;
  matchId: string;

  constructor(id: string) {
    this.playerId = id;
  }
}
