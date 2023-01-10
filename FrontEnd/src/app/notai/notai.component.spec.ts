import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotaiComponent } from './notai.component';

describe('NotaiComponent', () => {
  let component: NotaiComponent;
  let fixture: ComponentFixture<NotaiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotaiComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
