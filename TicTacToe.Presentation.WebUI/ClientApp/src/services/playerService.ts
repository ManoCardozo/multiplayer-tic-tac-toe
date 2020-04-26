import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Player } from '../models/player'
import { HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class PlayerService {

  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'player/';
  }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  InitPlayer(playerName: string): Observable<Player> {
    const opts = new HttpParams({ fromObject: { playerName: playerName } });
    return this.http.post<Player>(this.url + 'InitPlayer', JSON.stringify({}), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      params: opts
    })
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      )
  }

  // Error handling
  errorHandl(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
