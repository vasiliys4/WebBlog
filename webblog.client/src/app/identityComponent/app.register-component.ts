import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserDataService } from './user-data.service';
import {FormsModule} from "@angular/forms";
import {User} from "./user";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule,
    RouterLink
  ],
  templateUrl: './app.register-component.html'
})
export class AppRegisterComponent {
  user: User = new User();

  constructor(private userService: UserDataService, private router: Router) {}

  onRegister() {
    this.userService.register(this.user).subscribe({
      next: (user) => {
        console.log('Регистрация успешна', user);
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Ошибка регистрации', err);
      }
    });
  }
}
