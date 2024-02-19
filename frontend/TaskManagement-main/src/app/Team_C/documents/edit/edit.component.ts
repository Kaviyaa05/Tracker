import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DocumentService } from '../service/document.service';

interface Note {
  Title: string;
  Content: string;
}

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  noteId!: number;
  note: Note = { Title: '', Content: '' };

  constructor(private route: ActivatedRoute, private router: Router, private documentService: DocumentService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.noteId = +params['id'];
      this.getData();
    });
  }

  getData() {
    this.documentService.getNoteById(this.noteId).subscribe((res: Note) => {
      this.note = res;
    });
  }

  returnNote() {
    this.documentService.updateNote(this.noteId, this.note).subscribe(
      (data) => {
        
        console.log('Note updated successfully:', data);
        this.router.navigate(['/documents']); 
      },
    )
  }
}
