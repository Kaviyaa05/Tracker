import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectburndownComponent } from './projectburndown.component';

describe('ProjectburndownComponent', () => {
  let component: ProjectburndownComponent;
  let fixture: ComponentFixture<ProjectburndownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProjectburndownComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectburndownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
