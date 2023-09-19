import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../Models/user.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationService } from '../../Services/registration.service';
import { first } from 'rxjs/operators';



@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit{
  form!: FormGroup;
  loading = false;
  model: User;
  submitted = false;
  error?: string;

  constructor(
    private formBuilder: FormBuilder,
    private registrationService: RegistrationService,
    private router: Router
  ) {
      this.model = {
        UserEmail: "",
        UserFirstName: "",
        UserLastName: "",
        UserPassword: ""
      };
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      UserEmail: ['', Validators.required],
      UserPassword: ['', Validators.required],
      UserFirstName: ['', Validators.required],
      UserLastName: ['', Validators.required]
    });
  }

  get f() { return this.form.controls; }

  onRegisterUserSubmit(){
    this.submitted = true;

    // reset alert on submit
    this.error = '';

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.model.UserEmail = this.f['UserEmail'].value,
    this.model.UserFirstName = this.f['UserFirstName'].value,
    this.model.UserLastName = this.f['UserLastName'].value,
    this.model.UserPassword = this.f['UserPassword'].value,

    this.registrationService.addUser(this.model)
    .pipe(first())
    .subscribe({
      next:(response) => {
        alert(this.model.UserFirstName + this.model.UserLastName + " added successfully");
        this.router.navigate(['/user/login']);
      },
      error: error => {
        console.log("error");
        this.error = error;
        this.loading = false;
      }
    });
  }
}