import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DocumentService } from '../service/document.service';
@Component({
  selector: 'app-text-editor',
  templateUrl: './text-editor.component.html',
  styleUrls: ['./text-editor.component.css']
})
export class TextEditorComponent{
  constructor(private documentsService: DocumentService, private router: Router) { }
  ngOnInit(): void {   
  }
  onSubmit() {
    const title = (document.getElementById('title') as HTMLInputElement).value;
    const content = (document.getElementById('content') as HTMLTextAreaElement).value;
    this.documentsService.createNote(title, content).subscribe(
      () => {  
        this.router.navigate(['/documents']);
      },    
    );
  }
}
  




