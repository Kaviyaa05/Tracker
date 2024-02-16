import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from '../service/project.service';
import { Project } from '../models/project';

@Component({
  selector: 'app-view-all-projects',
  templateUrl: './view-all-project.component.html',
  styleUrls: ['./view-all-project.component.css']
})
export class ViewAllProjectsComponent implements OnInit {
  projects: Project[] = [];
  editedProject: Project = { ProjectId: 0, ProjectName: '', Owner: '', CreatedOn: new Date(), Description: '', Teams: '' };
  showEditForm: boolean = false;

  constructor(private router: Router, private projectService: ProjectService) { }

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
    // Assign the properties of the project individually to avoid reference issues
    this.editedProject = { ...project };
    // Show the edit form
    this.showEditForm = true;
  }

  updateProject() {
    this.projectService.updateProject(this.editedProject).subscribe(
      (response: Project) => {
        console.log('Project updated successfully:', response);
        this.showEditForm = false;
        // Update the projects list after successful update
        const index = this.projects.findIndex(p => p.ProjectId === response.ProjectId);
        if (index !== -1) {
          this.projects[index] = response;
        }
      },
      (error) => {
        console.error('Error updating project:', error);
      }
    );
  }

  cancelEdit() {
    // Reset the editedProject object and hide the edit form
    this.editedProject = { ProjectId: 0, ProjectName: '', Owner: '', CreatedOn: new Date(), Description: '', Teams: '' };
    this.showEditForm = false;
  }

  deleteProject(projectId: number | undefined) {
    console.log("delete");
    if (projectId !== undefined) {
      this.projectService.deleteProject(projectId).subscribe(
        () => {
          console.log('Project deleted successfully.');
          // Remove the deleted project from the projects list
          this.projects = this.projects.filter(project => project.ProjectId !== projectId);
        },
        (error) => {
          console.error('Error deleting project:', error);
        }
      );
    } else {
      console.error('ProjectId is undefined.');
    }
  }

  navigateToHome() {
    this.router.navigate(['/task']);
  }
}
