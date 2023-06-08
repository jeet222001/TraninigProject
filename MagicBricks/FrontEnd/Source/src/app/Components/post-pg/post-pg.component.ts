import { Component,  Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-post-pg',
  templateUrl: './post-pg.component.html',
  styleUrls: ['./post-pg.component.css']
})
export class PostPGComponent implements OnInit {
  title = 'newMat';
     
  isLinear = true;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  constructor(private _formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      amount: ['', Validators.required],
      stock: ['', Validators.required]
    });  }

    submit(){
      console.log(this.firstFormGroup.value);
      console.log(this.secondFormGroup.value);
  }
}

