import { Component } from '@angular/core';

@Component({
  selector: 'app-taskburndown',
  templateUrl: './taskburndown.component.html',
  styleUrl: './taskburndown.component.css'
})
export class TaskburndownComponent {
  // selectedTaskType: string = ''; // Initialize with 'all' to show all tasks initially
  
  tasks = [
    { pid:2001,id: 101, name: 'Image button', userId: 1001,priority:'high', taskType: 'Issue', owner: 'Shruti', startDate: '21.01.24', dueDate: '27.01.24' , overdue:2},
    { pid:2002,id: 102, name: 'Comment button', userId: 1002,priority:'Low',  taskType: 'Bug', owner: 'Priyanka', startDate: '22.01.24', dueDate: '26.01.24',overdue:3 },
    
    // Add other tasks as needed
  ];

  ngOnInit() {
   
  }

  showAllTasks() {
    this.tasks;
  }
  
  
}
