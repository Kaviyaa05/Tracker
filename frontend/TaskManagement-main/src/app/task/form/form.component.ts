import { Component } from '@angular/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'] // Correct the typo 'styleUrl' to 'styleUrls'
})
export class FormComponent {
  task: any;

  constructor() {
    this.task = {
      taskId: '',
      userId: '',
      name: '',
      taskType: '',
      priority: '',
      createdBy: '',
      startDate: '',
      endDate: '',
      status: '',
      description: ''
    };
  }
}
