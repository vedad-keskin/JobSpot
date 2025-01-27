import { TestBed } from '@angular/core/testing';

import { AxiosService } from './axios.service';

describe('AxiosService', () => {
  let service: AxiosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AxiosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
