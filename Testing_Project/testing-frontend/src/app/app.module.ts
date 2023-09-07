import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Core/Components/navbar/navbar.component';
import { StudentListComponent } from './Student/Components/student-list/student-list.component';
import { AddStudentComponent } from './Student/Components/add-student/add-student.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UpdateStudentComponent } from './Student/Components/update-student/update-student.component';
import { EmployeeListComponent } from './Employee/Components/employee-list/employee-list.component';
import { AddEmployeeComponent } from './Employee/Components/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './Employee/Components/update-employee/update-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    StudentListComponent,
    AddStudentComponent,
    UpdateStudentComponent,
    EmployeeListComponent,
    AddEmployeeComponent,
    UpdateEmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
