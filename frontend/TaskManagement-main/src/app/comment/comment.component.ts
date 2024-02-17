import { Component, OnInit } from '@angular/core';
import { CommentService } from '../services/comment.service'; 

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  comments: any[] = [];
  newCommentText: string = '';

  constructor(private commentService: CommentService) {}

  ngOnInit(): void {
    this.getComments();
  }
  getComments(): void {
    this.commentService.getComments()
      .subscribe(
        (data: any[]) => {
          this.comments = data; 
        },
       
      );
  }
  addComment() {
    if (this.newCommentText.trim() !== '') {
      const newComment: any = {
        taskId: 1,
        projectId: 1,
        commentedData: this.newCommentText,
        dateTimePosted: new Date(),
        commentId: 1 
      };

      this.commentService.addComment(newComment)
        .subscribe(
          (comment: any) => {
            this.getComments();
            
            this.newCommentText = '';
          },
          
        ); 
    }
  }

  deleteComments(commentId: number) {
    console.log('Deleting comment with id:', commentId);
  
    if (commentId !== undefined && commentId !== null && commentId !== 0) {
      this.commentService.deleteComment(commentId)
        .subscribe(
          () => {
            console.log('Comment deleted successfully');     
            this.comments = this.comments.filter(comment => comment.commentId !== commentId);
          },
          error => {
            console.error('Error deleting comment:', error);
          }
        );
    } else {
      console.error('Invalid commentId:', commentId);
    }
  }
  
}
