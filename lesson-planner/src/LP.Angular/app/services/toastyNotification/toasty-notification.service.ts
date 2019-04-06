import { Injectable } from '@angular/core';
import { INotification } from '@services/interfaces/inotification.service';
import { ToastOptions, ToastyService } from 'ng2-toasty';

@Injectable({
  providedIn: 'root'
})
export class ToastyNotificationService implements INotification {

  constructor(private toastyService: ToastyService) { }

  showError(title: string, message: string): void {
    const builtMessage = this.buildMessage(title, message);
    this.toastyService.error(builtMessage);
  }

  showSuccess(title: string, message: string): void {
    const builtMessage = this.buildMessage(title, message);
    this.toastyService.success(builtMessage);
  }

  showInfo(title: string, message: string): void {
    const builtMessage = this.buildMessage(title, message);
    this.toastyService.info(builtMessage);
  }

  private buildMessage(title: string, message: string): ToastOptions {
    const toastyOptions: ToastOptions = {
      title: title,
      msg: message,
      timeout: 3000
    };
    return toastyOptions;
  }


}
