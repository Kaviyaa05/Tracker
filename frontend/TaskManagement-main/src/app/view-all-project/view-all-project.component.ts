import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../service/project.service';
import { Project } from '../models/project';

@Component({
  selector: 'app-view-all-project',
  templateUrl: './view-all-project.component.html',
  styleUrls: ['./view-all-project.component.css']
})
export class ViewAllProjectsComponent implements OnInit {
  projects: Project[] = [];
  editedProject: Project = { ProjectId: 0, ProjectName: '', Priority: '', Description: '', Owner: '', StartDate: '', EndDate: '', Status: '', TeamMembers: '' };
  showEditForm: boolean = false;

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
    this.getProjects();
  }

  getProjects() {
    this.projectService.getProjects().subscribe(
      (response: Project[]) => {
        this.projects = response;
        console.log('Retrieved Projects:', this.projects);
      },
      (error) => {
        console.error('Error retrieving projects:', error);
      }
    );
  }

  editProject(project: Project) {
    // Set the editedProject object and show the edit form
    this.editedProject = { ...project }; // Make a copy to prevent direct modification of the original object
    this.showEditForm = true;
  }

  updateProject() {
    // Call the update API endpoint using the project service
    this.projectService.updateProject(this.editedProject).subscribe(
      (response: any) => {
        console.log('Project updated successfully:', response);
        // Hide the edit form and refresh the project list
        this.showEditForm = false;
        this.getProjects();
      },
      (error) => {
        console.error('Error updating project:', error);
        // Handle error (e.g., show error message)
      }
    );
  }

  cancelEdit() {
    // Reset editedProject and hide the edit form
    this.editedProject = { ProjectId: 0, ProjectName: '', Priority: '', Description: '', Owner: '', StartDate: '', EndDate: '', Status: '', TeamMembers: '' };
    this.showEditForm = false;
  }

  deleteProject(projectId: number | undefined) {
    // Check if projectId is defined before making the delete request
    if (projectId !== undefined) {
      this.projectService.deleteProject(projectId).subscribe(
        () => {
          console.log('Project deleted successfully.');
          // Remove the deleted project from the projects list
          this.projects = this.projects.filter(project => project.ProjectId !== projectId);
        },
        (error) => {
          console.error('Error deleting project:', error);
          // Handle error (e.g., show error message)
        }
      );
    }
  }
}
