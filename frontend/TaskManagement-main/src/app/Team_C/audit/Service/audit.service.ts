import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuditService {
  
  constructor(private http: HttpClient) { }

  getAuditLogs(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:44388/api/audit');
  }

  getTodayAuditLogs(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:44388/api/audit/Today');
  }

  getYesterdayAuditLogs(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:44388/api/audit/Yesterday');
  }

  getCustomDateAuditLogs(date: string): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:44388/api/audit/CustomDate/' + date);
  }
}
