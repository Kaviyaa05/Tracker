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
  project: Project = {
    ProjectName: '',
    Owner: '',
    CreatedOn: new Date(),
    Description: '',
    Teams: ''
  };

  errorMessage: string = '';
  successMessage: string = '';

  constructor(private projectService: ProjectService, private router: Router) { }

  submitForm() {
    console.log('Project data before submission:', this.project);

    // Validation
    if (!this.validateForm()) {
      return;
    }

    this.projectService.addProject(this.project).subscribe(
      (response: Project) => {
        console.log('Project created successfully:', response);
        this.successMessage = 'Project created successfully.';
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
    this.project = {
      ProjectName: '',
      Owner: '',
      CreatedOn: new Date(),
      Description: '',
      Teams: ''
    };
    this.errorMessage = '';
    this.successMessage = '';
  }

  validateForm(): boolean {
    if (!this.project.ProjectName || !this.project.Owner || !this.project.Description) {
      this.errorMessage = 'Please fill in all required fields.';
      return false;
    }
    return true;
  }
}
