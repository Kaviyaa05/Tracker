import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenKey = 'authToken';


  constructor(private http: HttpClient,private router: Router) {}

  login(username: string, password: string): Observable<any> {
    const loginUrl = 'https://localhost:44388//token';
    
    const headers = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded'
    });
    const data = `grant_type=password&username=${encodeURIComponent(username)}&password=${encodeURIComponent(password)}`;
  
    console.log('Login request data:', data);
  
    return this.http.post(loginUrl, data, { headers })
      .pipe(
        map((response: any) => {
          // No need to parse response since it's already JSON
          this.setToken(response.access_token);
          return response;
        })
      );
  }
  

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);

  }
  getUserInfo(): Observable<any> {
    const apiUrl = 'https://localhost:44388/api/data'; // Replace with your API endpoint
    const token = this.getToken();
    
    if (!token) {
      throw new Error('No token found in local storage');
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    return this.http.get(apiUrl, { headers });
  }
}
