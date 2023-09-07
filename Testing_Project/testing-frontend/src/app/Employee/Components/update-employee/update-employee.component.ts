import { Component } from '@angular/core';
import { UpdateEmployeeRequest } from '../../models/update-employee-request.model';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent {
  model: UpdateEmployeeRequest;

  constructor(private employeeService: EmployeeService, private router: Router){
    this.model = {
      EmployeeId: 0,
      EmployeeName: ''
    };
  }

  onUpdateEmployeeSubmit(){
    this.employeeService.updateEmployee(this.model).subscribe({
      next: () => {
        alert('Employee update successfully');
        this.router.navigate(['/employee/']);
      },
      error: (error) => {
        alert('Error updateing employee. Please try again.');
      }
    });
  }
}
