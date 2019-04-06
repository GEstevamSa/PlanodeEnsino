import { Injectable } from '@angular/core';
import { BrowserService } from './browser.service';

@Injectable({
  providedIn: 'root'
})
export class DownloadService {

  constructor(private browserService: BrowserService) {
  }

  public downloadFileFromHttpResponse(response): void {
    const contentDispositionHeader = response.headers.get('Content-Disposition');
    const type = response.body ? response.body.type : null;
    const blob = new Blob([response.body], { type: type });
    const filename = this.getFilename(contentDispositionHeader);
    if (this.browserService.isIEOrEdge()) {
      window.navigator.msSaveBlob(blob, filename);
    } else {
      const blobUrl = window.URL.createObjectURL(blob);
      const anchor = document.createElement('a');

      anchor.download = filename;
      anchor.href = blobUrl;
      anchor.click();
    }
  }

  public getFilename(header: string): string {
    if (header) {
      const fileName = header.split(';')[1].trim().split('=')[1];
      return fileName.replace(/"/g, '');
    }
    return 'Document';
  }
}
