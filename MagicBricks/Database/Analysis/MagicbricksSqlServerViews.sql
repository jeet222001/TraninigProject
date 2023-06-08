create view vWGetPropertyType 
AS
Select TypeName
from ApplicationObjectType  apt
join ApplicationObject apo
on apt.AppObjid = apo.AppObjid
where apo.AppObjid=6

select * from vWGetPropertyType
