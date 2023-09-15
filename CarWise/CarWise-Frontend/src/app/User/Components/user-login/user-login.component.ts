import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { LoginService } from '../../Services/login.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
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
      if (this.loginService.userValue) {
          this.router.navigate(['/']);
      }
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      UserEmail: ['', Validators.required],
      UserPassword: ['', Validators.required]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alert on submit
    this.error = '';

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.loginService.login(this.f['UserEmail'].value, this.f['UserPassword'].value)
      .pipe(first())
      .subscribe({
          next: () => {
            console.log("Correct");
            this.router.navigate(['/car']);
          },
          error: error => {
            console.log("error");
            this.error = error;
            this.loading = false;
          }
      });
  }
}
