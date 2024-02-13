import { Component } from '@angular/core';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-projectburndown',
  templateUrl: './projectburndown.component.html',
  styleUrl: './projectburndown.component.css'
})
export class ProjectburndownComponent {
  projectdeadline:any[]=[];

  constructor(private http : ReportService){}
  
  getAllOverdue(){
    this.http.showAllProjectOverdue().subscribe((data:any[])=>{
      this.projectdeadline = data;
    })
  }
  ngOnInit(){
      this.getAllOverdue();
  }  
  
}
