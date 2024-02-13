import { FormComponent } from './task/form/form.component';
import { LoginactivityComponent } from './loginactivity/loginactivity.component';
import { NgModule, Component, createComponent } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskComponent } from './task/task.component';
import { HomeComponent } from './home/home.component';
import { AclSettingsComponent } from './acl-settings/acl-settings.component';
import { ChartComponent } from './chart/chart.component';
import { LoginpageComponent } from './loginpage/loginpage.component';
import { CreateComponent } from './create/create.component';
import { NotificationComponent } from './Team_C/notification/notification.component';
import { ProfileComponent } from './profile/profile.component';
import { AuditComponent } from './Team_C/audit/audit.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CommentComponent } from './comment/comment.component';
import { ImageuploaderComponent } from './Team_C/imageuploader/imageuploader.component';
import { DetailsComponent } from './details/details.component';
import { TeamsComponent } from './Team_C/teams/teams.component';
import { BoardsComponent } from './Team_C/boards/boards.component';
import { TimetrackerComponent } from './Team_C/timetracker/timetracker.component';
import { UsersComponent } from './users/users.component';
import { UserAddEditComponent } from './user-add-edit/user-add-edit.component';
import { TasktypeComponent } from './report/tasktype/tasktype.component';
import { DocumentsComponent } from './Team_C/documents/documents.component';
import { TextEditorComponent } from './Team_C/documents/text-editor/text-editor.component';
import { TaskpriorityComponent } from './report/taskpriority/taskpriority.component';
import { TaskburndownComponent } from './report/taskburndown/taskburndown.component';
import { ProjectpriorityComponent } from './report/projectpriority/projectpriority.component';
import { ProjectburndownComponent } from './report/projectburndown/projectburndown.component';
import { ShowTskcomponent } from './task/form/show-tsk/show-tsk.component';

const routes: Routes = [
  { path : 'login', component : LoginpageComponent},
  { path:'loginactivity', component:LoginactivityComponent },
  { path:'acl', component:AclSettingsComponent},
  { path:'chart', component:ChartComponent},
  { path: 'task', component: TaskComponent },
{path:'create', component:CreateComponent},
  { path: 'notification', component:NotificationComponent},
  { path: 'profile', component: ProfileComponent},
  { path: 'form', component: FormComponent }, 
  {path:'audit' ,component:AuditComponent},
  { path: 'comment', component: CommentComponent },
  {path:'image' ,component:ImageuploaderComponent},
  {path:'details',component:DetailsComponent},
  {path:'teams',component:TeamsComponent},
  {path:'boards',component:BoardsComponent},
  {path:'timetracker',component:TimetrackerComponent},
  {path:'imageuploader',component:ImageuploaderComponent},
  {path:'users', component:UsersComponent},
  {path:'user-add-edit',component:UserAddEditComponent},
  {path:'tasktype',component:TasktypeComponent},
  {path:'documents',component:DocumentsComponent},
  {path:'text-editor',component:TextEditorComponent},
  {path:'tasktype',component:TasktypeComponent},
  {path:'taskpriority',component:TaskpriorityComponent},
  {path:'burndowntask',component:TaskburndownComponent},
  {path:'projectpriority',component:ProjectpriorityComponent},
  {path:'burndownproject',component:ProjectburndownComponent},
  {path:'show-tsk',component:ShowTskcomponent},
   {path:'**',component:PageNotFoundComponent}
   
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
