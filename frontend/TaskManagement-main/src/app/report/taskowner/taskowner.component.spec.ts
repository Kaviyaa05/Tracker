import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskownerComponent } from './taskowner.component';

describe('TaskownerComponent', () => {
  let component: TaskownerComponent;
  let fixture: ComponentFixture<TaskownerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskownerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskownerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
