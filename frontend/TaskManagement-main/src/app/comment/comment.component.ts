import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  comments: string[] = [];
  newComment: string = '';
  dummyUsername: string = 'priyanga';
  ngOnInit() {
    const storedComments = localStorage.getItem('comments');
    if (storedComments) {
      this.comments = JSON.parse(storedComments);
    }
  }
  addComment() {
    if (this.newComment.trim() !== '') {   
      const commentWithDummyUsername = `${this.dummyUsername}: ${this.newComment}`;
      this.comments.push(commentWithDummyUsername);
      this.newComment = '';
      this.saveCommentsToLocalStorage();
    }
  }
  deleteComment(index: number) {
    this.comments.splice(index, 1);
    this.saveCommentsToLocalStorage();
  }
  private saveCommentsToLocalStorage() {  
    localStorage.setItem('comments', JSON.stringify(this.comments));
  }
  onFileSelected(event: any) {
    const fileInput = event.target;
    if (fileInput.files.length > 0) {
      const selectedFile = fileInput.files[0];
      console.log('Selected File:', selectedFile.json);
    }
  }
}
