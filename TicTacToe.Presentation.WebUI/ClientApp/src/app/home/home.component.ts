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
import { MatchWonDialogComponent } from '../match-won-dialog/match-won-dialog.component'
import { MatchLostDialogComponent } from '../match-lost-dialog/match-lost-dialog.component'

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

  showMatchWonDialog(): void {
    const dialogRef = this.dialog.open(MatchWonDialogComponent, {
      width: '300px',
      data: {}
    });

    dialogRef.afterClosed().subscribe(() => {
      this.initPlayer(this.player.name);
    });
  }

  showMatchLostDialog(): void {
    const dialogRef = this.dialog.open(MatchLostDialogComponent, {
      width: '300px',
      data: {}
    });

    dialogRef.afterClosed().subscribe(() => {
      this.initPlayer(this.player.name);
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
        this.ticTacToeHubService.updateBoard(this.match.matchId);
      });
    });
  }

  private subscribeToEvents(): void {
    this.ticTacToeHubService.boardUpdated.subscribe(() => {
      this.boardService.GetBoxes(this.match.matchId).subscribe(board => {
        this.boxes = board.boxes;
      });

      this.matchService.Get(this.match.matchId).subscribe(match => {
        this.match = match;
        if (match.winnerId != null) {
          if (match.winnerId == this.player.playerId) {
            this.showMatchWonDialog();
          }
          else {
            this.showMatchLostDialog();
          }
        }
      });
    });

    this.ticTacToeHubService.playerJoined.subscribe((message) => {
      this.snackbarService.show(message, "Dismiss");
      this.matchService.Get(this.match.matchId).subscribe(match => {
        this.match = match;
      });
    });
  }

}
