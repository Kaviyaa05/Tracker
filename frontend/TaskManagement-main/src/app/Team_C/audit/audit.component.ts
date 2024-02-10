import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.css']
})
export class AuditComponent implements OnInit  {
  auditLogs = [
    { dateTime: new Date('2024-01-01T12:00:00'), userName: 'Lakshmi Priya', module: 'Documents', action: 'Added document' },
    { dateTime: new Date('2024-01-02T14:30:00'), userName: 'Shruti', module: 'Profile', action: 'Updated profile information' },
    { dateTime: new Date('2024-01-03T10:45:00'), userName: 'Kaniga', module: 'Task', action: 'Added a new task'},
    { dateTime: new Date('2024-01-04T08:20:00'), userName: 'Priyanka', module: 'Home', action: 'Priyanka logged in'}
  ];

  searchTerm: string = '';
  filteredLogs: any[] = [];
  auditForm: FormGroup = this.formBuilder.group({
    dateRange: [''],
    customDate: [null],
  });

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.filterLogs();
  }

  filterLogs() {
    const auditForm = this.auditForm;

    if (auditForm) {
      const dateRangeControl = auditForm.get('dateRange');
      const customDateControl = auditForm.get('customDate');

      if (dateRangeControl && customDateControl) {
        const dateRange = dateRangeControl.value;
        const customDate = customDateControl.value;

        if (!dateRange || (dateRange === 'custom' && !customDate)) {
          // If custom date is selected but not provided, don't filter
          this.filteredLogs = this.auditLogs;
          return;
        }

        const today = new Date();
        let startDate = new Date();
        let endDate = new Date();

        if (dateRange === 'today') {
          startDate.setHours(0, 0, 0, 0);
        } else if (dateRange === 'yesterday') {
          startDate.setDate(today.getDate() - 1);
          startDate.setHours(0, 0, 0, 0);
          endDate.setDate(today.getDate() - 1);
          endDate.setHours(23, 59, 59, 999);
        } else if (dateRange === 'custom' && customDate) {
          startDate = new Date(customDate);
          startDate.setHours(0, 0, 0, 0);
          endDate = new Date(customDate);
          endDate.setHours(23, 59, 59, 999);
        }

        this.filteredLogs = this.auditLogs.filter((log) => {
          const logDate = new Date(log.dateTime);
          return logDate >= startDate && logDate <= endDate;
        });
      }
    } else {
      // If auditForm is null or undefined, show all records
      this.filteredLogs = this.auditLogs;
    }
  }

}
