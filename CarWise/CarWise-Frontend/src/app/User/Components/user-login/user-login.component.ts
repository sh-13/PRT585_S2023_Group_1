import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { LoginService } from '../../Services/login.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
})
export class UserLoginComponent implements OnInit {
  defaultAuth: any = {
    UserEmail: 'durvesh@gmail.com',
    UserPassword: '1234567890',
  };

  form!: FormGroup;
  loading = false;
  submitted = false;
  error?: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private loginService: LoginService
  ) {
    // redirect to home if already logged in
    if (this.loginService.currentUserSubject) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      UserEmail: [this.defaultAuth.UserEmail, Validators.required],
      UserPassword: [this.defaultAuth.UserPassword, Validators.required],
    });
  }

  navigateToRegistration() {
    // ... some logic here if needed
    this.router.navigate(['/registration']);
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;

    // reset alert on submit
    this.error = '';

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.loginService
      .login(this.f['UserEmail'].value, this.f['UserPassword'].value)
      .pipe(first())
      .subscribe({
        next: (response) => {
          if (response) {
            this.router.navigate(['/car']);
          } else {
            this.error = "error";
            this.loading = false;
          }
        },
        error: (error) => {
          this.error = error;
          this.loading = false;
        },
      });
  }

  /*   submit() {
    this.hasError = false;
    const loginSubscr = this.authService
      .login(this.f.emailAddress.value, this.f.password.value)
      .pipe(first())
      .subscribe((user: UserModel | undefined) => {
        if (user) {
          this.router.navigate([this.returnUrl]);
        } else {
          this.hasError = true;
        }
      });
    this.unsubscribe.push(loginSubscr);
   }*/
}
