import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ImageuploaderService {
  private baseUrl = 'http://localhost:9336/api/image'; // Replace with your actual backend URL

  constructor(private http: HttpClient) {}

  uploadImage(formData: FormData) {
    return this.http.post(this.baseUrl + '/multiple', formData); // Modify the URL to handle multiple uploads
  }

  getImages() {
    return this.http.get(this.baseUrl);
  }
}
