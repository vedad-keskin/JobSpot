import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavarComponent } from './navbar.component';

describe('NavarComponent', () => {
  let component: NavarComponent;
  let fixture: ComponentFixture<NavarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NavarComponent],
    });
    fixture = TestBed.createComponent(NavarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
