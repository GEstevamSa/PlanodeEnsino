import { TestBed, inject } from '@angular/core/testing';

import { ToastyNotificationService } from '@services/toastyNotification/toasty-notification.service';
import { ToastOptions, ToastyConfig, ToastyService } from 'ng2-toasty';

describe('ToastyNotificationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ToastyNotificationService, ToastyService, ToastyConfig, ToastOptions]
    });
  });

  it('should be created', inject([ToastyNotificationService], (service: ToastyNotificationService) => {
    expect(service).toBeTruthy();
  }));
});
