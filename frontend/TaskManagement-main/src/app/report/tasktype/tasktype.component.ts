import { Component } from '@angular/core';

@Component({
  selector: 'app-tasktype',
  templateUrl: './tasktype.component.html',
  styleUrl: './tasktype.component.css'
})
export class TasktypeComponent {
  selectedTaskType: string = 'all'; // Initialize with 'all' to show all tasks initially
  
  tasks = [
    { pid:2001,id: 101, name: 'Image button', userId: 1001,priority:'high', taskType: 'Issue', owner: 'Shruti', startDate: '10.01.24', dueDate: '20.01.24' },
    { pid:2002,id: 102, name: 'Comment button', userId: 1002,priority:'Low',  taskType: 'Bug', owner: 'Priyanka', startDate: '10.01.24', dueDate: '20.01.24' },
    { pid:2003,id: 103, name: 'Textbox', userId: 1003,priority:'Medium',  taskType: 'Create', owner: 'Priyanka', startDate: '10.01.24', dueDate: '21.01.24' },
    { pid:3004,id: 104, name: 'Likes', userId: 1004,priority:'high',  taskType: 'Features', owner: 'Priyanka', startDate: '10.01.24', dueDate: '22.01.24' },
    { pid:5005,id: 105, name: 'Notes', userId: 1005,priority:'Medium',  taskType: 'Bug', owner: 'Priyanka', startDate: '10.01.24', dueDate: '24.01.24' },
    // Add other tasks as needed
  ];

  ngOnInit() {
    // Call getFilteredTasks here if additional setup is needed
    // this.getFilteredTasks();
  }

  showAllTasks() {
    this.selectedTaskType = 'all';
  }
  
  getFilteredTasks(): any[] {
    if (this.selectedTaskType.toLowerCase() === 'all') {
      return this.tasks;
    } else {
      // Filter tasks based on the selected task type
      const filtered = this.tasks.filter(task => task.taskType.toLowerCase() === this.selectedTaskType.toLowerCase());
      return filtered.length > 0 ? filtered : [];
    }
  }

}
