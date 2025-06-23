import { TestBed } from '@angular/core/testing';

import { RandevuapiserviceService } from './randevuapiservice.service';

describe('RandevuapiserviceService', () => {
  let service: RandevuapiserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RandevuapiserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
