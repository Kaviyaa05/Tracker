import { Component,OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-show-tsk',
  templateUrl: './show-tsk.component.html',
  styleUrl: './show-tsk.component.css'
})
export class ShowTskcomponent implements OnInit {

  constructor(private service:SharedService) {}

  TaskList:any=[];

  ngOnInit(): void { 
      this.refreshtskList();
  }
  
  refreshtskList(){
    this.service.gettskList().subscribe(data=>{
      this.TaskList=data;
    });
  }

}