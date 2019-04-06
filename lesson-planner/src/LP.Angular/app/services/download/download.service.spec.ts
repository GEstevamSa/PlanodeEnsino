import { TestBed } from '@angular/core/testing';

import { BrowserService } from './browser.service';
import { DownloadService } from './download.service';

describe('DownloadService', () => {
  let service: DownloadService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BrowserService],
    });
    service = TestBed.get(DownloadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
