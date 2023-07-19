import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Message } from '../_models/message';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';
import { UserParams } from '../_models/userParams';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  baseUrl = environment.apiUrl;
  ausername = UserParams.CurrentUsername;

  constructor(private http: HttpClient) { }

  getMessages(pageNumber: number, pageSize: number, container: string, username: string) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    params = params.append('Username', username);
    return getPaginatedResult<Message[]>(this.baseUrl + 'messages', params, this.http);
  }
  getUsernameFromLocalStorage(): string {
    const username = localStorage.getItem('username');
    return username ? username : this.ausername;
  }

  getMessageThread(username: string) {
    return this.http.get<Message[]>(this.baseUrl + 'messages/thread/' + username);
  }

  sendMessage(username: string, content: string) {
    return this.http.post<Message>(this.baseUrl + 'messages', 
      {recipientUsername: username, content});
  }

  deleteMessage(id: number) {
    return this.http.delete(this.baseUrl + 'messages/' + id);
  }
}