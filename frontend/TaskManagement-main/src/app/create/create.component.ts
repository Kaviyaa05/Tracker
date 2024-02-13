// create.component.ts
import { Component } from '@angular/core';
import { ProjectService } from '../service/project.service';
import { Project } from '../models/project';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  projectName: string = '';
  priority: string = '';
  description: string = '';
  owner: string = '';
  startDate: string = '';
  endDate: string = '';
  status: string = '';
  teamMembers: string = '';

  errorMessage: string = ''; // For displaying error messages to the user

  constructor(private projectService: ProjectService) { }

  submitForm() {
    const project: Project = {
      ProjectName: this.projectName,
      Priority: this.priority,
      Description: this.description,
      Owner: this.owner,
      StartDate: this.startDate,
      EndDate: this.endDate,
      Status: this.status,
      TeamMembers: this.teamMembers
    };

    console.log('Project data before submission:', project);

    this.projectService.addProject(project).subscribe(
      (response: Project) => {
        console.log('Project created successfully:', response);
        this.resetForm();
        // You can add any additional logic here
      },
      (error) => {
        console.error('Error creating project:', error);

        if (error.status === 400) {
          // Handle validation errors (if applicable)
          this.errorMessage = error.error.message; // Assuming the server returns a 'message' property
        } else {
          // Handle other errors
          this.errorMessage = 'An unexpected error occurred. Please try again later.';
        }
      }
    );
  }

  resetForm() {
    this.projectName = '';
    this.priority = '';
    this.description = '';
    this.owner = '';
    this.startDate = '';
    this.endDate = '';
    this.status = '';
    this.teamMembers = '';
    this.errorMessage = ''; // Clear error message
  }
}
