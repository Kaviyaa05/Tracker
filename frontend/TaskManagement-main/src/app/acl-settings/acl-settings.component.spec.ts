import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AclSettingsComponent } from './acl-settings.component';

describe('AclSettingsComponent', () => {
  let component: AclSettingsComponent;
  let fixture: ComponentFixture<AclSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AclSettingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AclSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
