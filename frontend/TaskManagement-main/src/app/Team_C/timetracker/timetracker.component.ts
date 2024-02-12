// time-tracking.component.ts

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TimeTrackerService } from './timetracker.service';
import { ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';


@Component({
  selector: 'app-timetracker',
  templateUrl: './timetracker.component.html',
  styleUrls: ['./timetracker.component.css'],
  changeDetection: ChangeDetectionStrategy.Default, // or ChangeDetectionStrategy.OnPush

})
export class TimetrackerComponent implements OnInit {
  timeEntries: any[] = [];
  timeEntryForm!: FormGroup;
  showPopup = false;
  editingIndex: number | null = null;
  viewAllEntries = false;
  filterProjectID: string = '';
  selectedIndex: number | null = null;

  constructor(private fb: FormBuilder, private timeTrackerService: TimeTrackerService) { }

  ngOnInit() {
    this.initializeForm();
    this.loadAllTimeEntries();
  }

  initializeForm() {
    this.timeEntryForm = this.fb.group({
      UserID: ['', Validators.required],
      ProjectID: ['', Validators.required],
      TaskID: ['', Validators.required],
      StartTime: [null, Validators.required],
      EndTime: [null, Validators.required],
      TotalWorkingHours: ['']
    });

    this.timeEntryForm.get('StartTime')?.valueChanges.subscribe(() => {
      this.calculateTotalHours();
    });

    this.timeEntryForm.get('EndTime')?.valueChanges.subscribe(() => {
      this.calculateTotalHours();
    });
  }

  loadAllTimeEntries() {
    this.timeTrackerService.GetAllTimeEntries().subscribe(
      (data) => {
        this.timeEntries = data;
        // console.log('Time entries loaded successfully:', this.timeEntries);
      },
      (error) => {
        console.error('Failed to load time entries:', error);
        // Handle error as needed
      }
    );
  }


  calculateTotalHours() {
    const StartTime = this.timeEntryForm.get('StartTime')?.value;
    const EndTime = this.timeEntryForm.get('EndTime')?.value;
  
    if (StartTime && EndTime) {
      const Start = new Date(StartTime);
      const End = new Date(EndTime);
  
      const diffMillis = End.getTime() - Start.getTime();
      const hours = diffMillis / (1000 * 60 * 60);
      
      // Set TotalWorkingHours as a numeric value
      this.timeEntryForm.get('TotalWorkingHours')?.setValue(hours);
    } else {
      this.timeEntryForm.get('TotalWorkingHours')?.setValue(null);
    }
  }
  

  openPopup() {
    this.showPopup = true;
    this.editingIndex = null;
    this.clearForm();
  }

  closePopup() {
    this.showPopup = false;
    this.clearForm();
    this.viewAllEntries = false;
    this.filterProjectID = ''; // Reset filter when closing the popup
  }

  AddTimeEntry() {
    if (this.timeEntryForm.valid) {
      const newEntry = {
        ...this.timeEntryForm.value,
        StartTime: new Date(this.timeEntryForm.get('StartTime')?.value),
        EndTime: new Date(this.timeEntryForm.get('EndTime')?.value),
        TotalWorkingHours: this.timeEntryForm.get('TotalWorkingHours')?.value,
      };

      if (this.editingIndex === null) {
        this.timeTrackerService.AddTimeEntry(newEntry).subscribe(
          (response: any) => {
            this.timeEntries.push(response);
            this.closePopup();
          },
          (error: any) => {
            console.error('Failed to add time entry:', error);
          }
        );
      } else {
        const editedEntry = { ...newEntry, id: this.timeEntries[this.editingIndex].id };

        this.timeTrackerService.EditTimeEntry(editedEntry).subscribe(
          (response: any) => {
            console.log('Time entry updated successfully:', response);
            this.updateLocalEntry(response);
            this.closePopup();
          },
          (error: any) => {
            console.error('Failed to update time entry:', error);
          }
        );
      }
    }
  }
  
  // Helper method to update the local entry after editing
  
  private updateLocalEntry(updatedEntry: any) {
    const index = this.timeEntries.findIndex(entry => entry.id === updatedEntry.id);
    if (index !== -1) {
      // Convert date strings to Date objects
      updatedEntry.StartTime = new Date(updatedEntry.StartTime);
      updatedEntry.EndTime = new Date(updatedEntry.EndTime);
  
      this.timeEntries[index] = updatedEntry;
    }
  }

 populateForm(entry: any) {
  // Convert date strings to Date objects
  entry.StartTime = new Date(entry.StartTime);
  entry.EndTime = new Date(entry.EndTime);

  // Set the form values
  this.timeEntryForm.patchValue({
    ...entry,
    StartTime: entry.StartTime.toISOString().slice(0, -8), // Adjust the format as needed
    EndTime: entry.EndTime.toISOString().slice(0, -8),     // Adjust the format as needed
  });
}

  EditTimeEntry(index: number) {
    this.editingIndex = index;
    this.showPopup = true;
    this.populateForm(this.timeEntries[index]);
    this.updateLocalEntry(Response);
  }

  DeleteTimeEntry(index: number) {
    const TaskID = this.timeEntries[index]?.TaskID;
    if (TaskID) {
      this.timeTrackerService.DeleteTimeEntry(TaskID).subscribe(
        () => {
          this.timeEntries.splice(index, 1);
        },
        (error: any) => {
          console.error('Failed to delete time entry:', error);
          // Handle error as needed
        }
      );
    }
  }

  

  clearForm() {
    this.timeEntryForm.reset();
  }

  toggleViewAllEntries() {
    this.viewAllEntries = !this.viewAllEntries;
    if (!this.viewAllEntries) {
      this.filterProjectID = ''; // Reset filter when switching to view specific entries
    }
  }

  getUniqueProjects(): string[] {
    const projects: string[] = [];
    this.timeEntries.forEach(entry => {
      if (!projects.includes(entry.ProjectID)) {
        projects.push(entry.ProjectID);
      }
    });
    return projects;
  }
}
