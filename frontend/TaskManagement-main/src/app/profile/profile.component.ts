import { Component, OnInit } from '@angular/core';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  Name: string = '';
  UserId:string='';
  email: string = '';
  phone: string = '';
  role: string = '';
  about: string = '';
  password: string = '';
  address: string = '';

  originalProfileData: any; // To store original profile data
  isEditMode: boolean = false; // Flag to track edit mode

  constructor(private profileService: ProfileService) { }

  ngOnInit(): void {
    // Fetch all fields from the database
    this.getProfileDataFromDB();
  }

  getProfileDataFromDB() {
    // Fetch profile data and populate the fields
    this.profileService.getProfile().subscribe(profile => {
      this.Name = profile.Name;
      this.UserId=profile.Name;
      this.email = profile.email;
      this.phone = profile.phone;
      this.role = profile.role;
      this.about = profile.about;
      this.password = profile.password;
      this.address = profile.address;
      
      // Store original profile data
      this.originalProfileData = { ...profile };
    });
  }

  toggleEditMode() {
    this.isEditMode = !this.isEditMode;
    // If entering edit mode and profile data is not fetched yet, fetch it
    if (this.isEditMode && !this.originalProfileData) {
      this.getProfileDataFromDB();
    }
}


  saveProfile() {
    const profileData = this.getProfileData();
    
    // Save profile data
    this.profileService.saveProfile(profileData).subscribe((response: any) => {
      console.log('Profile saved successfully:', response);
      this.originalProfileData = { ...profileData }; // Update original profile data
      this.isEditMode = false; // Exit edit mode after saving
    }, (error: any) => {
      console.error('Error saving profile:', error);
    });
  }

  updateProfile() {
    const profileData = this.getProfileData();
    
    // Update profile data
    this.profileService.updateProfile(profileData).subscribe((response: any) => {
      console.log('Profile updated successfully:', response);
      this.originalProfileData = { ...profileData }; // Update original profile data
      this.isEditMode = false; // Exit edit mode after updating
    }, (error: any) => {
      console.error('Error updating profile:', error);
    });
  }

  // Helper function to get profile data from form fields
  private getProfileData() {
    return {
      Name: this.Name,
      UserId:this.UserId,
      email: this.email,
      phone: this.phone,
      role: this.role,
      about: this.about,
      password: this.password,
      address: this.address
    };
  }

  // Function to check if there are changes in profile data
  profileDataChanged() {
    const currentProfileData = this.getProfileData();
    return JSON.stringify(currentProfileData) !== JSON.stringify(this.originalProfileData);
  }
}