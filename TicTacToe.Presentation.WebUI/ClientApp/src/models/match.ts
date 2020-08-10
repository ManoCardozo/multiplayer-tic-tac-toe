import { Player } from '../models/player'
import { Board } from '../models/board'

export class Match {
  matchId: string;
  playerOne: Player;
  playerTwo: Player;
  winnerId: string;
  playerTurnId: string;
  isFinished: boolean;

  constructor(id: string) {
    this.matchId = id;
  }
}
