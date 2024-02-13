import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  baseUrl: string = 'https://localhost:44392/api/Profile';

  getAllUsers() {
    return this.http.get(this.baseUrl + '/users');
  }

  createUser(user: any) {
    return this.http.post(this.baseUrl + '/users', user);
  }

  updateUser(user: any) {
    return this.http.put(this.baseUrl + '/users/' + user.UserId, user);
  }

  deleteUser(UserId: number) { // Modify the parameter name to match the backend
    return this.http.delete(this.baseUrl + '/users/' + UserId);
  }
  
}
