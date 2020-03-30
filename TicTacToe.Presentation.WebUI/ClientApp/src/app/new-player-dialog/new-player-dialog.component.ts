import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NewPlayer } from '../../models/newPlayer';
import { faPlayCircle } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-new-player-dialog',
  templateUrl: './new-player-dialog.component.html',
})
export class NewPlayerDialogComponent {

  faPlayCircle = faPlayCircle;

  constructor(
    public dialogRef: MatDialogRef<NewPlayerDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public newPlayer: NewPlayer) { }

}
