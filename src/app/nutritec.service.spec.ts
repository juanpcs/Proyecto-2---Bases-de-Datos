import { TestBed } from '@angular/core/testing';

import { NutritecService } from './nutritec.service';

describe('NutritecService', () => {
  let service: NutritecService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NutritecService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
