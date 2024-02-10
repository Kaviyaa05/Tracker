import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrl: './documents.component.css'
})
export class DocumentsComponent {
  notes: any[] = [];

  constructor(private route: ActivatedRoute, private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    const newNote = navigation?.extras.state?.['newNote'];

    if (newNote) {
      this.notes.push(newNote);
    }

    // For simplicity, initialize with dummy data if the array is empty
    if (this.notes.length === 0) {
      this.notes = [
        { title: 'Note 1', content: 'Content for Note 1' },
        { title: 'Note 2', content: 'Content for Note 2' },
      ];
    }
  }

  createNewPage() {
    this.router.navigate(['/text-editor']);
  }

  viewPage(note: any) {
    console.log('Viewing note:', note);
  }

  editPage(note: any) {
    this.router.navigate(['/text-editor', note.title]);
  }
  
}



