import { Component } from '@angular/core';
import { ReportService } from '../../services/report.service';


@Component({
  selector: 'app-taskburndown',
  templateUrl: './taskburndown.component.html',
  styleUrl: './taskburndown.component.css'
})
export class TaskburndownComponent {
  deadline:any[]=[];

  constructor(private http : ReportService){}
  
  getAllOverdue(){
    this.http.showAllOverdue().subscribe((data:any[])=>{
      this.deadline = data;
    })
  }
  ngOnInit(){
      this.getAllOverdue();
  }
  
  
}
