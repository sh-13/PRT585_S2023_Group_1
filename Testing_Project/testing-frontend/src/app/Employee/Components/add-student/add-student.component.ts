import { Component } from '@angular/core';
import { AddStudentRequest } from '../../models/add-employee-request.model';
import { StudentService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  model: AddStudentRequest;

  constructor(private studentService: StudentService, private router: Router){
    this.model = {
      StudentId: 0,
      StudentName: ''
    };
  }

  onAddStudentSubmit(){
    this.studentService.addStudent(this.model).subscribe({
      next:(response) => {
        alert(this.model.StudentName + " added successfully with id " + response.StudentId);
        this.router.navigate(['/student/']);
      }
    })
  }
}
