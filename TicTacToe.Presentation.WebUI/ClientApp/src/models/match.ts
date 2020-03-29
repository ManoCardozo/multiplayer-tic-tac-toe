import { Player } from '../models/player'
import { Board } from '../models/board'

export class Match {
  matchId: string;
  player1Name: string;
  player2Name: string;

  constructor(id: string) {
    this.matchId = id;
  }
}
