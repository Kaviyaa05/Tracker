import { Component } from '@angular/core';
import { ReportService } from '../../services/report.service';
@Component({
  selector: 'app-projectpriority',
  templateUrl: './projectpriority.component.html',
  styleUrl: './projectpriority.component.css'
})
export class ProjectpriorityComponent {
  selectedProjectpriority: string = 'All'; // Initialize with 'all' to show all tasks initially
  project:any[]=[];
  fliterProject:any[]=[];

 constructor (private http:ReportService){}

 getAllProjects(){
  this.http.showAllProject().subscribe((data:any[])=>{
    this.project = data;
    this.projectPriority();
  });
 }
 ngOnInit(): void {
     this.getAllProjects();
 }

 onProjectChange(){
  this.projectPriority();
 }
 projectPriority(){
  if(this.selectedProjectpriority === 'All'){
    this.fliterProject=this.project;
  }else{
    this.http.showProjectByPriority(this.selectedProjectpriority).subscribe((data:any[])=>{
      this.fliterProject=data;
    })
  }
 }
}
