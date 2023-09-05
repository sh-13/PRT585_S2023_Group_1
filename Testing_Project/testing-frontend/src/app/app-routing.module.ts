import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentListComponent } from './Student/student-list/student-list.component';
import { AddStudentComponent } from './Student/add-student/add-student.component';

const routes: Routes = [
  {
    path: 'student',
    component: StudentListComponent
  },
  {
    path: 'student/add',
    component: AddStudentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
