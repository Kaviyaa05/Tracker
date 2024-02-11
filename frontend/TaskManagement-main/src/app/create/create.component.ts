// Import necessary Angular modules
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NotifyService } from '../Team_C/notification/notify.service';

@Component({
  selector: 'app-create', // Adjusted selector to 'app-create'
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'] // You can create a CSS file for styling
})
export class CreateComponent {
  // Define properties for the project fields
  projectId: string = '';
  projectName: string = '';
  priority: string = 'high';
  description: string = '';
  owner: string = '';
  teamMembers: string = '';
  startDate: string = '';
  endDate: string = '';
  status: string = 'inProgress';

  submitForm() {
    // You can add your logic here to handle the form submission
    this.addnoti();
    console.log('Form submitted!', this.projectId, this.projectName, this.priority, this.description, this.owner, this.teamMembers, this.startDate, this.endDate, this.status);
  }
  
  constructor(private http:HttpClient,private notify:NotifyService){}
  noti: any = {
    Username: 'guha',  
    Time: new Date().toLocaleString(),  
    Message: 'You Have been assigned in a Project.',
    Priority: 'High'
  };
  addnoti(){
    this.notify.addnotification(this.noti)
    .subscribe(()=>{
      console.log("notification added");
    })
  }
}
