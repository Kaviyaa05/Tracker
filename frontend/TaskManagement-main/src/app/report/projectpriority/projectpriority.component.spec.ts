import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectpriorityComponent } from './projectpriority.component';

describe('ProjectpriorityComponent', () => {
  let component: ProjectpriorityComponent;
  let fixture: ComponentFixture<ProjectpriorityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProjectpriorityComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectpriorityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
