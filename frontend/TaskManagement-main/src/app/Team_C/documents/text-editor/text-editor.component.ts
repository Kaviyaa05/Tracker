import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

declare var tinymce: any;
@Component({
  selector: 'app-text-editor',
  templateUrl: './text-editor.component.html',
  styleUrl: './text-editor.component.css'
})
export class TextEditorComponent {
  private editor: any;

  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe((params) => {
      const id = params['id'];
      console.log(`Loading page with ID: ${id}`);
    });
  }

  ngAfterViewInit() {
    tinymce.init({
      selector: '#editor',
      height: 500,
      plugins: [
        'advlist autolink lists link image charmap print preview anchor',
        'searchreplace visualblocks code fullscreen',
        'insertdatetime media table paste code help wordcount',
      ],
      toolbar: 'undo redo | formatselect | ' +
               'bold italic backcolor | alignleft aligncenter ' +
               'alignright alignjustify | bullist numlist outdent indent | ' +
               'removeformat | help',
      menubar:false
    });
  }

  ngOnDestroy() {
    if (this.editor) {
      this.editor.destroy();
    }
  }
}




  




