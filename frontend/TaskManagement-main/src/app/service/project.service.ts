// project.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Project } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private apiUrl = 'https://localhost:44388/api/Projects';

  constructor(private http: HttpClient) { }

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  addProject(project: Project): Observable<Project> {
    return this.http.post<Project>(`${this.apiUrl}/AddProject`, project)
      .pipe(
        catchError(this.handleError)
      );
  }
  

  updateProject(project: Project): Observable<Project> {
    return this.http.put<Project>(`${this.apiUrl}/UpdateProject/${project.ProjectId}`, project)
      .pipe(
        catchError(this.handleError)
      );
  }


  deleteProject(projectId: number): Observable<Project> {
    return this.http.delete<Project>(`${this.apiUrl}/DeleteProject/${projectId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: any) {
    console.error('API Error:', error);
    return throwError(error);
  }
}
