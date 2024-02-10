import { Component } from '@angular/core';

@Component({
  selector: 'app-projectburndown',
  templateUrl: './projectburndown.component.html',
  styleUrl: './projectburndown.component.css'
})
export class ProjectburndownComponent {
  // selectedTaskType: string = ''; // Initialize with 'all' to show all tasks initially
  
  tasks = [
    { pid:2001,id: 101, name: 'Image button', userId: 1001,priority:'high', taskType: 'Issue', owner: 'Shruti', startDate: '20.01.24', dueDate: '24.01.24' , overdue:5},
    { pid:2002,id: 102, name: 'Comment button', userId: 1002,priority:'Low',  taskType: 'Bug', owner: 'Priyanka', startDate: '22.01.24', dueDate: '25.01.24',overdue:4 },
    
    // Add other tasks as needed
  ];

  ngOnInit() {
   
  }

  showAllTasks() {
    this.tasks;
  }
  
}
