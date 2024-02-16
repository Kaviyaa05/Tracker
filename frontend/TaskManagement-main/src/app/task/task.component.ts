import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  

  tasks:any[]=[{
    id: 101, name: 'Login', priority: 'High', type: 'Create', startDate: '24/12/2023', endDate: '20/1/2024', status: 'Todo'
  }];

  constructor(private router: Router) {}
  ngOnInit(): void {}

  
  // Add this method for navigation to FormComponent
  navigateToForm() {
    this.router.navigate(['/form']); // Adjust the route based on your actual route configuration
  }
  

  navigateToDetails(taskId: number) {
    console.log(taskId);
    this.router.navigate(['/details', taskId]);
  }

}
