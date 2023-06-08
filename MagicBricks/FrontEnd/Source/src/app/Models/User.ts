import Property from "./Property";

export default interface User{
    UserId: number|null;
    UserTypeId: number|null;
    Name: string|null;
    Email: string|null;
    DateReg?: Date|null;
    PhoneNo: string|null;
    Otpno: string|null;
    Password: string|null;
    Property?: Property[]|null;
}