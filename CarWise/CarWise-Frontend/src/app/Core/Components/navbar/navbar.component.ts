import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/User/Models/user.model';
import { LoginService } from 'src/app/User/Services/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  user?: User | null;

  constructor(private loginService: LoginService, private router: Router,) {
    this.loginService.currentUserSubject.subscribe(x => this.user = x);
  }

  logout() {
    this.loginService.logout();
  }

  userhome() {
    this.router.navigate(['/']);
  }
}
