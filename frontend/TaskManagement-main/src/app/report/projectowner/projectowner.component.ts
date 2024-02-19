import { Component, OnInit } from '@angular/core';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-projectowner',
  templateUrl: './projectowner.component.html',
  styleUrl: './projectowner.component.css'
})
export class ProjectownerComponent implements OnInit{
  name:string ="";
  project:any[]=[];
  constructor(private http : ReportService){}
  ngOnInit(): void {
    this.ownedProject();
  }

  ownedProject(){
    this.http.showOwnedProject(this.name).subscribe((data:any[])=>{
      this.project=data;
    })
  }

}
