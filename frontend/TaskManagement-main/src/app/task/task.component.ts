import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { DetailsService } from '../services/details.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {


  tasks:any[]=[{
    id: 1, name: 'Login', priority: 'High', type: 'Create', startDate: '24/12/2023', endDate: '20/1/2024', status: 'Todo'
  }];

  constructor(private router: Router , private http: DetailsService) {}
  ngOnInit(): void {}

  
  // Add this method for navigation to FormComponent
  navigateToForm() {
    this.router.navigate(['/form']); // Adjust the route based on your actual route configuration
  }
  

  navigateToDetails(taskid: number) {
    console.log(taskid);
    this.http.taskId = taskid;
    this.router.navigate(['/details']);
  }
   

}
