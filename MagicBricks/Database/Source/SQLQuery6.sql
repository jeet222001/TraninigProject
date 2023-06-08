USE [magicbrics-2392-jeet]
GO

/****** Object:  View [dbo].[VwPropertyDetails]    Script Date: 26-08-2022 18:45:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter view [dbo].[VwPropertyDetails]
as
select p.BRS_ID,p.PropertyDescription,p.PropertyTypeID,p.UserID,pf.AgeOfConstruction,pf.AvailableFrom,
pf.Balconies,pf.Bathrooms,pf.Bedrooms,pf.BGC_ID,pf.FloorNo,pf.FurnishedStatus,pf.PossessionStatus,pf.Price,pf.SuperArea,
pf.TokenAmount,pf.TotalFloors,
u.[Name],u.Email,u.PhoneNo,i.Imagename,
l.AddressLine1,l.AddressLine2,l.Pincode,c.[name] CityName,s.[name] StateName,ct.[name] CountryName
from Property p
join PropertyFacility pf
	on p.PropertyID=pf.PropertyID
join [User] u
	on p.UserID =u.UserID
join [Image] i
	on	p.PropertyID=i.PropertyID
join [Location] l
	on p.PropertyID=l.PropertyID
	join [cities] c
		on c.CityID=l.CityID
			join [states] s
				on	s.StateID = c.StateID
					join countries ct
						on	s.CountryID=ct.CountryID
GO


