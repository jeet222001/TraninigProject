import Images from "./Images";
import Locations from "./Locations";
import PropertyFacility from "./PropertyFacility";

export default interface property{
PropertyID?:number|null;
PropertyTypeID:number|null;
PropertyDescription:string|null;
BrsId:number|null;
UserID:number|null;
Locations?:Locations[]|null;
PropertyFacilities?:PropertyFacility[]|null;
Image?:Images[]|null;
}