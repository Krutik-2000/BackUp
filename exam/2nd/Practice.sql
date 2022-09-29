CREATE TABLE Students 
(
StudentId int identity(1,1) Primary key,
RollNo int  ,
FirstName varchar(20) NOT NULL,
LastName varchar(20) NOT NULL,
Gender varchar(10) CONSTRAINT myCheckConstraint CHECK(gender in('Male','Female')),
StandardId int Foreign key references Standards(StandardId) NOT NULL,
TeacherId int Foreign key references  ClassTeachers(TeacherId) NOT NULL
)

CREATE TABLE Standards(
StandardId int identity(1,1) Primary key,
Standard varchar(10) NOT NULL
)
CREATE TABLE ClassTeachers
(
TeacherId int identity(1,1) Primary key,
TeacherName varchar(30) NOT NULL
StandardId int unique Foreign key references Standards(StandardId) NOT NULL
)

select * from ClassTeachers
select * from Students
select * from Standards