import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class AclSettingsService { 
  private roleDetails: { [role: string]: { permissions: string[] } } = {};

  constructor() {
    this.loadRolePermissions();
  }
  private loadRolePermissions() {
    this.roleDetails = {
      Admin: { permissions: [] },
      TeamLeader: { permissions: [] },
      JuniorDeveloper: { permissions: [] },
      SeniorDeveloper: { permissions: [] },
      SoftwareTrainee: { permissions: [] },
    };
  }
  getRoleDetails(role: string): { permissions: string[] } {
    return this.roleDetails[role] || { permissions: [] };
  }
  hasPermission(permission: string): boolean {
    return true;
  }
  saveRoleDetails(role: string, details: { permissions: string[] }) {
    this.roleDetails[role] = details;
  }
}
