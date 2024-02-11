import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private profileUrl = 'http://localhost:2682/api/profile'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  getProfile(): Observable<any> {
    return this.http.get<any>(this.profileUrl);
  }

  saveProfile(profileData: any): Observable<any> {
    return this.http.post<any>(this.profileUrl, profileData);
  }

  updateProfile(profileData: any): Observable<any> {
    return this.http.put<any>(this.profileUrl, profileData);
  }
}