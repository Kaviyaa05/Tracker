import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from './user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  formValue!: FormGroup;
  users: any = [];
  modalTitle: string | undefined;
  isAdd: boolean = true;

  constructor(
    private formbuilder: FormBuilder,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.formValue = this.formbuilder.group({
      UserId: [''],
      UserName: [''],
      Role: [''],
      Email: [''],
      Password: ['']
    });
    this.getAllUsers();
  }

  addUser() {
    this.userService.createUser(this.formValue.value).subscribe((res) => {
      alert("User added successfully");
      this.formValue.reset();
      this.getAllUsers();
    });
  }

  getAllUsers() {
    this.userService.getAllUsers().subscribe((res) => {
      this.users = res;
    });
  }

  editUser(user: any) {
    this.modalTitle = "Edit User";
    this.formValue.patchValue({
      UserId: user.UserId,
      UserName: user.UserName,
      Role: user.Role,
      Email: user.Email,
      Password: user.Password
    });
    this.isAdd = false;
  }

  updateUser() {
    this.userService.updateUser(this.formValue.value).subscribe(
      (res) => {
        alert("User updated successfully");
        this.formValue.reset();
        this.getAllUsers();
        // Reset modal title and set isAdd to true after update
        this.modalTitle = undefined;
        this.isAdd = true;
      },
      (error) => {
        alert("An error occurred while updating the user.");
        console.error(error);
      }
    );
  }

  deleteUser(userId: number) {
    if (confirm("Are you sure you want to delete this user?")) {
      this.userService.deleteUser(userId).subscribe(
        () => {
          alert("User deleted successfully");
          this.getAllUsers();
        },
        (error) => {
          alert("An error occurred while deleting the user.");
          console.error(error);
        }
      );
    }
  }
  
}
