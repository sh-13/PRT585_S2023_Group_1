import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car.model';

@Injectable({ providedIn: 'root' })
export class CarService {

  constructor(private http: HttpClient) { }

  // addCar(model: AddCarRequest): Observable<AddCarRequest> {
  //   return this.http.post<AddCarRequest>('https://localhost:7246/api/Car', model, {withCredentials: true})
  // }

  showCars(): Observable<Car[]> {
    return this.http.get<Car[]>('https://localhost:7246/api/Car', {withCredentials: true})
  }

  showMultipleCars() {
    return this.http.get<Car[]>('https://localhost:7246/api/Car', {withCredentials: true});
  }

  getById(id: number | string) {
    return this.http.get<Car>('https://localhost:7246/api/Car/' + id, {withCredentials: true});
  }

  // getCar(carId: number): Observable<Car>{
  //   return this.http.get<Car>('https://localhost:7246/api/Car/' + carId, {withCredentials: true})
  // }

  // removeCar(carId: number): Observable<void>{
  //   return this.http.delete<void>('https://localhost:7246/api/Car/' + carId, {withCredentials: true})
  // }

  // updateCar(model: UpdateCarRequest): Observable<UpdateCarRequest> {
  //   return this.http.put<UpdateCarRequest>('https://localhost:7246/api/Car/update', model, {withCredentials: true})
  // }
}
