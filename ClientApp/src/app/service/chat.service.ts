import { Injectable, Inject } from '@angular/core';
import { Message } from '../Interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MyResponse } from '../Interface';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ChatService {

  public baseUrl: string;

  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetMesagge(): Observable<Message[]> {
    return this.http.get<Message[]>(this.baseUrl + "api/Chat/Message");
  }

   public Add(name, texto) {
    this.http.post<MyResponse>(this.baseUrl + "api/Chat/Add", { 'Name': name, 'Texto': texto }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.error(error)
      );
  }

}
