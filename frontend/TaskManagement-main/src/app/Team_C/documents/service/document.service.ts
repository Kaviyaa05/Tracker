import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  
  private baseUrl = 'https://localhost:44341/api/documents'; 

  constructor(private http: HttpClient) {}

  getNotes(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  createNote(title: string, content: string): Observable<any> {
    const formData = {
      Title: title, 
      Content: content,
      CreatedAt: new Date().toISOString() 
    };
    return this.http.post<any>(`${this.baseUrl}`, formData);
  }

  getNoteById(id: number): Observable<any> {
    console.log("get all")
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  updateNote(id: number, note: any): Observable<any> {
    console.log("edit")
    return this.http.put(`${this.baseUrl}/${id}`, note);
  }
}