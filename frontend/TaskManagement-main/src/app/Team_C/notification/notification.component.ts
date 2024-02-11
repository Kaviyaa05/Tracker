import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Subject, interval, takeUntil } from 'rxjs';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css'
})
export class NotificationComponent {
  private destroy$ = new Subject<void>();

  StudentArray: any[] = [];
  isResultLoaded = false;

  latestMessages:any[]=[];

  constructor(private http: HttpClient) {
    this.getAllStudent();
  }

  ngOnInit(): void {
    interval(5000)
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        this.getAllStudent();
        console.log(this.StudentArray);
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  id:Number=4;
//need to place it in the service 
  getAllStudent() {
   
    this.http.get("https://localhost:44354/api/values"+"/"+this.id)

      .subscribe((resultData: any) => {

        this.isResultLoaded = true;
       
        this.StudentArray = resultData.sort((a: { NId: number; }, b: { NId: number; }) => b.NId - a.NId);
      
        this.latestMessages = this.StudentArray.slice(0, 3).map(item => `${item.Username} sent Message`);
      }); 
  }
 

  
  markAsRead(StudentItem: any) {
    StudentItem.isRead = true;

    this.http.put("https://localhost:44354/api/values"+"/" + StudentItem.NId,StudentItem)
    .subscribe(()=>
      {
        console.log("Marked as Read");
      }
     
      );
  }
}

