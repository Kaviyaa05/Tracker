import { Component } from '@angular/core';
import { ReportService } from '../../services/report.service';


@Component({
  selector: 'app-taskpriority',
  templateUrl: './taskpriority.component.html',
  styleUrl: './taskpriority.component.css'
})
export class TaskpriorityComponent {
  selectedTaskpriority: string = 'All'; // Initialize with 'all' to show all tasks initially
  taskpriority:any[] = [];
  fliteredPriority : any[] = [];

  constructor(private obj:ReportService){}

  ngOnInit() {
      this.getTask();
  }
  getTask(){
     this.obj.showAllTask().subscribe((data:any[])=>{
      this.taskpriority = data;
      this.priorityFilter();
    });
  }

  onTaskByPriority(){
    this.priorityFilter();
  }

  priorityFilter(){
    if(this.selectedTaskpriority === 'All'){
      this.fliteredPriority = this.taskpriority;
    }else{
      this.obj.showTaskByPriority(this.selectedTaskpriority).subscribe((data : any[])=>{
        this.fliteredPriority = data;
      });
    }
  }

}
