import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup} from '@angular/forms'
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit{


  formValue !: FormGroup;

  constructor(private formbuilder: FormBuilder) {}


  ngOnInit(): void {

    this.formValue = this.formbuilder.group(
      {
        UserId :[''],
        UserName :[''],
        Role : [''],
        Email :[''],
        Password : ['']

      }
    )

  }




  

}
