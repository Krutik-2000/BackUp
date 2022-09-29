Create table Category(
CategoryId int identity(1,1) Primary key,
CategoryName varchar(100) Not Null,
)

CREATE TABLE Products
(
ProductId int identity(1,1) Primary key,
ProductName varchar(100) Not NULL,
Price money Not Null,
ProductSKU int Not Null,
Icon  varchar(Max) Not null,
Image varchar(Max) Not Null,
Width int Not Null,
Height int Not Null,
Weight decimal(5,3) Not Null,
CategoryId int foreign key references  Category(CategoryId)
)

Create table AllData
(
dataId int identity(1,1) primary key,
referenceNumber varchar(100) Null,
ProductName varchar(100)  NULL,
Price money  Null,
ProductSKU int  Null,
Width int  Null,
Height int  Null,
Weight decimal(5,3)  Null,
Icon  varchar(Max)  null,
Image varchar(Max)  Null,
CategoryId int foreign key references  Category(CategoryId),
)


Alter procedure Mergedata @dataId int
as
---------------------------------
insert into Products(ProductName,Price,ProductSKU,Width,Height,Weight,Icon,Image,CategoryId)
select ProductName,Price,ProductSKU,Width,Height,Weight,Icon,Image,CategoryId
from AllData
where dataId = @dataId
---------------------------------
exec Mergedata 1



select * from AllData
select * from Products
select * from Category









