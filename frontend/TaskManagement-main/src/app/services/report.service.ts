import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  username : string ="";
  taskId!:number;
  
  getUserName(){
    return this.username;
  }
  setUserName(unmae : string){
    this.username = unmae;
  }
 
  constructor(private http: HttpClient) { }

  showAllTask(): Observable<any[]> {   
    return this.http.get<any[]>('https://localhost:44388/api/report/task');
  }


  showAllOverdue(): Observable<any[]>{
    return this.http.get<any[]>('https://localhost:44388/api/report/overdue')
  }


  showTaskByType(taskType: string): Observable<any[]> {
    return this.http.get<any[]>(`https://localhost:44388/api/report/taskByType?type=${taskType}`);
  }

  showTaskByPriority(taskPriority: string):Observable<any[]>{
    return this.http.get<any[]>(`https://localhost:44388/api/report/taskbypriority?priority=${taskPriority}`);
  }

  showOwnedProject(projectOwner:string): Observable<any[]>{
    return this.http.get<any[]>(`https://localhost:44388/api/report/CreatedProject?owner=${this.getUserName()}`);
  }

  showAssignedTask(taskAssigned : string) : Observable<any[]>{
    return this.http.get<any[]>(`https://localhost:44388/api/report/TaskAssigned?assign=${this.getUserName()}`)
  }

  showCreatedTask(taskcreated:string){
    return this.http.get<any[]>(`https://localhost:44388/api/report/TaskCreated?create=${this.getUserName()}`)
  }

  
}
