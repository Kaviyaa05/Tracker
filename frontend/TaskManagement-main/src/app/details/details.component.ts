import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DetailsService } from '../services/details.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  taskid!: number;
  details: any[] = [];

  constructor(private route: ActivatedRoute, private obj: DetailsService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.taskid = +params['id'];
      this.getDetails();
    });
  }

  getDetails() {
    this.obj.showTaskDetails(this.taskid).subscribe((data: any[]) => {
      console.log(this.taskid);
      this.details = data;
    });
  }
}
