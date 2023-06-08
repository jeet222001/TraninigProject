import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import ApplicationObjectType from 'src/app/Models/ApplicationObjectType';
import { CrudserviceService } from 'src/app/Services/crudservice.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  Floors: number[] = new Array(63);
  AppObjTypes!: ApplicationObjectType[];
  AgeOfConstruction: string[] = ['New Construction', 'less than 5 Years', '5 to 10 Years',
    '10 To 15 Years', '15 To 20 Years', 'Above 20 Years'];
  PosessionStatus!: string;
  Properties: any;
  PropertiesA:any;
  id!: number;
  uId = localStorage.getItem("id");
  showShortDesciption: boolean = true;
  furnishedStatus: string = 'fstatus';
  Floor: number = -1;
  AgeOfConstructions!: string
  MinPrice!: number
  MaxPrice!: number
  BedRooms!: number
  PropertyFor: number = -1;
  CarpetArea!: number;
  constructor(
    private crud: CrudserviceService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router
  ) { }
  path = environment.path;
  ngOnInit(): void {
    this.route.params.subscribe((p: any) => {
      this.id = p["id"];
      this.GetPropertyonType();
    });
  }
  
  ContactOwnerForm = this.fb.group({
    name: [''],
    email: [''],
    phone: ['']
  })
  GetPropertyonType() {
    this.crud.GetPropertiesDetails().subscribe(data => {
      this.Properties = data.filter((x: any) => x.propertyTypeId == this.id);
      this.PropertiesA = this.Properties;
      console.log(this.Properties);
    })
  }
  alterDescriptionText() {
    this.showShortDesciption = !this.showShortDesciption
  }
  ContactOwner() {
    if (this.uId == null) {
      this.router.navigate(['/login']);
    }
    this.crud.ContactOwner(this.ContactOwnerForm.value).subscribe(data => {
      if (data.Status == 200) {
        return data.Message;
      }
    })
  }
  filterByfloor(e: any) {
    this.PropertiesA = this.Properties.filter((val:any) =>   val.floorNo==this.Floor)
    }
    filterByBudget(){
      this.PropertiesA = this.Properties.filter((val:any)=>val.price>=this.MinPrice&&val.price<=this.MaxPrice)
    }
  FilterProperties() {
    this.PropertiesA = this.Properties.filter((x: any) => {
      return (
        x.brsId == this.PropertyFor 
      )
    })
  }
  log() {
    console.log(this.PosessionStatus);
  }
}
