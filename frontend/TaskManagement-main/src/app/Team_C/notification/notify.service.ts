import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { Subject, interval, takeUntil } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {

  constructor(private http:HttpClient) { }
   
  url="https://localhost:44354/api/values";

  
  getNotification(id: Number) {
    return this.http.get(this.url + "/" + id)
  }

  isRead(studentItem: any) {
    studentItem.isRead = true;

    return this.http.put(this.url + "/" + studentItem.NId, studentItem)
  }

  addnotification(noti:any){
    return this.http.post("https://localhost:44354/api/values",noti)
  }

 
}
