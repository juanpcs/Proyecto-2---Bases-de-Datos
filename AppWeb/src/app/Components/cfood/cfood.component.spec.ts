import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CfoodComponent } from './cfood.component';

describe('CfoodComponent', () => {
  let component: CfoodComponent;
  let fixture: ComponentFixture<CfoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CfoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CfoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
