import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from '../service/project.service';
import { Project } from '../models/project';

import { NotifyService } from '../Team_C/notification/notify.service';


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
   
  constructor(private projectService: ProjectService, private router: Router,private notify:NotifyService) { }
  
  submitForm() {
    this.addnoti()
    const project: Project = {
      ProjectName: this.projectName,
      Owner: this.owner,
      CreatedOn: this.createdOn,
      Description: this.description,
      Teams: this.teams
      
   // console.log('Form submitted!', this.projectId, this.projectName, this.priority, this.description, this.owner, this.teamMembers, this.startDate, this.endDate, this.status);
  }
    };

    //console.log('Project data before submission:', project);

  //   this.projectService.addProject(project).subscribe(
  //     (response: Project) => {
  //       console.log('Project created successfully:', response);
  //       this.resetForm();
  //       // Redirect to view-all-project route after successful project creation
  //       this.router.navigate(['/view-all-projects']);
  //     },
  //     (error) => {
  //       console.error('Error creating project:', error);

  //       if (error.status === 400) {
  //         // Handle validation errors (if applicable)
  //         this.errorMessage = error.error.message; // Assuming the server returns a 'message' property
  //       } else {
  //         // Handle other errors
  //         this.errorMessage = 'An unexpected error occurred. Please try again later.';
  //       }
  //     }
  //   );
  // }
  noti: any = {
    Username: this.notify.getusername(),  
    Time: new Date().toLocaleString(),  
    Message: 'You Have been assigned in a Project.',
    Priority: 'High',
    isRead:'false',
    receiver:'Guhan'
  };
  addnoti(){ console.log(this.noti);
    console.log(this.notify.Uname);
    this.notify.addnotification(this.noti)
    .subscribe(()=>{
      console.log("notification added");
     
    },
    (error) => {
      console.error("Error adding notification:", error);
    })
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

