import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowTskcomponent } from './show-tsk.component';

describe('ShowTskComponent', () => {
  let component: ShowTskcomponent;
  let fixture: ComponentFixture<ShowTskcomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowTskcomponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShowTskcomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
