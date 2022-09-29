Create table Users
(
UserId Int Primary Key Identity(1,1),
UserName varchar(20),
PasswordHash varbinary(200),
PasswordSalt varbinary(200),
Role int Foreign Key References TypeOfObject(TypeId)
)

ALTER TABLE Users
ALTER COLUMN PasswordSalt varchar(50); 


Create table PersonalDetails
(
PersonalDetails_Id Int Primary Key Identity(1,1),
First_Name  varchar(20),
Last_Name  varchar(20),
Email_Id varchar(50),
Mobile_Number Decimal,
Address varchar(200),
BirthDate Date,
Gender int Foreign Key References TypeOfObject(TypeId),
MaritalStatus int Foreign Key References TypeOfObject(TypeId),
Salary int NOT NULL,
Hire_Date Date,
Profile_Image varchar(MAX),
Department int Foreign Key References TypeOfObject(TypeId),
Post int Foreign Key References TypeOfObject(TypeId),
UserId int Foreign Key References Users(UserId)
)

Create table ObjectType
(
ObjectId int Primary Key Identity(1,1),
Value varchar(20) NOT NULL
)
Create table TypeOfObject
(
TypeId int Primary Key Identity(1,1),
Value varchar(20),
ObjectId int Foreign Key References ObjectType(ObjectId)
)
--DBCC CHECKIDENT ('[Employees]', RESEED, 0);


Create table Attendance
(
AttendanceId Int Primary Key Identity(1,1),
Date Date Not Null,
Attendance int  Foreign Key References TypeOfObject(TypeId),
UserId int Foreign Key References Users(UserId)
)


alter view VwSalaryCount AS
	select distinct(pd.salary / (DAY(EOMONTH(GETDATE())))) as perDaySalary,pd.UserId as Employee from  PersonalDetails as pd
	join Attendance as a on
	pd.UserId = a.UserId
	group by  MONTH(Date), pd.Salary,pd.UserId

alter view VWAbsentCount As
select count(AttendanceId) as Absent,UserId,datename(mm,date) as Month from Attendance
group by Attendance,datename(mm,date),UserId
having Attendance = 3 

--select V.Employee,pd.Salary,V.perDaySalary from VwSalaryCount As V
--join PersonalDetails As pd on pd.UserId =  V.Employee



select * from VwSalaryCount 
select * from VWAbsentCount 
select * from Attendance 


select distinct( V.perDaySalary*A.Absent ) as Total_Salary, (V.Employee), A.Month from VwSalaryCount as V
join  VWAbsentCount as A on
V.Employee = A.UserId



