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

  // Constructor with dependency injection
  constructor(private fb: FormBuilder, private timeTrackerService: TimeTrackerService) {}

  // Lifecycle hook for component initialization
  ngOnInit() {
    this.initializeForm();
    this.loadAllTimeEntries();
  }

  // Initialize the form with validators and value change subscriptions
  initializeForm() {
    this.timeEntryForm = this.fb.group({
      UserID: ['', Validators.required],
      ProjectID: ['', Validators.required],
      TaskID: ['', Validators.required],
      StartTime: [null, Validators.required],
      EndTime: [null, Validators.required],
      TotalWorkingHours: [''],
    });

    // Subscribe to value changes for StartTime and EndTime to calculate total hours
    this.timeEntryForm.get('StartTime')?.valueChanges.subscribe(() => {
      this.calculateTotalHours();
    });

    this.timeEntryForm.get('EndTime')?.valueChanges.subscribe(() => {
      this.calculateTotalHours();
    });
  }

  // Load all time entries from the service
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

  // Calculate total hours based on StartTime and EndTime
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

  // Open the popup for adding a new time entry
  openPopup() {
    this.showPopup = true;
    this.editingIndex = null;
    this.clearForm();
  }

  // Close the popup and optionally refresh time entries
  closePopup() {
    this.showPopup = false;
    this.clearForm();
    this.viewAllEntries = false;
    this.filterProjectID = ''; // Reset filter when closing the popup
    this.refreshTimeEntries();
  }

  // Refresh time entries by calling the service again
  refreshTimeEntries() {
    this.timeTrackerService.GetAllTimeEntries().subscribe((data) => {
      this.timeEntries = data;
    });
  }

  // Add a new time entry or edit an existing one
  AddTimeEntry() {
    if (this.timeEntryForm.valid) {
      const newEntry = { ...this.timeEntryForm.value, TotalWorkingHours: this.timeEntryForm.get('TotalWorkingHours')?.value };

      if (this.editingIndex === null) {
        // Add a new time entry
        this.timeTrackerService.AddTimeEntry(newEntry).subscribe(
          (response: any) => {
            this.timeEntries.push(response);
            this.closePopup();
            this.triggerChangeDetection();
          },
          (error: any) => {
            console.error('Failed to add time entry:', error);
          }
        );
      } else {
        // Edit an existing time entry
        const editedEntry = { ...newEntry, id: this.timeEntries[this.editingIndex].id };

        this.timeTrackerService.EditTimeEntry(editedEntry).subscribe(
          (response: any) => {
            console.log('Time entry updated successfully:', response);
            this.updateLocalEntry(response);
            this.closePopup();
            this.triggerChangeDetection();
          },
          (error: any) => {
            console.error('Failed to update time entry:', error);
          }
        );
      }
    }
  }

  // Trigger change detection manually
  triggerChangeDetection() {
    throw new Error('Method not implemented.');
  }

  // Update a local time entry after editing
  private updateLocalEntry(updatedEntry: any) {
    const index = this.timeEntries.findIndex((entry) => entry.id === updatedEntry.id);
    if (index !== -1) {
      Object.assign(this.timeEntries[index], updatedEntry);
    }
  }

  // Edit a specific time entry
  EditTimeEntry(index: number) {
    this.editingIndex = index;
    this.showPopup = true;
    this.populateForm(this.timeEntries[index]);
 }

  // Delete a specific time entry
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

  // Populate the form with data for editing
  populateForm(entry: any) {
    this.timeEntryForm.patchValue(entry);
  }

  // Clear the form
  clearForm() {
    this.timeEntryForm.reset();
  }

  // Toggle between viewing all entries and specific entries
  toggleViewAllEntries() {
    this.viewAllEntries = !this.viewAllEntries;
    if (!this.viewAllEntries) {
      this.filterProjectID = ''; // Reset filter when switching to view specific entries
    }
  }

  // Get unique project IDs from time entries
  getUniqueProjects(): string[] {
    const projects: string[] = [];
    this.timeEntries.forEach((entry) => {
      if (!projects.includes(entry.ProjectID)) {
        projects.push(entry.ProjectID);
      }
    });
    return projects;
  }
}
