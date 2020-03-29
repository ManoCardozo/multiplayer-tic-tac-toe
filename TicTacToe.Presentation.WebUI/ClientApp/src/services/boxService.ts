import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Box } from '../models/box';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class BoxService {

  // Base url
  baseurl = 'https://localhost:44314/box/';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }

  Mark(boxId: string, playerId: string): Observable<Box> {
    const opts = new HttpParams({ fromObject: { playerId: playerId, boxId: boxId } });
    return this.http.put<Box>(this.baseurl + 'Mark', JSON.stringify({}), {
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
