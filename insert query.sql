--/Inserting Data into DB/--
--/Inserting Data into 1. CUSTOMER TABLE/ --
INSERT INTO Customer VALUES(
'Krutik',
'Krutik',
'Vasava',
'vasavakrutik72@gmail.com',
'admin',
'7574905018',
4454
)
--/Inserting Data into 2. MasterTable TABLE/ --
INSERT INTO MasterTable VALUES 
('Size'),
('Color'),
('OrderStatus'),
('PaymentType'),
('PaymentStatus'),
('AddressType')
--/Inserting Data into 3. Attribute TABLE/ --
INSERT INTO Attribute VALUES 
(1, 'XS'),
(1, 'S'),
(1, 'M'),
(1, 'L'),
(1, 'XL'),
(1, '2XL'),
(1, '3XL'),
(1, '4XL'),
(1, '30'),
(1, '32'),
(1, '34'),
(1, '36'),
(1, '38'),
(1, '40'),
(1, '42'),
(1, '44'),
(1, '46'),
(1, '48'),
(1, '50'),
(1, '4'),
(1, '5'),
(1, '6'),
(1, '7'),
(1, '8'),
(1, '9'),
(1, '10'),
(1, '28EU'),
(1, '29EU'),
(1, '30EU'),
(1, '31EU'),
(1, '32EU'),
(1, '33EU'),
(1, '34EU'),
(1, '35EU'),
(1, '36EU'),
(1, '37EU'),
(1, '38EU'),
(1, '24EU'),
(1, '25EU'),
(1, '26EU'),
(1, '27EU'),
(1, '20EU'),
(1, '21EU'),
(1, '22EU'),
(1, '23EU'),
(2, 'Black'),
(2, 'Blue'),
(2, 'Red'),
(2, 'White'),
(2, 'Green'),
(2, 'Pink'),
(2, 'Navy'),
(2, 'Orange'),
(2, 'Peach'),
(2, 'Gray'),
(2, 'Brown'),
(2, 'Yellow'),
(2, 'Olive'),
(3, 'InProgress'),
(3, 'Dispatched'),
(3, 'Delivered'),
(3, 'Cancel'),
(5, 'Success'),
(5, 'Pending'),
(5, 'Failed'),
(4, 'UPI'),
(4, 'Credit'),
(4, 'Debit'),
(4, 'COD'),
(6, 'Home'),
(6, 'Office')


--/Inserting Data into 4. CustomerAddresses TABLE/ --
INSERT INTO CustomerAddresses VALUES 
(
1,
'A-16 Rameshwar App near over bridge opp Caracan Ganeshchowkadi Anand',  
388001,
'Anand',
'Anand',
'Gujarat'

)

INSERT INTO Product VALUES (
'Venerate Headphone Stand Headset Holder Earphone Stand with Aluminum Supporting Bar (Black)', 269,'asdfas','InStock',50,'Venerate Headphone Stand Headset Holder Earphone Stand with Aluminum Supporting Bar, the colour of the stand is black . Headphone stand is made of Aluminium, ABS & Flexible TPU|Flexible headrest made with elastic TPU rubber, can support a variety of sizes of headphones|Headphones are shown just for illustration and is not included with the package|Dimension : 10 x 10x 22 cm','Maximum Retail Price (inclusive of all taxes) 	:   Rs.1999
Common or Generic Name 	:   Holder and Stand Net Contents / Net Quantity 	:   1 Manufacturers Name and Address 	:   BVPL & No 645, 12th cross, 5th main, MC Layout,Govindarajanagar,Bengaluru,560040
Packers Name and Address 	:   BVPL & No 645, 12th cross, 5th main, MC Layout,Govindarajanagar,Bengaluru,560040
Marketers name and Address 	:   BVPL & No 645, 12th cross, 5th main, MC Layout,Govindarajanagar,Bengaluru,560040
Importers Name and Address 	:   BVPL & No 645, 12th cross, 5th main, MC Layout,Govindarajanagar,Bengaluru,560040
Country of Origin / Manufacture / Assembly 	:   China',null,null
)
INSERT INTO ProductImages VALUES(
'https://cdn.shopclues.com/images1/thumbnails/115246/50/50/152689876-115246213-1659944531.jpg'
,1
)