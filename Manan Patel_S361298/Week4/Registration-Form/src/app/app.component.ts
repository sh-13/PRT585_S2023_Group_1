import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  registrationForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    grade: ['', Validators.required],
    dob: ['', Validators.required],
    gender: ['', Validators.required],
    terms: [false, Validators.requiredTrue]
  });

  constructor(private fb: FormBuilder) { }

  onSubmit() {
    console.log(this.registrationForm.value);
  }
}
