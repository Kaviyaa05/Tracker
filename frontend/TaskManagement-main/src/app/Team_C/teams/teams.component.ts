import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent {
  
  teamName: string = "";
  admin: string = "";
  snrDev: string = "";
  jnrDev: string = "";
  teamLead: string = "";
  tne: string = "";
  constructor(private http: HttpClient) {}

  submitForm() {
    const formData = {
      //ProjectID: 123, // Replace with actual project ID
      //TeamID: 456, // Replace with actual team ID
      TeamName: this.teamName,
      TeamMemberList: `${this.admin},${this.snrDev},${this.jnrDev},${this.teamLead},${this.tne}` // Combine all team members into a comma-separated string
    };

    this.http.post<any>('http://localhost:44388/api/team', formData)
      .subscribe(
        response => {
          console.log(response);
          alert('Data saved successfully!');
        },
        error => {
          console.error('Error:', error);
          alert('Error saving data. Please try again.');
        }
      );
  }

}

