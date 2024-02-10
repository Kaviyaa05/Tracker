import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  constructor(private router: Router) {}

  // Add this method for navigation to FormComponent
  navigateToForm() {
    this.router.navigate(['/form']); // Adjust the route based on your actual route configuration
  }


}
