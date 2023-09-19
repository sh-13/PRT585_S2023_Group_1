import { Component, OnInit } from '@angular/core';
import { Car } from '../../models/car.model';
import { CarService } from '../../services/car.service';
import { BehaviorSubject, catchError, of, tap } from 'rxjs';


@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  cars: Car[] = [];
  _cars$ = new BehaviorSubject<Car[]>([]);

  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.carService.showCars().subscribe((data) => {
      this.cars = data;
    });

    // this.carService
    //   .showMultipleCars()
    //   .pipe(
    //     tap((res: Car[]) => {
    //       console.log('res.items', res);

    //       this._cars$.next(res);
    //     }),
    //     catchError((err) => {
    //       console.log('error.items', err);
    //       return of([]);
    //     })
    //   )
    //   .subscribe();
  }
}

