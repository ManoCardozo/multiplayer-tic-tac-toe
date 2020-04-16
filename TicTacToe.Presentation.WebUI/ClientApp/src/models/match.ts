import { Player } from '../models/player'
import { Board } from '../models/board'

export class Match {
  matchId: string;
  player1: Player;
  player2: Player;
  winnerId: string;
  playerTurnId: string;

  constructor(id: string) {
    this.matchId = id;
  }
}
