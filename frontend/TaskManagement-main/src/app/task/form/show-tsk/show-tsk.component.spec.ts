import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowTskComponent } from './show-tsk.component';

describe('ShowTskComponent', () => {
  let component: ShowTskComponent;
  let fixture: ComponentFixture<ShowTskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowTskComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShowTskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
