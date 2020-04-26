import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Match } from '../models/match'

@Injectable({
  providedIn: 'root'
})

export class MatchService {

  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'match/';
  }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  Get(matchId: string): Observable<Match> {
    const opts = { params: new HttpParams({ fromObject: { matchId: matchId } }) };
    return this.http.get<Match>(this.url + 'get', opts)
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
