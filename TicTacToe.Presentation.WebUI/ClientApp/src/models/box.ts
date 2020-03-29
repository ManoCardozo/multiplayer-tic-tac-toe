import { Player } from '../models/player'

export class Box {
  boxId: string;
  markedBy: Player;

  constructor(id: string) {
    this.boxId = id;
  }
}
