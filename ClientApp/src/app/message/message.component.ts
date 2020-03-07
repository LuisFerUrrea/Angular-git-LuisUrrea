import { Component, Input } from '@angular/core';
import { Message } from '../Interface';

@Component({
  selector: "message-app",
  templateUrl: "./message.component.html"
})

export class MessageComponent {
  @Input() oMessage: Message;
}



