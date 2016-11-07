create database SystemDB;
use SystemDB;
set global optimizer_switch='derived_merge=off'
set optimizer_switch='derived_merge=off'

select @@optimizer_switch;
select @@GLOBAL.optimizer_switch;


create table ACCOUNT
(
Id int not null auto_increment,
UserName nvarchar(20),
Password nvarchar(20),
AccountType nvarchar(10),
primary key(Id)

);

insert into ACCOUNT values
(1,'Hoang', '123456', 'Admin'),
(2,'Dai', '123456', 'Client'),
(3,'HTHHOANG', '123456', 'Merchant')

create table BUSSINESSTYPE
(
Id int not null auto_increment,
Name nvarchar(10),
Description nvarchar(300),
primary key(Id)
)

insert into BUSSINESSTYPE values
(1,N'Tạp hóa', N'Buốn bán các mặt hàng phục vụ nhu cầu người dùng'),
(2,N'Quán ăn', N'Các món ăn'),
(3,N'Đồng hồ', N'Các loại đồng hồ')

create table STORE
(
Id int not null auto_increment,
Name nvarchar(50),
MapAddress nvarchar(50),
PhysicAddress nvarchar(50),
Email nvarchar(30),
Avatar nvarchar(100),
Description nvarchar(300),
BussinessType int,
PhoneNumber nvarchar(12),
primary key(Id),
foreign key(BussinessType) references BUSSINESSTYPE(Id)

);

insert into STORE values
(1,N'Nhậu 123!', '10.751822,106.706406', N'Trần Xuân Soạn quận 7 Hồ Chí Minh', 'Nhau123@Gmail.com', null,
'Quán nhậu q7', 1, '09890984'),
(2,N'Đồng hồ 123!', '10.751822,106.706406', N'Trần Xuân Soạn quận 7 Hồ Chí Minh', 'Nhau123@Gmail.com', null,
'Quán đồng hồ', 2, '09890984')



create table STOREACCOUNT
(
Id int not null auto_increment,
IdACCOUNT int ,
IdSTORE int,
Name nvarchar(20),
Email nvarchar(20),
Address nvarchar(30),
Age int, 
Sex bit,
primary key(Id),
foreign key(IdACCOUNT) references ACCOUNT(Id), 
foreign key(IdSTORE) references STORE(Id)
);

insert into STOREACCOUNT values
(1,3, 1, N'Hà Thế Hoàng', 'HTH@Gmail.com', N'Quận 7 Hồ Chí Minh',
22, true)

create table ADMINACCOUNT
(
Id int not null auto_increment,
IdACCOUNT int ,
Email nvarchar(20),
Address nvarchar(20),
NumberPhone nvarchar(12),
primary key(Id),
foreign key(IdACCOUNT) references ACCOUNT(Id)
)

insert into ADMINACCOUNT values 
(1,1, 'HTH@Gmail.com', N'Quận 7 Hồ Chí Minh', '0312654428')

create table CLIENTACCOUNT
(
Id int not null auto_increment,
IdACCOUNT int,
Name nvarchar(20),
Address nvarchar(30),
Email nvarchar(30),
Avartar nvarchar(100),
Description nvarchar(300),
Age int,
Sex bit,
PhoneNumber nvarchar(12),
DateBirth date,
primary key(Id),
foreign key(IdACCOUNT) references ACCOUNT(Id)
)

insert into CLIENTACCOUNT values 
(1,2, N'Diệp Công Đại', N'Quận 7 Hồ Chí Minh', 'DAI@Gmail.com', null, 
N'Đây là acclient', 21, true, '05390505', '1995/2/2')

create table PROMOTION
(
Id int not null auto_increment,
IdSTORE int,
Name nvarchar(50),
Status bit,
DateBegin Datetime,
DateEnd Datetime,
Description nvarchar(300),
IdListReward int,
primary key(Id),
foreign key(IdSTORE) references STORE(Id)
);

insert into PROMOTION values
(1,1, N'Đợt khuyến mãi 1', false, '2016/2/2', '2016/3/2', N'đợt khuyến mãi đầu năm', 1),
(2,1, N'Đợt khuyến mãi 2', true, '2016/9/2', '2016/10/2', N'đợt khuyến mãi cuối năm', 2)

create table REWARD
(
Id int not null auto_increment,
Name nvarchar(30),
ChanceToGet int,
ChanceToRoll int,
Status bit,
TimeRemain int,
primary key(Id)
)

insert into REWARD values
(1,N'nhậu món 1 được giảm giá 50%', 10, 10, true, 3600),
(2,N'nhậu món 2 được giảm giá 10%', 20, 20, true, 3500)

create table LISTREWARD
(
Id int not null auto_increment,
IdList int, 
Quantity int,
IdReward int,
primary key(Id)
)

insert into LISTREWARD values
(1,1, 10, 1),
(2,1, 15, 2),
(3,2, 5, 1),
(4,2, 10, 2)

create table QRCODE
(
Id int not null auto_increment,
IdPromotion int,
Url nvarchar(100),
primary key(Id),
foreign key(IdPromotion) references PROMOTION(Id)
)

insert into QRCODE values
(1,1, 'abc/xyz/1')

create table TICKET
(
Id int not null auto_increment,
IdPromotion int,
IdReWard int,
IdClientUser int,
IsWin bit,
Date datetime,
Status bit,
primary key(Id),
foreign key(IdPromotion) references PROMOTION(Id),
foreign key(idReward) references REWARD(Id),
foreign key(IdClientUser) references CLIENTACCOUNT(Id)
)

insert into TICKET values
(1,1,1,1,true, '2016/10/2', false)

