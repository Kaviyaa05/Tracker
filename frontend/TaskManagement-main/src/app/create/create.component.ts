import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from '../service/project.service';
import { Project } from '../models/project';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  projectName: string = '';
  owner: string = '';
  createdOn: Date = new Date();
  description: string = '';
  teams: string = '';

  errorMessage: string = '';

  constructor(private projectService: ProjectService, private router: Router) { }

  submitForm() {
    const project: Project = {
      ProjectName: this.projectName,
      Owner: this.owner,
      CreatedOn: this.createdOn,
      Description: this.description,
      Teams: this.teams
    };

    console.log('Project data before submission:', project);

    this.projectService.addProject(project).subscribe(
      (response: Project) => {
        console.log('Project created successfully:', response);
        this.resetForm();
        // Redirect to view-all-project route after successful project creation
        this.router.navigate(['/view-all-projects']);
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
    this.owner = '';
    this.createdOn = new Date();
    this.description = '';
    this.teams = '';
    this.errorMessage = '';
  }
}
