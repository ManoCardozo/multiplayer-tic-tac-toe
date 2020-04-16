import { Component, Input, OnInit } from '@angular/core';
import { Box } from '../../models/box';
import { Match } from '../../models/match';
import { BoxService } from '../../services/boxService';
import { TicTacToeHubService } from '../../services/TicTacToeHubService';
import { SnackbarService } from '../../services/snackbarService'
import { faTimes, faCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
})
export class BoxComponent {
  @Input() box: Box;
  @Input() boxIndex: number;
  @Input() match: Match;
  @Input() playerId: string;

  constructor(
    public boxService: BoxService,
    public ticTacToeHubService: TicTacToeHubService,
    public snackbarService: SnackbarService,
  ) {
    
  }

  faTimes = faTimes;
  faCircle = faCircle;
  boxes: Box[];

  onSelect(box: Box) {
    var isBoxMarked = box.markedBy != null;
    var matchReady = this.match.playerTurnId == null;
    var isPlayerTurn = this.playerId == this.match.playerTurnId;

    if (matchReady)
    {
      this.snackbarService.show("Match is not ready yet.", "Dismiss");
      return;
    }
    else if (!isPlayerTurn) {
      this.snackbarService.show("It's not your turn. Please wait.", "Dismiss");
      return;
    }
    else if (isBoxMarked) {
      this.snackbarService.show("This box is already taken. Please choose another one.", "Dismiss");
      return;
    }
    else {
      let boxId = box.boxId;
      this.boxService.Mark(boxId, this.playerId).subscribe(data => {
        console.log('Box Updated');

        this.ticTacToeHubService.markBox(this.match.matchId);
      });
    }
  }

}
