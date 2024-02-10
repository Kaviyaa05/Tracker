import { Component } from '@angular/core';

@Component({
  selector: 'app-imageuploader',
  templateUrl: './imageuploader.component.html',
  styleUrl: './imageuploader.component.css'
})
export class ImageuploaderComponent {
  showUploadForm: boolean = false;

  toggleUploadForm() {
    this.showUploadForm = !this.showUploadForm;
  }

  openViewModal() {
    // Implement your logic to open the view modal
    console.log('View button clicked');
  }

}
