import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudserviceService } from 'src/app/Services/crudservice.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {
Properties!:any;
id!:number;
path = environment.path;

uId=localStorage.getItem("id");
  constructor(
    private crud:CrudserviceService,
    private route:ActivatedRoute,
    private router:Router,
    private fb:FormBuilder
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((p: any) => {
      this.id = p["id"];
      this.GetProperties();
    });
  }
  ContactOwnerForm = this.fb.group({
    name: [''],
    email: [''],
    phone: ['']
  })
  GetProperties(){
    this.crud.GetPropertiesDetails().subscribe(data => {
      this.Properties = data.filter((x: any)=>x.propertyId==this.id); 
          console.log(this.Properties);
    })
  }
  ContactOwner() {
    if(this.uId==null){
      this.router.navigate(['/login']);
    }
        this.crud.ContactOwner(this.ContactOwnerForm.value).subscribe(data => {
          if (data.Status == 200) {
            return data.Message;
          }
        })
      }
}
