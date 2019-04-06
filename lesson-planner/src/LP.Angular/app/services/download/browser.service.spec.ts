import { TestBed } from '@angular/core/testing';
import { BrowserService } from './browser.service';

describe('BrowserService', () => {
  let service: BrowserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.get(BrowserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should test if browser is IE or Edge', () => {
    expect(service.isIEOrEdge()).toBeFalsy();
  });
});
