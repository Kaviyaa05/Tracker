import { Component,OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { DocumentService } from './service/document.service';
@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrl: './documents.component.css'
})
export class DocumentsComponent implements OnInit {
  notes: any[] = [];
  notesId!:number;

  constructor(private router: Router, private documentsService: DocumentService) {}

  ngOnInit(): void {
    this.fetchNotes();
  }

  fetchNotes() {
    this.documentsService.getNotes().subscribe(
      (data: any[]) => {
        this.notes = data; 
      },
      
    );
  }

  createNewPage() {
    this.router.navigate(['/text-editor']);
  }
  editPage(notesId: number) {
    this.router.navigate(['/edit',notesId]);
  }
 
}



