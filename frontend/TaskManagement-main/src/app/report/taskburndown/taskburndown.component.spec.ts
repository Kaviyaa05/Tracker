import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskburndownComponent } from './taskburndown.component';

describe('TaskburndownComponent', () => {
  let component: TaskburndownComponent;
  let fixture: ComponentFixture<TaskburndownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskburndownComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskburndownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
