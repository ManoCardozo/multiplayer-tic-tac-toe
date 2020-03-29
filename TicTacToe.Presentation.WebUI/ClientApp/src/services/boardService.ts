import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Box } from '../models/box';
import { Board } from '../models/board';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class BoardService {

  // Base url
  baseurl = 'https://localhost:44314/board/';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }

  // POST
  CreateBox(data): Observable<Box> {
    return this.http.post<Box>(this.baseurl, JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      )
  }

  // GET
  GetBox(id): Observable<Box> {
    return this.http.get<Box>(this.baseurl + id)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      )
  }

  // GET
  GetBoxes(matchId: string): Observable<Board> {
    const opts = { params: new HttpParams({ fromObject: { matchId: matchId } }) };
    return this.http.get<Board>(this.baseurl + 'Get', opts)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      )
  }

  // PUT
  UpdateBox(boxId: string, playerId: string, matchId: string, data): Observable<Box[]> {
    const opts = new HttpParams({ fromObject: { boxId: boxId, playerId: playerId, matchId: matchId } });
    return this.http.put<Box[]>(this.baseurl + 'MarkBox', JSON.stringify(data), {
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

  // DELETE
  DeleteBox(id) {
    return this.http.delete<Box>(this.baseurl + id, this.httpOptions)
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
