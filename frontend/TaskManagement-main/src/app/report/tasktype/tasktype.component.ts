import { Component } from '@angular/core';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-tasktype',
  templateUrl: './tasktype.component.html',
  styleUrl: './tasktype.component.css'
})
export class TasktypeComponent {
  
  selectedTaskType: string = 'All';
  tasks: any[] = [];
  filteredTasks: any[] = [];

  constructor(private taskService: ReportService) {}

  ngOnInit() {
    this.getTasks();
  }

  getTasks() {
    this.taskService.showAllTask().subscribe((data: any[]) => {
      this.tasks = data;
      this.filterTasks();
    });
  }

  onTaskTypeChange() {
    this.filterTasks();
  }

  filterTasks() {
    if (this.selectedTaskType === 'All') {
      this.filteredTasks = this.tasks;
      
    } else {
      this.taskService.showTaskByType(this.selectedTaskType).subscribe((data: any[]) => {
            this.filteredTasks = data;     
      });
    }
  }

  generatePDF(){
    if (this.selectedTaskType === 'All') {
      this.filteredTasks = this.tasks;
      
    } else {
      this.taskService.showTaskByType(this.selectedTaskType).subscribe((data: any[]) => {
            this.filteredTasks = data;     
      });
    }
  }

}
