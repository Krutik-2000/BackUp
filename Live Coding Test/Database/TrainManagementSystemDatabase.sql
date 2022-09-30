CREATE DATABASE TrainManagementSystem

Create Table Users
(
UserId int Primary Key identity(1,1),
UserName varchar(20) Not NULL,
EmailId varchar(30) Not NULL,
Password varchar(50) Not NULL
)

Create Table Stations
(
StationId int Primary Key identity(1,1),
StationName varchar(50) Not NULL,
)
Create Table Train
(
TrainId int Primary Key identity(1,1),
TrainName varchar(50) Not NULL,
Seats int Not NULL
)

Create Table Station_Train
(
Station_TrainId int Primary Key identity(1,1),
TrainId int Foreign Key References Train(TrainID),
StationId int Foreign Key References Stations(StationId)
)

Create Table Booking
(
BookingId int Primary Key identity(1,1),
Ticket int Not Null,
FromStation int Foreign Key References Stations(StationId),
ToStation int Foreign Key References Stations(StationId),
TrainId int Foreign Key References Train(TrainID),
UserId int Foreign Key References Users(UserId)
)

Insert Into Users
Values(
'Krutik','Krutik@gmail.com','Krutik@462000'
)

Insert Into Train
Values
('Rajdhani Expres',900),
('Local',1000),
('Shatabdi Express',850),
('Jan Shatabdi Express',700),
('Kavi Guru Express',800)

Insert Into Stations
Values
('Surat'),
('Ahemdabad'),
('Mumbai'),
('Delhi'),
('Banglore'),
('Kolkata'),
('Asam')


