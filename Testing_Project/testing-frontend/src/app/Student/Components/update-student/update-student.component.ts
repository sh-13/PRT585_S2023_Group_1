import { Component } from '@angular/core';
import { UpdateStudentRequest } from '../../models/update-student-request.model';
import { StudentService } from '../../services/student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-student',
  templateUrl: './update-student.component.html',
  styleUrls: ['./update-student.component.css']
})
export class UpdateStudentComponent {
  model: UpdateStudentRequest;

  constructor(private studentService: StudentService, private router: Router){
    this.model = {
      StudentId: 0,
      StudentName: ''
    };
  }

  onUpdateStudentSubmit(){
    this.studentService.updateStudent(this.model).subscribe({
      next: () => {
        alert('Student update successfully');
        this.router.navigate(['/student/']);
      },
      error: (error) => {
        alert('Error updateing student. Please try again.');
      }
    });
  }
}
