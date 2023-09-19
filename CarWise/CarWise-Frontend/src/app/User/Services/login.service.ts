import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { User } from '../Models/user.model';

@Injectable({ providedIn: 'root' })
export class LoginService {
  private userSubject: BehaviorSubject<User | null>;
  public user: Observable<User | null>;

  constructor(private router: Router, private http: HttpClient)
  {
    this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
    this.user = this.userSubject.asObservable();
  }

  public get userValue() {
    return this.userSubject.value;
  }

  login(UserEmail: string, UserPassword: string) {
    return this.http.post<User>('https://localhost:7246/api/User/login?UserEmail=' + UserEmail + '&UserPassword=' + UserPassword, { UserEmail, UserPassword }, {withCredentials: true})
      .pipe(
        map(user => {
          if (user === null) {
            throw new Error('Invalid credentials'); // Throw an error if user is null
          }
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('user', JSON.stringify(user));
          this.userSubject.next(user);
          return user;
        }),
        catchError(error => {
          // Handle the error here, e.g., log it or perform any specific actions
          // console.error('Login error:', error);
          throw error; // Re-throw the error to propagate it further
        })
    );
  }

  logout() {
      // remove user from local storage and set current user to null
      localStorage.removeItem('user');
      this.userSubject.next(null);
      this.router.navigate(['/user/login']);
  }
}
