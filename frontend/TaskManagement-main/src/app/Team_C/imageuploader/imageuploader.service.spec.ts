import { TestBed } from '@angular/core/testing';

import { ImageuploaderService } from './imageuploader.service';

describe('ImageuploaderService', () => {
  let service: ImageuploaderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageuploaderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
