import { Component, Input, OnInit } from '@angular/core';
import { Box } from '../../models/box';
import { BoxService } from '../../services/boxService';
import { TicTacToeHubService } from '../../services/TicTacToeHubService'

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
})
export class BoxComponent {
  @Input() box: Box;
  @Input() playerId: string;
  @Input() matchId: string;
  @Input() boxIndex: number;

  constructor(
    public boxService: BoxService,
    public ticTacToeHubService: TicTacToeHubService
  ) {
    
  }

  boxes: Box[];

  onSelect(boxId: string) {
    this.boxService.Mark(boxId, this.playerId).subscribe(data => {
      console.log('Box Updated');
    });

    this.ticTacToeHubService.markBox(this.matchId);
  }

}
