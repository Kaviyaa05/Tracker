import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl="https://localhost:44388/api"

  constructor(private http:HttpClient) { }

  gettskList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/task');
  }

  addTask(val:any){
    return this.http.post(this.APIUrl+'/Task',val);
  }

  updateTask(val:any){
    return this.http.put(this.APIUrl+'/Task',val);
  }

  deleteTask(val:any){
    return this.http.delete(this.APIUrl+'/Task/'+val);
  }

}
