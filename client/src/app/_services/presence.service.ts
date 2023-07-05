import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpTransportType, HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class PresenceService {
//   hubUrl = environment.hubUrl;
//   private hubConnection?: HubConnection;
//   private onlineUsersSource = new BehaviorSubject<string[]>([]);
//   onlineUsers$ = this.onlineUsersSource.asObservable();

//   constructor(private toastr: ToastrService, private router: Router) { }

//   createHubConnection(user: User) {
//     this.hubConnection = new HubConnectionBuilder()
//       .withUrl(this.hubUrl + 'presence', {
//         accessTokenFactory: () => user.token,
//         transport: HttpTransportType.WebSockets
//       })
//       .withAutomaticReconnect()
//       .build();

//     this.hubConnection.start().catch(error => console.log(error));

//     this.hubConnection.on('UserIsOnline', user => {
//       this.onlineUsers$.pipe(take(1)).subscribe({
//         next: users => this.onlineUsersSource.next([...users, user])
//       })
//     })

//     this.hubConnection.on('UserIsOffline', user => {
//       this.onlineUsers$.pipe(take(1)).subscribe({
//         next: users => this.onlineUsersSource.next(users.filter(x => x !== user))
//       })
//     })

//     this.hubConnection.on('GetOnlineUsers', users => {
//       this.onlineUsersSource.next(users);
//     })

//     this.hubConnection.on('NewMessageReceived', ({user, knownAs}) => {
//       this.toastr.info(knownAs + ' has sent you a new message! Click me to see it')
//         .onTap
//         .pipe(take(1))
//         .subscribe({
//           next: () => this.router.navigateByUrl('/members/' + user + '?tab=Messages')
//         })
//     })
//   }

//   stopHubConnection() {
//     this.hubConnection?.stop().catch(error => console.log(error));
//   }
 }