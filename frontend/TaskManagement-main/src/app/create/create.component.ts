// Import necessary Angular modules
import { Component } from '@angular/core';

@Component({
  selector: 'app-create', // Adjusted selector to 'app-create'
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'] // You can create a CSS file for styling
})
export class CreateComponent {
  // Define properties for the project fields
  projectId: string = '';
  projectName: string = '';
  priority: string = 'high';
  description: string = '';
  owner: string = '';
  teamMembers: string = '';
  startDate: string = '';
  endDate: string = '';
  status: string = 'inProgress';

  submitForm() {
    // You can add your logic here to handle the form submission
    console.log('Form submitted!', this.projectId, this.projectName, this.priority, this.description, this.owner, this.teamMembers, this.startDate, this.endDate, this.status);
  }
  

  // Add any additional logic or methods as needed
}
