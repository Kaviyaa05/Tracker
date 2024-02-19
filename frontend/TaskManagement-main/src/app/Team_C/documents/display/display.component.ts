import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Import Router
import { DocumentService } from '../service/document.service';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css']
})
export class DisplayComponent implements OnInit {
  documentId!: number;
  documentContent!: string;

  constructor(private route: ActivatedRoute, private router: Router, private documentService: DocumentService) { } // Inject Router

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.documentId = +params['id']; // Convert string to number
      this.loadDocumentContent();
    });
  }

  loadDocumentContent() {
    this.documentService.getNoteContentById(this.documentId).subscribe(
      content => {
        this.documentContent = content;
      },
      error => {
        console.error('Error loading document content:', error);
      }
    );
  }

  goBack() {
    this.router.navigate(['/documents']); // Navigate back to documents page
  }
}