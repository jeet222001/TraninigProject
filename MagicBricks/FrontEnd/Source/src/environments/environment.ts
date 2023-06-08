// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { HttpHeaders } from "@angular/common/http";

export const environment = {
  production: false,
 apiURL: 'https://localhost:44365',
  endpoints: 'api/Country',
  CityendPoint: 'api/City',
  AppobjType: 'api/ApplicationObjectType',
  AddUser: 'bricks/Signup/users',
  otpVerify: 'bricks/Signup/verifyOtp',
  Login: 'api/login',
  Property:'api/Properties',
  PropertyDetails:'api/PropertyDetails',
  Images:'api/Images',
  path :"https://localhost:44365/Images/",
  ContactOwner:"api/ContactOwner",
  httpOptions: {
    headers: new HttpHeaders({
      'content-Type': 'application/json'
    }),
  },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
