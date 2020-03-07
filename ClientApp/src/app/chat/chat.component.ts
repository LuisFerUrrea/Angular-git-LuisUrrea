import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { ChatService } from '../service/chat.service';
import { Message } from '../Interface';


@Component({
  selector: "chat-app",
  templateUrl: "./chat.component.html"
})

export class ChatComponent {

  public lstmensaje: Observable<Message[]>;
  nameControl = new FormControl('');
  textoControl = new FormControl('');

  constructor(http: HttpClient,protected chatService: ChatService) {
    this.GetInfo();
  }

  public GetInfo() {
    this.lstmensaje = this.chatService.GetMesagge();
  }

  public SendMessage() {
    this.chatService.Add(this.nameControl.value, this.textoControl.value);

    setTimeout(() => {
      this.GetInfo()
    }, 300);

    this.nameControl.setValue('');
    this.textoControl.setValue('');
  }
}
