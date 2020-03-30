import { Component, Inject } from '@angular/core';
import { Box } from '../../models/box';
import { Match } from '../../models/match';
import { Player } from '../../models/player';
import { BoxService } from '../../services/boxService';
import { BoardService } from '../../services/boardService';
import { MatchService } from '../../services/matchService';
import { PlayerService } from '../../services/playerService';
import { TicTacToeHubService } from '../../services/TicTacToeHubService'
import { SnackbarService } from '../../services/snackbarService'
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NewPlayerDialogComponent } from '../new-player-dialog/new-player-dialog.component'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  boxes: Box[];
  match: Match;
  player: Player;

  constructor(
    public boxService: BoxService,
    public boardService: BoardService,
    public matchService: MatchService,
    public playerService: PlayerService,
    public ticTacToeHubService: TicTacToeHubService,
    public snackbarService: SnackbarService,
    public dialog: MatDialog
  ) {
    this.subscribeToEvents();
    this.initMatch();
  }

  private initMatch(): void {
    this.ticTacToeHubService.connectionEstablished.subscribe(data => {
      this.welcomePlayer();
    })
  }

  welcomePlayer(): void {
    const dialogRef = this.dialog.open(NewPlayerDialogComponent, {
      width: '300px',
      data: {  }
    });

    dialogRef.afterClosed().subscribe(playerName => {
      this.initPlayer(playerName);
    });
  }

  initPlayer(playerName: string) {
    //Init player
    this.playerService.InitPlayer(playerName).subscribe(player => {
      this.player = player;

      //Get match info
      this.matchService.Get(player.matchId).subscribe(match => {
        this.match = match;

        this.ticTacToeHubService.joinMatch(this.match.matchId, playerName);

        //Get boxes
        this.boardService.GetBoxes(this.match.matchId).subscribe(board => {
          this.boxes = board.boxes;
        });
      });
    });
  }

  private subscribeToEvents(): void {
    this.ticTacToeHubService.boardUpdated.subscribe(() => {
      this.boardService.GetBoxes(this.match.matchId).subscribe(board => {
        this.boxes = board.boxes;
        console.log('Done');
      });
    });

    this.ticTacToeHubService.playerJoined.subscribe((message) => {
      this.snackbarService.show(message, "Dismiss");
    });
  }

}
