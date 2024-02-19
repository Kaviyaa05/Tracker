import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectownerComponent } from './projectowner.component';

describe('ProjectownerComponent', () => {
  let component: ProjectownerComponent;
  let fixture: ComponentFixture<ProjectownerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProjectownerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectownerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
