import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { faMedal, faPlayCircle } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-match-won-dialog',
  templateUrl: './match-won-dialog.component.html',
})
export class MatchWonDialogComponent {

  faMedal = faMedal;
  faPlayCircle = faPlayCircle;

  constructor(public dialogRef: MatDialogRef<MatchWonDialogComponent>) { }

}
