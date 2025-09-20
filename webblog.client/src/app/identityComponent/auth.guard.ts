import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserDataService } from './user-data.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: UserDataService, private router: Router) {}

  canActivate(): boolean {
    if (this.authService.isLoggedIn()) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}
