import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CarService } from '../car.service';

@Component({
  selector: 'app-car-form',
  templateUrl: './car-form.component.html',
})
export class CarFormComponent implements OnInit {

  carForm: FormGroup;
  cars: any[] = [];

  constructor(private fb: FormBuilder, private carService: CarService) {
    this.carForm = this.fb.group({
      id: [''],
      carname: [''],
      carmodel: ['']
    });
  }

  ngOnInit(): void {
    this.loadCars();
  }

  loadCars() {
    this.carService.getCars().subscribe(data => {
      this.cars = data as any[];
    });
  }

  onSubmit() {
    if (this.carForm.value.id) {
      this.carService.updateCar(this.carForm.value).subscribe(() => {
        this.loadCars();
        this.carForm.reset();
      });
    } else {
      this.carService.createCar(this.carForm.value).subscribe(() => {
        this.loadCars();
        this.carForm.reset();
      });
    }
  }

  onEdit(car: any) {
    this.carForm.setValue({
      id: car.id,
      carname: car.carname,
      carmodel: car.carmodel
    });
  }

  onDelete(id: number) {
    this.carService.deleteCar(id).subscribe(() => {
      this.loadCars();
    });
  }
}
