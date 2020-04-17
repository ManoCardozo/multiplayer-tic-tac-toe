import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class TicTacToeHubService {
  boardUpdated = new EventEmitter<any>();
  playerJoined = new EventEmitter<any>();
  playerLeft = new EventEmitter<any>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  joinMatch(matchId: string, playerName: string) {
    this._hubConnection.invoke('JoinMatch', matchId, playerName);
  }

  updateBoard(matchId: string) {
    this._hubConnection.invoke('UpdateBoard', matchId);
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(window.location.href + 'TicTacToeHub')
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function () { this.startConnection(); }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('BoardUpdated', (data: any) => {
      this.boardUpdated.emit(data);
    });

    this._hubConnection.on('PlayerJoined', (data: any) => {
      this.playerJoined.emit(data);
    });
  }
}  
