import { Component } from '@angular/core';
import { Car } from '../../models/car.model';
import { CarService } from '../../services/car.service';
import { Subscription, catchError, first, of, switchMap } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

const EMPTY_CAR: Car = {
  CarId: 0,
  CarCompanyName: '',
  CarModelName: '',
  CarType: '',
  CarBuildYear: 0,
  CarColour: '',
  CarOdometer: 0,
  CarSeat: 0,
  CarRentPrice: 0,
  CarImage: '',
};

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css'],
})
export class CarDetailsComponent {
  CarId: string | null | undefined;
  loading = false;
  NumID: number | undefined;
  car: Car;

  private subscriptions: Subscription[] = [];
  constructor(
    private carService: CarService,
    private route: ActivatedRoute
  ) {
    this.car = EMPTY_CAR;
  }

  ngOnInit(): void {   
    this.route.paramMap.subscribe(params => {
      // Get the 'id' parameter from the URL as a string
      const idString = params.get('id');
  
      if (idString) {
        // Convert the string to a number using parseInt or parseFloat
        const idNumber = parseInt(idString, 10); // Use parseInt with base 10
        // Or, if it's a floating-point number, you can use parseFloat
        // const idNumber = parseFloat(idString);
  
        if (!isNaN(idNumber)) {
          this.carService.getById(idNumber).subscribe((data) => {
            this.car = data
          })
          // Check if the conversion was successful and idNumber is a valid number
          console.log('ID as a number:', idNumber);
        } else {
          console.error('Invalid ID:', idString);
        }
      }
    });

    // const sb = this.route.paramMap
    //   .pipe(
    //     switchMap((params) => {
    //       // get _id from URL
    //       this.CarId = params.get('id');
    //       console.log('params', params);
    //       if (this.CarId) {
    //         console.log("Sahil")
    //         return this.carService.getById(this.CarId);
    //       }
    //       else{
    //         console.log("SAHIL")
    //         return of(EMPTY_CAR);
    //       }
    //     }),
    //     catchError((errorMessage) => {
    //       console.log('errorMessage', errorMessage);
    //       return of(undefined);
    //     })
    //   )
    //   .subscribe((res: any) => {
    //     if (!res) {
    //       console.log("SAHIL")
    //       /* this.router.navigate(['/cars'], {
    //         relativeTo: this.route,
    //       }); */
    //     }

    //     let response: any;

    //     this.car = Object.assign(EMPTY_CAR, res);
    //   });
    // this.subscriptions.push(sb);
    console.log(this.car);
  }

  ngOnDestroy() {
    this.subscriptions.forEach((sb) => sb.unsubscribe());
  }
}
