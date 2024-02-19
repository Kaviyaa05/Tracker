import { Component, OnInit } from '@angular/core';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-taskassigned',
  templateUrl: './taskassigned.component.html',
  styleUrl: './taskassigned.component.css'
})
export class TaskassignedComponent implements OnInit {
  name:string ="";
  tasks:any[]=[];
  constructor(private http : ReportService){}
  ngOnInit(): void {
    this.ownedProject();
  }

  ownedProject(){
    this.http.showAssignedTask(this.name).subscribe((data:any[])=>{
      this.tasks=data;
    })
  }

}
