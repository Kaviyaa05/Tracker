import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from './shared.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  
  constructor(private service: SharedService) {}

  @Input() tsk: any = [];
  TaskId: string = "";
  UserId: string = "";
  Taskname: string = "";
  TaskType: string = "";
  Priority: string = "";
  CreatedBy: string = "";
  StartDate: string = "";
  EndDate: string = "";
  Status: string = "";
  Description: string = "";

  ngOnInit(): void {
    // Initialize form fields if editing an existing task
    this.TaskId = this.tsk.TaskId;
    this.UserId = this.tsk.UserId;
    this.Taskname = this.tsk.Taskname;
    this.TaskType = this.tsk.TaskType;
    this.Priority = this.tsk.Priority;
    this.CreatedBy = this.tsk.CreatedBy;
    this.StartDate = this.tsk.StartDate;
    this.EndDate = this.tsk.EndDate;
    this.Status = this.tsk.Status;
    this.Description = this.tsk.Description;
  }

  addTask() {
    // Check if required fields are filled out
    if (!this.UserId || !this.Taskname || !this.TaskType || !this.Priority || !this.CreatedBy || !this.StartDate || !this.EndDate || !this.Status || !this.Description) {
      alert("Please fill out all required fields.");
      return;
    }

    // Prepare data for the request
    var val = {
      UserId: this.UserId,
      Taskname: this.Taskname,
      TaskType: this.TaskType,
      Priority: this.Priority,
      CreatedBy: this.CreatedBy,
      StartDate: this.StartDate,
      EndDate: this.EndDate,
      Status: this.Status,
      Description: this.Description
    };

    // Send request to add task
    this.service.addTask(val).subscribe(res => {
      alert(res.toString());
    });
  }

  updateTask() {
    // Check if required fields are filled out
    if (!this.TaskId || !this.UserId || !this.Taskname || !this.TaskType || !this.Priority || !this.CreatedBy || !this.StartDate || !this.EndDate || !this.Status || !this.Description) {
      alert("Please fill out all required fields.");
      return;
    }

    // Prepare data for the request
    var val = {
      TaskId: this.TaskId,
      UserId: this.UserId,
      Taskname: this.Taskname,
      TaskType: this.TaskType,
      Priority: this.Priority,
      CreatedBy: this.CreatedBy,
      StartDate: this.StartDate,
      EndDate: this.EndDate,
      Status: this.Status,
      Description: this.Description
    };

    // Send request to update task
    this.service.updateTask(val).subscribe(res => {
      alert(res.toString());
    });
  }
}
