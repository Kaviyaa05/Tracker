import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  getPaginatedUsers(currentPage: number, pageSize: number) {
    throw new Error('Method not implemented.');
  }

  constructor(private _http:HttpClient) { }

  updateUser(id:number, data:any):Observable<any>{
    return this._http.put('http://localhost:3000/users/${id}',data);
  }

  addUser(data:any):Observable<any>{
    return this._http.post('http://localhost:3000/users',data);
  }

  getUserList():Observable<any>{
    return this._http.get('http://localhost:3000/users');
  }

  deleteUser(id:number):Observable<any>{

    return this._http.delete('http://localhost:3000/users/${id}');

  }
}