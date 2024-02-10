import { Component } from '@angular/core';

@Component({
  selector: 'app-loginactivity',
  templateUrl: './loginactivity.component.html',
  styleUrl: './loginactivity.component.css'
})
export class LoginactivityComponent {
  revokeToken(token: string): void {
    // Add logic to revoke the token (you can make an API call to the server here)
    alert('Token ' + token + ' revoked!');
  }
}
