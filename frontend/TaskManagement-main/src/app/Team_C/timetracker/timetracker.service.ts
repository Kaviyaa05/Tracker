// time-tracking.service.ts
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimeTrackerService {
  addOrUpdateTimeEntry(newEntry: any) {
    throw new Error('Method not implemented.');
  }
  private apiUrl = 'https://localhost:44388/api/TimeTracker';

  constructor(private http: HttpClient) { }

  GetAllTimeEntries(): Observable<any> {
    return this.http.get(`${this.apiUrl}/GetAllTimeEntries`);
  }

  AddTimeEntry(entry: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/AddTimeEntry`, entry);
  }

  EditTimeEntry(entry: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/EditTimeEntry`, entry);
  }

  DeleteTimeEntry(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/DeleteTimeEntry/${id}`);
  }
}
