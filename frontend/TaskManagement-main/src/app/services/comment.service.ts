import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private apiUrl = 'https://localhost:44388/api/Comment'; // URL to your ASP.NET Web API

  constructor(private http: HttpClient) {}

  // Get all comments
  getComments(): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.apiUrl}/GetComments`)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Add a comment
  addComment(comment: Comment): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/AddComment`, comment)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Update a comment
  updateComment(comment: Comment): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/UpdateComment`, comment)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Delete a comment by ID
  deleteComment(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/DeleteComment/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Handle HTTP errors
  private handleError(error: any) {
    console.error('An error occurred:', error);
    return throwError(error);
  }
}
