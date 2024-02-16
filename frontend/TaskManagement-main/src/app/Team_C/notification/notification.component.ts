import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Subject, interval, takeUntil } from 'rxjs';
import { NotifyService } from './notify.service';

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

  constructor(private http: HttpClient,private notify:NotifyService) {
    this.getAll();
  }

  ngOnInit(): void {
    interval(5000)
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        this.getAll();
        console.log(this.StudentArray);
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  id:Number=7;

  getAll() {
   
    this.notify.getNotification(this.id)

      .subscribe((resultData: any) => {

        this.isResultLoaded = true;
       
        this.StudentArray = resultData.sort((a: { NId: number; }, b: { NId: number; }) => b.NId - a.NId);
      
        this.latestMessages = this.StudentArray.slice(0, 3).map(item => `${item.Username} sent Message`);
      }); 
  }
 

  
  markAsRead(StudentItem: any) {

    this.notify.isRead(StudentItem)
    .subscribe(()=>
      {
        console.log("Marked as Read");
      }
     
      );
  }

}
