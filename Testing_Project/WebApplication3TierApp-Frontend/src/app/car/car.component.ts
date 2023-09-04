import { Component, OnInit } from '@angular/core';
import { CarService } from '../car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
})
export class CarComponent implements OnInit {
  cars: any[] = [];
  selectedCar: any;

  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.loadCars();
  }

  loadCars() {
    this.carService.getCars().subscribe(data => {
      this.cars = data as any[];
    });
  }

  onEdit(car: any) {
    this.selectedCar = car;
  }

  onDelete(id: number) {
    this.carService.deleteCar(id).subscribe(() => {
      this.loadCars();
    });
  }

  onCarSaved(car: any) {
    this.loadCars();
    this.selectedCar = null;
  }
}
