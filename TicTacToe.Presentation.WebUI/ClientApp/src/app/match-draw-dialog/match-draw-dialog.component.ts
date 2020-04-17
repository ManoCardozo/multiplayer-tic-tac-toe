import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { faBalanceScale, faPlayCircle } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-match-draw-dialog',
  templateUrl: './match-draw-dialog.component.html',
})
export class MatchDrawDialogComponent {

  faBalanceScale = faBalanceScale;
  faPlayCircle = faPlayCircle;

  constructor(public dialogRef: MatDialogRef<MatchDrawDialogComponent>) { }

}
