import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NfoodComponent } from './nfood.component';

describe('NfoodComponent', () => {
  let component: NfoodComponent;
  let fixture: ComponentFixture<NfoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NfoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NfoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
