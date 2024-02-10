import { Component, OnInit } from '@angular/core';
import { AclSettingsService } from './acl-settings.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-acl-settings', 
  templateUrl: './acl-settings.component.html', 
  styleUrls: ['./acl-settings.component.css'], 
})
export class AclSettingsComponent implements OnInit { 
  roles: string[] = ['TeamLeader', 'SeniorDeveloper', 'JuniorDeveloper', 'SoftwareTrainee'];
  permissions: string[] = ['Create', 'Assign', 'View', 'Edit', 'Delete'];
  rolePermissions: { [role: string]: { permissions: string[] } } = {};
  showAlert: boolean = false;

  constructor(private aclService: AclSettingsService,private router: Router) {}

  ngOnInit(): void {
   
    this.loadRolePermissions();
  }
  private loadRolePermissions() {
    this.roles.forEach((role) => {
      const roleDetails = this.aclService.getRoleDetails(role);
      this.rolePermissions[role] = {
        permissions: roleDetails.permissions,
      };
    });
  }
  onPermissionChange(role: string, permission: string, event: any) {
    if (event.target.checked) {
      this.rolePermissions[role].permissions.push(permission);
    } else {
      const index = this.rolePermissions[role].permissions.indexOf(permission);
      if (index !== -1) {
        this.rolePermissions[role].permissions.splice(index, 1);
      }
    }
  }
  saveRolePermissions() {
    this.roles.forEach((role) => {
      const { permissions } = this.rolePermissions[role];
      this.aclService.saveRoleDetails(role, { permissions });
    });
    console.log('Permissions saved:', this.rolePermissions); 
    this.showAlert = true;
    setTimeout(() => {
      this.showAlert = false;
      this.router.navigate(['/home']);
    }, 3000);
  }
}
