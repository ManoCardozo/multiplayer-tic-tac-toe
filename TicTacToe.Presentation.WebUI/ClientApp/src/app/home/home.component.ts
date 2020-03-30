import { Component } from '@angular/core';
import { Box } from '../../models/box';
import { BoxService } from '../../services/boxService';
import { BoardService } from '../../services/boardService';
import { MatchService } from '../../services/matchService';
import { PlayerService } from '../../services/playerService';
import { TicTacToeHubService } from '../../services/TicTacToeHubService'
import { SnackbarService } from '../../services/snackbarService'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  boxes: Box[];
  player1Name: string;
  player2Name: string;
  playerId: string = null;
  matchId: string = null;
  boardId: string = null;
  symbol: string = null;

  constructor(
    public boxService: BoxService,
    public boardService: BoardService,
    public matchService: MatchService,
    public playerService: PlayerService,
    public ticTacToeHubService: TicTacToeHubService,
    public snackbarService: SnackbarService
  ) {
    this.subscribeToEvents();
    this.initMatch();
  }

  private initMatch(): void {
    
    //Init player
    this.playerService.InitPlayer().subscribe(data => {
      this.playerId = data.playerId;
      this.matchId = data.matchId;
      this.ticTacToeHubService.connectionEstablished.subscribe(data => {
        this.ticTacToeHubService.joinMatch(this.matchId);
      })

      //Get match info
      this.matchService.Get(this.matchId).subscribe(data => {
        this.player1Name = data.player1Name;
        this.player2Name = data.player2Name;
      });

      //Get boxes
      this.boardService.GetBoxes(this.matchId).subscribe(data => {
        this.boxes = data.boxes;
      });
    });
  }

  private subscribeToEvents(): void {
    this.ticTacToeHubService.boardUpdated.subscribe(() => {
      this.boardService.GetBoxes(this.matchId).subscribe(data => {
        this.boxes = data.boxes;
        console.log('Done');
      });
    });

    this.ticTacToeHubService.playerJoined.subscribe((message) => {
      this.snackbarService.show(message, "Dismiss");
    });
  }

}
