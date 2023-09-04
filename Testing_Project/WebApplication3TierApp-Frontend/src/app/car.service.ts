import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private API_URL = 'https://localhost:7246/api/Car';

  constructor(private http: HttpClient) { }

  getCars() {
    return this.http.get(this.API_URL);
  }

  getCarById(id: number) {
    return this.http.get(`${this.API_URL}${id}`);
  }

  createCar(carData: any) {
    return this.http.post(this.API_URL, carData);
  }

  updateCar(carData: any) {
    return this.http.put(`${this.API_URL}update`, carData);
  }

  deleteCar(id: number) {
    return this.http.delete(`${this.API_URL}${id}`);
  }
}
