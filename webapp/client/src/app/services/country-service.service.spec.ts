import { TestBed } from '@angular/core/testing';

import { CountryServiceService } from './country-service.service';

describe('CountryServiceService', () => {
  let service: CountryServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CountryServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
