import { Component } from '@angular/core';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-taskowner',
  templateUrl: './taskowner.component.html',
  styleUrl: './taskowner.component.css'
})
export class TaskownerComponent {
  name:string ="";
  taskown:any[]=[];
  constructor(private http : ReportService){}
  ngOnInit(): void {
    this.ownedProject();
  }

  ownedProject(){
    this.http.showCreatedTask(this.name).subscribe((data:any[])=>{
      this.taskown=data;
    })
  }
}
