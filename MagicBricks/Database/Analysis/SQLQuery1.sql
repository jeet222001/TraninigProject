CREATE TABLE ApplicationObject(
AppObjid INT CONSTRAINT pk_appobjID PRIMARY KEY,
ObjectName VARCHAR(25)
)

CREATE TABLE ApplicationObjectType(
TypeID INT CONSTRAINT pk_typeID PRIMARY KEY,
AppObjid INT CONSTRAINT fk_appobjID FOREIGN KEY REFERENCES ApplicationObject(AppObjID) ON DELETE SET NULL,
TypeName VARCHAR(50)
)

CREATE TABLE [User](
UserID INT CONSTRAINT pk_userID PRIMARY KEY,
UserTypeID INT CONSTRAINT fk_userTypeID FOREIGN KEY REFERENCES ApplicationObjectType(TypeID) ON DELETE SET NULL,
[Name] VARCHAR(50),
Email VARCHAR(254),
[Password] VARCHAR(128),
Date_Reg DATE,
PhoneNo VARCHAR(13),
OTPNo INT
)

CREATE TABLE Property(
PropertyID INT CONSTRAINT pk_PropID PRIMARY KEY,
UserID INT CONSTRAINT fk_userProp FOREIGN KEY REFERENCES [User](UserID),
BRS_ID INT CONSTRAINT fk_PropObjTID FOREIGN KEY REFERENCES ApplicationObjectType(TypeID),
PropertyTypeID INT CONSTRAINT fk_PropType FOREIGN KEY REFERENCES ApplicationObjectType(TypeID),
[Name] VARCHAR(50),
PropertyDescription VARCHAR(250),
Price MONEY,
DepositeAmount MONEY,
Facing_ID INT CONSTRAINT fk_Facing FOREIGN KEY REFERENCES ApplicationObjectType(TypeID),
[Floor] INT,
Bedroom VARCHAR(5),
)

CREATE TABLE PropertyFacility(
FacilityID INT CONSTRAINT pk_Propfaci PRIMARY KEY,
PropertyID INT CONSTRAINT fk_PropID FOREIGN KEY REFERENCES Property(PropertyID),
Food BIT,
AC BIT,
WIFI BIT,
Sunday_Meal BIT,
Laundry BIT,
ElectricCharge BIT,
PowerBackup BIT,
Lift BIT,
NoticePeriodMonth INT,
Sharing_ID INT CONSTRAINT fk_Shar FOREIGN KEY REFERENCES ApplicationObjectType(TypeID),
BGC_ID INT CONSTRAINT fk_bgc FOREIGN KEY REFERENCES ApplicationObjectType(TypeID),
Preferred_Tenants INT CONSTRAINT fk_tenant FOREIGN KEY REFERENCES ApplicationObjectType(TypeID),
)

CREATE TABLE countries(
CountryID INT CONSTRAINT pk_country PRIMARY KEY,
shortname CHAR(3),
[name] VARCHAR(150),
phonecode INT
)

CREATE TABLE states(
StateID INT CONSTRAINT pk_state PRIMARY KEY,
[name] VARCHAR(30),
CountryID INT CONSTRAINT fk_country FOREIGN KEY REFERENCES countries(CountryID)
)

CREATE TABLE cities(
CityID INT CONSTRAINT pk_city PRIMARY KEY,
[name] VARCHAR(30),
StateID INT CONSTRAINT fk_city FOREIGN KEY REFERENCES states(StateID)
)

CREATE TABLE [Location](
LocationID INT CONSTRAINT pk_LocID PRIMARY KEY,
AddressLine1 VARCHAR(50),
AddressLine2 VARCHAR(50),
CityID INT,
Pincode INT,
PropertyID INT CONSTRAINT fk_PropLoc FOREIGN KEY REFERENCES Property(PropertyID)
)

CREATE TABLE [Image](
ImageID INT CONSTRAINT pk_Img PRIMARY KEY,
ImageURL VARCHAR(100),
PropertyID INT CONSTRAINT fk_PropImg FOREIGN KEY REFERENCES Property(PropertyID)
)

CREATE TABLE ContactOwner(
ID INT CONSTRAINT pk_Cont PRIMARY KEY,
[Name] VARCHAR(50),
Email VARCHAR(50),
PhoneNo VARCHAR(13),
OTPNo INT,
PrpertyID INT CONSTRAINT fk_PropContID FOREIGN KEY REFERENCES Property(PropertyID)
)