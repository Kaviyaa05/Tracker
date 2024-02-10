import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  teamName: string = "";
  admin: string = "";
  snrDev: string = "";
  jnrDev: string = "";
  teamLead: string = "";
  tne: string = "";

  showSelectedValues() {
    const message = `Team members:\n\n
        Team Name: ${this.teamName}\n
        Admin: ${this.admin}\n
        SNR DEV: ${this.snrDev}\n
        JNR DEV: ${this.jnrDev}\n
        TL: ${this.teamLead}\n
        TNE: ${this.tne}`;

    alert(message);
  }

}
