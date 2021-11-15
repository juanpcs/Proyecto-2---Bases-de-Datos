import { TestBed } from '@angular/core/testing';

import { AgregarMedidasService } from './agregar-medidas.service';

describe('AgregarMedidasService', () => {
  let service: AgregarMedidasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AgregarMedidasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
