import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  baseUrl: string = 'https://localhost:44392/api/Profile';

  getAllUsers() {
    return this.http.get(this.baseUrl);
  }

  createUser(user: any) {
    return this.http.post(this.baseUrl, user);
  }

  updateUser(user: any) {
    return this.http.put(this.baseUrl + '/' + user.UserId, user);
  }

  deleteUser(userId: number) {
    return this.http.delete(this.baseUrl + '/' + userId);
  }
}
