import { TestBed, inject } from '@angular/core/testing';

import { UserCollectorService } from '@collectors/user/user-collector.service';

describe('UserCollectorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserCollectorService]
    });
  });

  it('should be created', inject([UserCollectorService], (service: UserCollectorService) => {
    expect(service).toBeTruthy();
  }));
});
