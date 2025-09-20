import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { UserDataService } from './user-data.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: UserDataService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = this.authService.getToken();

    if (token) {
      const cloned = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      return next.handle(cloned);
    }

    return next.handle(req);
  }
}
