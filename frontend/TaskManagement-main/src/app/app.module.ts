import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbDropdown, NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TaskComponent } from './task/task.component';
import { AclSettingsComponent } from './acl-settings/acl-settings.component';
import { LoginactivityComponent } from './loginactivity/loginactivity.component';
import { ChartComponent } from './chart/chart.component';
import { LoginpageComponent } from './loginpage/loginpage.component';
import { TeamsComponent } from './Team_C/teams/teams.component';
import { NotificationComponent } from './Team_C/notification/notification.component';
import { AuditComponent } from './Team_C/audit/audit.component';
import { BoardsComponent } from './Team_C/boards/boards.component';
import { TimetrackerComponent } from './Team_C/timetracker/timetracker.component';
import { DocumentsComponent } from './Team_C/documents/documents.component';
import { ImageuploaderComponent } from './Team_C/imageuploader/imageuploader.component';
import { UsersComponent } from './users/users.component';
import { UserAddEditComponent } from './user-add-edit/user-add-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateComponent } from './create/create.component';
import { CommentComponent } from './comment/comment.component';
import {Chart} from 'chart.js';
import {registerables} from 'chart.js';
import { ProfileComponent } from './profile/profile.component';
import { FormComponent } from './task/form/form.component';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
Chart.register(...registerables);
import { DetailsComponent } from './details/details.component';
import { TasktypeComponent } from './report/tasktype/tasktype.component';
import { TaskpriorityComponent } from './report/taskpriority/taskpriority.component';
import { TaskburndownComponent } from './report/taskburndown/taskburndown.component';
import { ShowTskcomponent } from './task/form/show-tsk/show-tsk.component';
import { AddEditComponent } from './task/form/add-edit/add-edit.component';
import { SharedService } from './task/form/shared.service';
import { HttpClientModule } from '@angular/common/http';
import { NotifyService } from './Team_C/notification/notify.service';
import { TimeTrackerService } from './Team_C/timetracker/timetracker.service';
import { ImageuploaderService } from './Team_C/imageuploader/imageuploader.service';
import { ProfileService } from './profile/profile.service';
import { UserService } from './users/user.service';
import { ViewAllProjectsComponent } from './view-all-project/view-all-project.component';
import { NgModel } from '@angular/forms';
import { EditComponent } from './Team_C/documents/edit/edit.component';
import { ProjectownerComponent } from './report/projectowner/projectowner.component';
import { TaskownerComponent } from './report/taskowner/taskowner.component';
import { TaskassignedComponent } from './report/taskassigned/taskassigned.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TaskComponent,
    AclSettingsComponent,
    LoginactivityComponent,
     ChartComponent, 
     LoginpageComponent, 
     TeamsComponent, 
     NotificationComponent, 
     AuditComponent, 
     BoardsComponent, 
     TimetrackerComponent, 
     DocumentsComponent,
     ImageuploaderComponent, 
     UsersComponent,
     UserAddEditComponent, CreateComponent, CommentComponent, ProfileComponent, FormComponent, PageNotFoundComponent,
   ImageuploaderComponent, DetailsComponent, TasktypeComponent, TaskpriorityComponent, TaskburndownComponent, ShowTskcomponent, AddEditComponent, ShowTskcomponent,ViewAllProjectsComponent,EditComponent, ProjectownerComponent, TaskownerComponent, TaskassignedComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
     TableModule,
    HttpClientModule

  ],
  providers: [
    provideClientHydration(),SharedService,TimeTrackerService,ImageuploaderService,ProfileService,UserService,NgModel,NotifyService
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
