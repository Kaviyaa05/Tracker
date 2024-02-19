import { Component, OnInit } from '@angular/core';
import { DetailsService } from '../services/details.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  details: any[] = [];

  constructor(private detailsService: DetailsService) {}

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails() {
    const taskId = this.detailsService.taskId;
    this.detailsService.showTaskDetails(taskId).subscribe((data: any[]) => {
      this.details = data;
    });
  }
}
