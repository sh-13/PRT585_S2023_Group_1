import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentListComponent } from './Student/Components/student-list/student-list.component';
import { AddStudentComponent } from './Student/Components/add-student/add-student.component';
import { UpdateStudentComponent } from './Student/Components/update-student/update-student.component';
import { EmployeeListComponent } from './Employee/Components/employee-list/employee-list.component';
import { AddEmployeeComponent } from './Employee/Components/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './Employee/Components/update-employee/update-employee.component';

const routes: Routes = [
  {
    path: 'student',
    component: StudentListComponent
  },
  {
    path: 'student/add',
    component: AddStudentComponent
  },
  {
    path: 'student/update',
    component: UpdateStudentComponent
  },
  {
    path: 'employee',
    component: EmployeeListComponent
  },
  {
    path: 'employee/add',
    component: AddEmployeeComponent
  },
  {
    path: 'employee/update',
    component: UpdateEmployeeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
