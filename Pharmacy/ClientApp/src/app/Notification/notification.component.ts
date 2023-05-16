import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';


@Component({
  selector: 'app-notification',
  styleUrls: ['./notification.component.scss'],
  template: '',
})
export class NotificationComponent{

  constructor(private snackBar: MatSnackBar) {}

  showNotification(message: string, type: string, action: string, duration: number) {
    const config = new MatSnackBarConfig();

    config.duration = duration;
    // Задаем позицию всплывающего уведомления
    config.verticalPosition = 'top';
    config.horizontalPosition = 'end';

    // Задаем цвет всплывающего уведомления в зависимости от типа
    if (type === 'error') {
      config.panelClass = ['notification-error'];
    } else if (type === 'success') {
      config.panelClass = ['notification-success'];
    }

    this.snackBar.open(message, action, {
      ...config,
    });
  }
}
