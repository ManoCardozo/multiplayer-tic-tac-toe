import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { faGhost, faPlayCircle } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-match-lost-dialog',
  templateUrl: './match-lost-dialog.component.html',
})
export class MatchLostDialogComponent {

  faGhost = faGhost;
  faPlayCircle = faPlayCircle;

  constructor(public dialogRef: MatDialogRef<MatchLostDialogComponent>) { }

}
