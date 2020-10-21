import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, delay } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(catchedError => {
        if (catchedError) {
          if (catchedError.status === 400) {
            if (catchedError.error.errors) {
              throw catchedError.error;
            }
            else {
              this.toastr.error(catchedError.error.message, catchedError.error.statusCode);
            }
          }
          if (catchedError.status === 401) {
            this.toastr.error(catchedError.error.message, catchedError.error.statusCode);
          }
          if (catchedError.status === 404) {
            this.router.navigateByUrl('/not-found');
          }
          if (catchedError.status === 500) {
            const navigationExtras: NavigationExtras = { state: { error: catchedError.error } };
            this.router.navigateByUrl('/server-error', navigationExtras);
          }
          return throwError(catchedError);
        }
      })
    );
  }
}
