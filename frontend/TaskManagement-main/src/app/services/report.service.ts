import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

 
  constructor(private http: HttpClient) { }

  showAllTask(): Observable<any[]> {   
    return this.http.get<any[]>('https://localhost:44388/api/report/task');
  }

  showAllProject(): Observable<any[]>{
    return this.http.get<any[]>('https://localhost:44388/api/report/project');
  }

  showAllOverdue(): Observable<any[]>{
    return this.http.get<any[]>('https://localhost:44388/api/report/overdue')
  }

  showAllProjectOverdue(): Observable<any[]>{
    return this.http.get<any[]>('https://localhost:44388/api/report/ProjectOverdue')
  }
  

  // generatePdf():Observable<any[]>{
  //   return this.http
  // }

  showTaskByType(taskType: string): Observable<any[]> {
    return this.http.get<any[]>(`https://localhost:44392/api/report/taskByType?taskType=${taskType}`);
  }

  showTaskByPriority(taskPriority: string):Observable<any[]>{
    return this.http.get<any[]>(`https://localhost:44392/api/report/taskPriority?taskPriority=${taskPriority}`);
  }

  showProjectByPriority(projectPriority: string):Observable<any[]>{
    return this.http.get<any[]>(`https://localhost:44392/api/Report/projectPriority?priority=${projectPriority}`);
  }

}
