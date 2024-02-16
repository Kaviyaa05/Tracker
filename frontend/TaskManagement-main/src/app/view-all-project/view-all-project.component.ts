import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    this.editedProject = { ...project };
    this.showEditForm = true;
  }

  updateProject() {
    this.projectService.updateProject(this.editedProject).subscribe(
      (response: any) => {
        console.log('Project updated successfully:', response);
        this.showEditForm = false;
        this.getProjects();
      },
      (error) => {
        console.error('Error updating project:', error);
      }
    );
  }

  cancelEdit() {
    this.editedProject = { ProjectId: 0, ProjectName: '', Priority: '', Description: '', Owner: '', StartDate: '', EndDate: '', Status: '', TeamMembers: '' };
    this.showEditForm = false;
  }

  deleteProject(projectId: number | undefined) {
    if (projectId !== undefined) {
      this.projectService.deleteProject(projectId).subscribe(
        () => {
          console.log('Project deleted successfully.');
          this.projects = this.projects.filter(project => project.ProjectId !== projectId);
        },
        (error) => {
          console.error('Error deleting project:', error);
        }
      );
    }
  }

  navigateToHome() {
    this.router.navigate(['/task']);
  }
}
