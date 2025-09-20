import { Component } from '@angular/core';
import { UserDataService } from './user-data.service';
import {Router, RouterLink} from '@angular/router';
import {FormsModule} from "@angular/forms";
import {User} from "./user";

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './app.login-component.html',
  imports: [
    FormsModule,
    RouterLink
  ],
  providers: [UserDataService]
})
export class AppLoginComponent {
  user: User = new User();

  constructor(private userDataService: UserDataService, private router: Router) {}

  onLogin() {
    this.userDataService.login(this.user).subscribe({
      next: (token) => {
        this.userDataService.saveToken(token);
        this.router.navigate(['/']); // После логина идем на главную
      },
      error: () => alert('Ошибка входа')
    });
  }

}
