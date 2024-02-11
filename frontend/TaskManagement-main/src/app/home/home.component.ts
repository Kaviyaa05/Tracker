import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { faBell, faClock, faUser } from '@fortawesome/free-regular-svg-icons';
import { faKey, faPowerOff, faShield } from '@fortawesome/free-solid-svg-icons';
import { NotifyService } from '../Team_C/notification/notify.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  isHovered  : boolean= false;


faBell=faBell;
faUser=faUser;
faKey=faKey;
faClock=faClock;
faPower=faPowerOff;
faShield=faShield;
  

toggleDropdown(elementId: string): void {
  this.isHovered = true;
  //const dropdown = document.getElementById(elementId);
  //if (dropdown?.classList.contains("show")) {
  //  dropdown.classList.remove("show");
  //} else {
  //  dropdown?.classList.add("show");
  //}

  const dropdown = document.getElementById(elementId);

// If dropdown exists and has class 'show', remove 'show'; otherwise, add 'show'
dropdown?.classList.toggle("show");
}

onMouseLeave(): void {
  this.isHovered = false;
}

dropDownFun(): void {
  this.toggleDropdown("mydropdown");
}

dropDownFunTask(): void {
  this.toggleDropdown("mydropdowntask");
}

dropDownFunProject(): void {
  this.toggleDropdown("mydropdownProject");
}

constructor(private http:HttpClient,private notify:NotifyService){}

usernotiArray: any[] = [];

latestMessages:any[]=[];
id:number=1;
ngOnInit():void {
  
  this.notify.getNotification(this.id)

    .subscribe((resultData: any) => {

     // this.isResultLoaded = true;
     
      this.usernotiArray = resultData.sort((a: { NId: number; }, b: { NId: number; }) => b.NId - a.NId);
    
      this.latestMessages = this.usernotiArray.slice(0, 3).map(item => `${item.Username} sent Message`);
    });
}
}
