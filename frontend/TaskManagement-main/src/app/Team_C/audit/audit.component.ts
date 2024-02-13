import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuditService } from './Service/audit.service';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.css'],
})
export class AuditComponent implements OnInit {
  auditLogs: any[] = [];
  filteredLogs: any[] = [];
  auditForm: FormGroup;
  searchQuery: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private auditService: AuditService
  ) {
    this.auditForm = this.formBuilder.group({
      dateRange: ['all'],
      customDate: [null],
    });
  }

  ngOnInit() {
    this.getAuditLogs();
  }

  getAuditLogs() {
    this.auditService.getAuditLogs().subscribe(
      (auditLogs) => {
        this.auditLogs = auditLogs;
        this.filterLogs();
      },
      (error) => {
        console.error('Error fetching audit logs:', error);
      }
    );
  }

  filterLogs() {
    const dateRange = this.auditForm.get('dateRange')?.value;
    const customDate = this.auditForm.get('customDate')?.value;
    let startDate: Date | null = null;
  
    if (dateRange === 'all') {
      this.filteredLogs = this.auditLogs;
      return;
    }
  
    const today = new Date();
  
    if (dateRange === 'today') {
      startDate = new Date(today);
      startDate.setHours(0, 0, 0, 0);
    } else if (dateRange === 'yesterday') {
      const yesterday = new Date(today);
      yesterday.setDate(today.getDate() - 1);
      yesterday.setHours(0, 0, 0, 0);
      startDate = yesterday;
    } else if (dateRange === 'custom' && customDate) {
      startDate = new Date(customDate);
      startDate.setHours(0, 0, 0, 0);
    }
  
    console.log('startDate:', startDate);
  
    this.filteredLogs = this.auditLogs.filter((log) => {
      const logDate = new Date(log.Date_And_Time);
      console.log('logDate:', logDate);
      return startDate && logDate >= startDate && logDate < new Date(startDate.getTime() + 24 * 60 * 60 * 1000);
    });

    this.applySearch();
  }
  
  applySearch() {
    if (!this.searchQuery) {
      return; 
    }

    this.filteredLogs = this.filteredLogs.filter((log) => {
      for (const key in log) {
        if (log.hasOwnProperty(key)) {
          const value = log[key];
          if (typeof value === 'string' && value.toLowerCase().includes(this.searchQuery.toLowerCase())) {
            return true;
          }
        }
      }
      return false;
    });
  }

  onDateRangeChange() {
    const dateRange = this.auditForm.get('dateRange')?.value;
    if (dateRange === 'custom') {
      this.auditForm.get('customDate')?.setValue(null);
    }
    this.filterLogs();
  }

  onSearchInputChange() {
    this.applySearch();
  }
}
