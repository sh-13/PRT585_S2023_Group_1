import { Component } from '@angular/core';
import { AddEmployeeRequest } from '../../models/add-employee-request.model';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  model: AddEmployeeRequest;

  constructor(private employeeService: EmployeeService, private router: Router){
    this.model = {
      EmployeeId: 0,
      EmployeeName: ''
    };
  }

  onAddEmployeeSubmit(){
    this.employeeService.addEmployee(this.model).subscribe({
      next:(response) => {
        alert(this.model.EmployeeName + " added successfully with id " + response.EmployeeId);
        this.router.navigate(['/employee/']);
      }
    })
  }
}
