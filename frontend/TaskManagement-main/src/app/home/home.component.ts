import { Component } from '@angular/core';
import { faBell, faClock, faUser } from '@fortawesome/free-regular-svg-icons';
import { faKey, faPowerOff, faShield } from '@fortawesome/free-solid-svg-icons';

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

}
