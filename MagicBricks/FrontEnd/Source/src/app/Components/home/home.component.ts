import { Component, OnInit } from '@angular/core';
import ApplicationObjectType from 'src/app/Models/ApplicationObjectType';
import Cities from 'src/app/Models/Cities';
import { CrudserviceService } from 'src/app/Services/crudservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  Cities!: Cities[];
  AppObjTypes!: ApplicationObjectType[];

 
  constructor(private crud: CrudserviceService) { }
  Properties!: any
  Properties2!: any

  ngOnInit(): void {
    this.GetPropertyTypes();
    this.GetCities();
  }

  private GetPropertyTypes() {
    this.crud.getAllAppObjTypes().subscribe(data => {
      this.AppObjTypes = data.filter(x => x.appObjid == 9);
      console.log(this.AppObjTypes);

    });
  }
  private GetCities() {
    this.crud.getAllCities().subscribe(data => {
      this.Cities = data;
      // console.log(this.Cities);
    });
  }
 


}
