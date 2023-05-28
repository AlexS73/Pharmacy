import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotificationComponent } from 'src/app/Notification/notification.component';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    constructor(private notificationComponent: NotificationComponent) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((error: HttpErrorResponse)=>{
                
                if(!error.url.endsWith('refresh-token'))
                    console.log('error', error);
                    this.notificationComponent.showNotification(error.message , 'error', 'Закрыть', 5000);
                return throwError(error);
            })
        )
    }
}
