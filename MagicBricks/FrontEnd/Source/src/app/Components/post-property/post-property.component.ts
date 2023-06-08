import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CrudserviceService } from '../../Services/crudservice.service';
import ApplicationObjectType from '../../Models/ApplicationObjectType';
import Country from '../../Models/country';
import Cities from '../../Models/Cities';
import User from 'src/app/Models/User';
import Property from 'src/app/Models/Property';
import { Router } from '@angular/router';
@Component({
  selector: 'app-post-property',
  templateUrl: './post-property.component.html',
  styleUrls: ['./post-property.component.css']
})
export class PostPropertyComponent implements OnInit {
  brsId!:number;
  BgcId!:number;
  //Arrays----------------------------------------
  Properties!: Property[];
  Cities!: Cities[];
  NoOfBedrooms: Array<number> = new Array(10);
  TotalFloors: Array<number> = new Array(60);
  Balconies: Array<number> = new Array(10);
  NoOfBathrooms: Array<number> = new Array(10);
  FloorNo: number[] = new Array(63);
  Year: number[] = new Array(12);
  AgeOfConstruction: string[] = ['New Construction', 'less than 5 Years', '5 to 10 Years',
    '10 To 15 Years', '15 To 20 Years', 'Above 20 Years'];
  PropertyType: string = '';
  FurnishedStatus: string[] = ['Furnished', 'Unfurnished', 'Semi Furnished'];
  AreaMeasure: string[] = ['Sq-ft', 'Sq-yrd', 'Sq-M', 'Acre', 'Bigha',
    'Hectare', 'Marla', 'Kanal', 'Biswa1', 'Biswa2', 'Ground', 'Aankadam', 'Rood',
    'Chatak', 'Kottah', 'Cent', 'Perch', 'Guntha', 'Are'];
  Month: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
  PosessionStatus: string = '';
  Countries!: Country[];
  AppObjTypes!: ApplicationObjectType[];
  PropertyPoster!: ApplicationObjectType[];
  ImageTypes!: ApplicationObjectType[];
  propertyTypeId:number=-1
  Sharing:number[]=new Array(6);
  //Arrays----------------------------------------
  id = localStorage.getItem("id");
  users!: User;
  isFileValid: boolean = false;
  constructor(
    private fb: FormBuilder,
    private crud: CrudserviceService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    if (this.id == null) this.router.navigate(['/login']);
    this.GetUsers(Number(this.id));
    this.GetPropertyTypes();
    this.GetCountries();
    this.GetCities();
    this.GetPropertyPoster();
    this.GetImageTypes();
  }

  PropertyForm = this.fb.group({
    user: this.fb.group({
      UserTypeId: [0],
      Name: [''],
      Mobile: [''],
      Email: [''],
    }),
    userId: [Number(this.id)],
    propertyTypeId: [0],
    brsId: [],
    propertyDescription: [''],
    locations: this.fb.array([
      this.fb.group({
        CityId: [],
        AddressLine1: [''],
      })
    ]),
    propertyFacilities: this.fb.array([
      this.fb.group({
        Bedrooms: [],
        Balconies: [],
        FloorNo: [Validators.required,Validators.nullValidator],
        TotalFloors: [],
        FurnishedStatus: [''],
        Bathrooms: [],
        food:[],
        Ac:[],
        BgcId:[],
        Wifi:[],
        SundayMeal:[],
        Laundry:[],
        ElectricCharge:[],
        PowerBackup:[],
        Lift:[],
        NoticePeriodMonth:[],
        SharingId:[],
        CarpetArea: [],
        SuperArea: [],
        posessionStatus: [''],
        AvailableFrom: [''],
        AgeOfConstruction: [''],
        Price: [],
        TokenAmount: [],
      })
    ]),

    images: this.fb.array([
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [44]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [45]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [46]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [47]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [48]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [49]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [50]
      }),
      this.fb.group({
        File: [],
        Imagename: [''],
        ImageTypeId: [51]
      })
    ]),
  });
  private GetPropertyPoster() {
    this.crud.getAllAppObjTypes().subscribe(data => {
      this.PropertyPoster = data.filter(x => x.appObjid == 7);
      // console.log(this.PropertyPoster);
    });
  }
  private GetCities() {
    this.crud.getAllCities().subscribe(data => {
      this.Cities = data;
      // console.log(this.Cities);
    });
  }
  private GetUsers(id: number) {
    this.crud.GetUser(id).subscribe(data => {
      this.users = data
      console.log(data);
      this.PropertyForm.value != null ?
        this.PropertyForm.controls.user.setValue({
          UserTypeId: this.users.UserTypeId,
          Name: this.users.Name,
          Mobile: this.users.PhoneNo,
          Email: this.users.Email
        }) :
        console.log(this.PropertyForm.value);
    })
  }
  private GetCountries() {
    this.crud.getAll().subscribe(data => {
      this.Countries = data;
      // console.log(this.Countries);
    });
  }
  private GetPropertyTypes() {
    this.crud.getAllAppObjTypes().subscribe(data => {
      this.AppObjTypes = data.filter(x => x.appObjid == 9);
      console.log(this.AppObjTypes);
    });
  }
  private GetImageTypes() {
    this.crud.getAllAppObjTypes().subscribe(data => {
      this.ImageTypes = data.filter(x => x.appObjid == 8);
      // console.log(this.ImageTypes)
    })
  }

 ImageToBuffer(event: any, index: number) {
    var basestr: any;
    var component = this;
    var file = event.target.files[0];
    console.log(event.target.files[0]);
    var filename = file.name;
    var reader = new FileReader();
    reader.readAsBinaryString(file);
    reader.onload = function () {
      basestr = btoa(<string>reader.result);
      var  array =  component.PropertyForm.controls.images as FormArray;
      var Group = array.at(index) as FormGroup;
      Group.controls['File'].setValue(basestr);
      Group.controls['Imagename'].setValue(filename);
    // console.log(basestr);
    };
    reader.onerror = function () {
      console.log('there are some problems');
    };
  }

  PostProperty() {
    console.log(this.PropertyForm.value);
    this.PropertyForm.controls.userId.setValue(Number(this.id));
    this.PropertyForm.controls.user.setValue({
      UserTypeId: null,
      Name: null,
      Mobile: null,
      Email: null
    });
    this.crud.PostProperty(this.PropertyForm.value).subscribe(data => {
      console.log(data);
    })
  }
  get Image() {
    return this.PropertyForm.get('images') as FormArray
  }
  get PropertyLocation() {
    return this.PropertyForm.get('locations') as FormArray;
  }
  get PropertyFeatures() {
    return this.PropertyForm.get('propertyFacilities') as FormArray;
  }


}
