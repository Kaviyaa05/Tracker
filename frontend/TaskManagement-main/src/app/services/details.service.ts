import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DetailsService {
  taskId!: number; 
  constructor(private http: HttpClient) { }

  showTaskDetails(taskid: number): Observable<any[]> {
    console.log(taskid);
    console.log("run");
    return this.http.get<any[]>(`https://localhost:44388/api/report/Details?id=${this.taskId}`);
  
  }
}
