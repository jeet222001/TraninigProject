import { HttpHeaders } from "@angular/common/http";

export const environment = {
  production: true,
  apiURL: 'http://magicbrics-2392-jeet-api.radixind.in',
  endpoints: 'api/Country',
  CityendPoint: 'api/City',
  AppobjType: 'api/ApplicationObjectType',
  AddUser: 'bricks/Signup/users',
  otpVerify: 'bricks/Signup/verifyOtp',
  Login: 'api/login',
  Property:'api/Properties',
  PropertyDetails:'api/PropertyDetails',
  Images:'api/Images',
  path :"http://magicbrics-2392-jeet-api.radixind.in/Images/",
  ContactOwner:"api/ContactOwner",
  httpOptions: {
    headers: new HttpHeaders({
      'content-Type': 'application/json'
    })
}
}
