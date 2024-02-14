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
  tsk:any=[];
  
  ngOnInit(): void { 
    this.refreshtskList();
}

  AddClick(){
    this.tsk={
      TaskId:"",
      UserId:"",
      Taskname:"",
      TaskType:"",
      Priority:"",
      CreatedBy:"",
      StartDate:"",
      EndDate:"",
      Status:"",
      Description:""
    }
    this.ModalTitle="Add Task";
    this.FormComp=true;
}
  

  

editClick(item:any){
  this.tsk=item;
  this.ModalTitle="Edit Task";
  this.FormComp=true;
}

deleteClick(item:any){
  if(confirm('Are you sure want to delete?')){
    this.service.deleteTask(item.TaskId).subscribe(data=>{
      alert(data.toString());
      this.refreshtskList();
    })
  }
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