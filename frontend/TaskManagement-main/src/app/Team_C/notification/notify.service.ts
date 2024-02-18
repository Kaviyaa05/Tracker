import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {
  constructor(private http:HttpClient) { }
   
  url="https://localhost:44388/api/Notification";
 
  Uname:string="";
  //username:string="";
  getNotification(username:string) {
    this.Uname=username;
    return this.http.get(this.url + "?UserName=" + username)
  }
  

  getusername(){
    return this.Uname;
  }
  isRead(studentItem: any) {
    studentItem.isRead = true;

    return this.http.put(this.url + "/" + studentItem.NId, studentItem)
  }

  addnotification(noti:any){
    return this.http.post("https://localhost:44388/api/Notification",noti)
  }

 
}
