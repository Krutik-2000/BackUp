create table ApplicationObjectType
(
	ObjectId int primary key identity(1,1),
	status varchar(20) not null
);

CREATE TABLE ObjectType(
TypeId  int primary key identity(1,1),
TypeValue varchar(20) not null,
ObjectId int foreign key references ApplicationObjectType(ObjectId)
)

CREATE TABLE USERS
(
	EmpId int Primary Key identity(1,1),
	EmpName varchar(50) not null,
	UserStatus int foreign key references ObjectType(TypeId),
);

CREATE TABLE Overtimes(
OtId int Primary Key identity(1,1),
EmpId int foreign key references USERS(EmpId),
OTDate Date not null,
ExpectedBillable int not null,
ActualBillable int not null,
ActualOvertime int not null,
OtStatus int foreign key references ObjectType(TypeId),
)

select* from Overtimes

select DATENAME(MM,OTDate)as Month,* from Overtimes order by EmpId

create Trigger datainsert
on Overtimes
after insert
as
begin
update Overtimes
set ActualOvertime = ActualBillable-ExpectedBillable
where EmpId = (select EmpId from inserted)
end

alter procedure calc
@Month varchar(30)
as
begin 
set @Month = (select  DATENAME(MM,OTDate) from Overtimes where EmpId = 1) 
if (@Month = 'January') 
begin
select ActualOvertime as Month from Overtimes  where EmpId = 1 
end
else if(@Month = 'February')
begin
select ActualOvertime as Month from Overtimes  where EmpId = 1 
end
else if(@Month = 'March')
begin
select ActualOvertime as Month from Overtimes  where EmpId = 1 
end
end

exec calc 'January'

select EmpId, DATENAME(MM,OTDate) as [Month], ActualOvertime from Overtimes 

SELECT * FROM USERS
SELECT * FROM vOvertimes

CREATE VIEW vOvertimes
AS
SELECT DISTINCT (SELECT EmpName FROM USERS AS U WHERE U.EmpId = O.EmpId) As EmpName,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 1) ,0) AS JAN,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 2) ,0) AS FEB,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 3) ,0) AS MARCH,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 4) ,0) AS APRIL,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 5) ,0) AS MAY,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 6) ,0) AS JUNE,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 7) ,0) AS JULY,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 8) ,0) AS AUG,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 9) ,0) AS SEPT,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 10) ,0) AS OCT,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 11) ,0) AS NOV,
COALESCE((SELECT OT.ActualOvertime FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId AND MONTH(OT.OTDate) = 12) ,0) AS DEC,
COALESCE((SELECT Sum(OT.ActualOvertime) FROM Overtimes As OT WHERE  OT.EmpId = O.EmpId ) ,0) AS [Total_OverTime]
 FROM Overtimes O
 
 