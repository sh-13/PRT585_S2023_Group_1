import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Core/Components/navbar/navbar.component';
import { CarListComponent } from './Car/Components/car-list/car-list.component';
import { HttpClientModule } from '@angular/common/http';
import { UserLoginComponent } from './User/Components/user-login/user-login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserRegistrationComponent } from './User/Components/user-registration/user-registration.component';
import { CarDetailsComponent } from './Car/Components/car-details/car-details.component';
import { HomeComponent } from './Core/Components/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CarListComponent,
    UserLoginComponent,
    UserRegistrationComponent,
    CarDetailsComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
