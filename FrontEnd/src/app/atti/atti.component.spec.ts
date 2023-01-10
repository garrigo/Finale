import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttiComponent } from './atti.component';

describe('AttiComponent', () => {
  let component: AttiComponent;
  let fixture: ComponentFixture<AttiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttiComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AttiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
