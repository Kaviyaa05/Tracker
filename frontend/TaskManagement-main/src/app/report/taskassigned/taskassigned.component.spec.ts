import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskassignedComponent } from './taskassigned.component';

describe('TaskassignedComponent', () => {
  let component: TaskassignedComponent;
  let fixture: ComponentFixture<TaskassignedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskassignedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskassignedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
