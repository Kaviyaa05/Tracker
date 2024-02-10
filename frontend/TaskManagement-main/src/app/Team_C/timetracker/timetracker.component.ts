import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-timetracker',
  templateUrl: './timetracker.component.html',
  styleUrl: './timetracker.component.css'
})
export class TimetrackerComponent {
  timeEntries: any[] = [];
  timeEntryForm!: FormGroup;
  showPopup = false;
  editingIndex: number | null = null;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.timeEntryForm = this.fb.group({
      userId: ['', Validators.required],
      projectId: ['', Validators.required],
      taskId: ['', Validators.required],
      startTime: [null, Validators.required],
      endTime: [null, Validators.required],
      totalHours: ['']
    });

    this.timeEntryForm.get('startTime')?.valueChanges.subscribe(() => {
      this.calculateTotalHours();
    });

    this.timeEntryForm.get('endTime')?.valueChanges.subscribe(() => {
      this.calculateTotalHours();
    });
  }

  calculateTotalHours() {
    const startTime = this.timeEntryForm.get('startTime')?.value;
    const endTime = this.timeEntryForm.get('endTime')?.value;

    if (startTime && endTime) {
      const start = new Date(startTime);
      const end = new Date(endTime);

      const diffMillis = end.getTime() - start.getTime();
      const hours = Math.floor(diffMillis / (1000 * 60 * 60));
      const minutes = Math.floor((diffMillis % (1000 * 60 * 60)) / (1000 * 60));

      const totalHours = `${hours}:${minutes < 10 ? '0' : ''}${minutes}`;
      this.timeEntryForm.get('totalHours')?.setValue(totalHours);
    } else {
      this.timeEntryForm.get('totalHours')?.setValue('');
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
  }

  addTimeEntry() {
    if (this.timeEntryForm.valid) {
      const newEntry = this.timeEntryForm.value;
      if (this.editingIndex === null) {
        this.timeEntries.push(newEntry);
      } else {
        this.timeEntries[this.editingIndex] = newEntry;
      }
      this.closePopup();
    }
  }

  editTimeEntry(index: number) {
    this.editingIndex = index;
    this.showPopup = true;
    this.populateForm(this.timeEntries[index]);
  }

  deleteTimeEntry(index: number) {
    this.timeEntries.splice(index, 1);
  }

  private populateForm(entry: any) {
    this.timeEntryForm.patchValue(entry);
  }

  private clearForm() {
    this.timeEntryForm.reset();
  }

}
