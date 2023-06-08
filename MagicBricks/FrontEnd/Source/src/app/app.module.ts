import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNavComponent } from './Components/top-nav/top-nav.component';
import { SignupComponent } from './Components/signup/signup.component';
import { AboutComponent } from './Components/about/about.component';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { HomeComponent } from './Components/home/home.component';
import { PostPropertyComponent } from './Components/post-property/post-property.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PostPGComponent } from './Components/post-pg/post-pg.component';
import {MatStepperModule} from '@angular/material/stepper';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginPageComponent } from './Components/login-page/login-page.component';
import { PaginationComponent } from './Components/pagination/pagination.component';
import { JwPaginationModule } from 'jw-angular-pagination';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { PropertyListComponent } from './Components/property-list/property-list.component';
import { MyProfileComponent } from './Components/my-profile/my-profile.component';
import { PropertyDetailsComponent } from './Components/property-details/property-details.component';
@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
    SignupComponent,
    AboutComponent,
    NavbarComponent,
    HomeComponent,
    PostPropertyComponent,
    PostPGComponent,
    LoginPageComponent,
    PaginationComponent,
    DashboardComponent,
    PropertyListComponent,
    MyProfileComponent,
    PropertyDetailsComponent,

    
  ],
  imports: [
    AppRoutingModule,
    HttpModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatListModule,
    JwPaginationModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
