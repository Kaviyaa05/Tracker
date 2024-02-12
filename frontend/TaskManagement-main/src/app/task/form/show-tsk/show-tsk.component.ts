import { Component,OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-show-tsk',
  templateUrl: './show-tsk.component.html',
  styleUrls: ['./show-tsk.component.css']
})
export class ShowTskcomponent implements OnInit {

  constructor(private service:SharedService) {}

  TaskList:any=[];
  ModalTitle: string ='';
  FormComp:boolean=false;
  tsk:any;
  
  ngOnInit(): void { 
    this.refreshtskList();
}

  AddClick(){
    this.tsk={
      UserId:'',
      Taskname:'',
    }
    this.ModalTitle="Add Task";
    this.FormComp=true;
}
  

  

editClick(item:any){
  this.tsk=item;
  this.ModalTitle="Edit Task";
  this.FormComp=true;
}

  closeClick(){
    this.FormComp=false;
    this.refreshtskList();
  }
  
  refreshtskList(){
    this.service.gettskList().subscribe(data=>{
      this.TaskList=data;
    });
  }

}