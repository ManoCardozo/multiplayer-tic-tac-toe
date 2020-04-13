import { Component, Input, OnInit } from '@angular/core';
import { Box } from '../../models/box';
import { Match } from '../../models/match';
import { BoardService } from '../../services/boardService';
import { TicTacToeHubService } from '../../services/TicTacToeHubService'

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
})
export class BoardComponent implements OnInit {
  @Input() match: Match;
  @Input() playerId: string;

  constructor(
    public boardService: BoardService,
    public ticTacToeHubService: TicTacToeHubService
  ) {
    
  }

  boxes: Box[];

  private initBoard(): void {

    //Init Board
    this.boardService.GetBoxes(this.match.matchId).subscribe(data => {
      this.boxes = data.boxes;
    });
  }

  private subscribeToEvents(): void {
    this.ticTacToeHubService.boardUpdated.subscribe(() => {
      this.boardService.GetBoxes(this.match.matchId).subscribe(data => {
        this.boxes = data.boxes;
        console.log('Done');
      });
    });
  }

  ngOnInit() {
    this.subscribeToEvents();
    this.initBoard();
  }

}
