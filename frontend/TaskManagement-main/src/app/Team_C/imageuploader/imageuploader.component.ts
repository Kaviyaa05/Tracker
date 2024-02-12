import { Component } from '@angular/core';
import { ImageuploaderService } from './imageuploader.service';

@Component({
  selector: 'app-imageuploader',
  templateUrl: './imageuploader.component.html',
  styleUrls: ['./imageuploader.component.css'],
})
export class ImageuploaderComponent {
  selectedFiles: FileList | null = null;
  images: any[] = []; // Array to store fetched images
  modalImageUrl: string | undefined;


  constructor(private imageuploaderService: ImageuploaderService) {}

  onFilesSelected(event: any) {
    this.selectedFiles = event.target.files;
  }

  onUpload() {
    if (this.selectedFiles) {
      const formData = new FormData();
      for (let i = 0; i < this.selectedFiles.length; i++) {
        formData.append('PhotoData', this.selectedFiles[i]);
      }

      this.imageuploaderService.uploadImage(formData).subscribe(
        (response) => {
          console.log('Images uploaded successfully', response);
          alert('Images uploaded successfully'); // Show alert when images are uploaded successfully

          // Handle success, e.g., show a success message
        },
        (error) => {
          console.error('Failed to upload images', error);
          // Handle error, e.g., show an error message
        }
      );
    }
  }

  fetchImages() {
    this.imageuploaderService.getImages().subscribe(
      (response: any) => {
        console.log('Images retrieved successfully', response);
        this.images = response; // Store fetched images in the 'images' array
      },
      (error) => {
        console.error('Failed to retrieve images', error);
        // Handle error, e.g., show an error message
      }
    );
  }
  openModal(imageData: string): void {
    this.modalImageUrl = 'data:image/jpeg;base64,' + imageData; // Prefix the base64 image data with proper format
  }
  closeModal(): void {
    console.log('Closing modal...');
    this.modalImageUrl = undefined;
  }
  
}