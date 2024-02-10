import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-add-edit',
  templateUrl: './user-add-edit.component.html',
  styleUrls: ['./user-add-edit.component.css']
})
export class UserAddEditComponent implements OnInit {

  roles: string[] = [
    'TeamLeader',
    'SeniorDeveloper',
    'JuniorDeceloper',
    'SoftwareTrainee',
  ];

  userForm: FormGroup;
  data: any;

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    public activeModal: NgbActiveModal
  ) {
    this.userForm = this._fb.group({
      UserName: '',
      UserId: '',
      email: '',
      password: '',
      roles: '',
    });
  }

  ngOnInit(): void {
    this.userForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.userForm.valid) {
      if (this.data) {
        this._userService.updateUser(this.data.id, this.userForm.value).subscribe({
          next: (val: any) => {
            alert('User details updated!');
            this.activeModal.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      } else {
        this._userService.addUser(this.userForm.value).subscribe({
          next: (val: any) => {
            alert('User added successfully');
            this.activeModal.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }
}
