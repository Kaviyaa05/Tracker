
import { Component, OnInit } from '@angular/core';
import { faBell, faClock, faUser } from '@fortawesome/free-regular-svg-icons';
import { faKey, faPowerOff, faShield } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from '../auth.service'; // Import AuthService
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
export class HomeComponent implements OnInit{
isHovered  : boolean= false;  
user: any;
faBell=faBell;
faUser=faUser;
faKey=faKey;
faClock=faClock;
faPower=faPowerOff;
faShield=faShield;
  username: any;
constructor(
  private http: HttpClient,
  private authService: AuthService // Inject AuthService
) {}
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
ngOnInit(): void {
  this.authService.getUserInfo().subscribe(
    (response) => {
      // Log the response to the console
      console.log('User info response:', response);
      this.user = response;
      this.username = response.split(',')[0].split(':')[1].trim();
    },
    (error) => {
      console.error('Error fetching user info:', error);
    }
  );
}
logout(): void {
  this.authService.logout();
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
