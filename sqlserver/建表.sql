create database bookManager
on primary(
	name = 'bookManager',
	filename = 'D:\bookManager.mdf',
	size = 5MB,
	maxsize = unlimited,
	filegrowth = 20%
)
log on(
	name = 'bookManager_log',
	filename = 'D:\bookManager.ldf',
	size = 5MB,
	maxsize = 100MB,
	filegrowth = 20%
)

go
use bookManager

create table bookTypes(
	bookTypeId int primary key,
	typeName varchar(30) not null
)

create table freeBookTypeId(
	id int
)

create table bookItem(
	ISBN varchar(30) primary key,
	bookTypeId int constraint FK_books_�����ڸ����͵��� foreign key references bookTypes(bookTypeId),
	name varchar(30) not null,
	author varchar(30),
	publisher varchar(30),
	publishtime smalldatetime,
	price money not null,
	borrowTimes int not null default 0,
	inventory int not null default 0,
	isBorrowed int not null default 0
)

create table books(
	barCode int primary key,
	ISBN varchar(30) not null foreign key references bookItem(ISBN),
	borrowStatus varchar(40) not null
)

create table readerTypes(
	readerTypeId int primary key,
	typeName varchar(30) not null,
	bookCanBorrow int not null,
	bookTimeCanBorrow int not null,
)

create table freeReaderTypeId(
	id int
)

create table readers(
	readerId int primary key,
	readerTypeId int constraint FK_readers_�����ڸ����͵Ķ��� foreign key references readerTypes(readerTypeId),
	idCard varchar(20) not null unique,
	name varchar(20) not null,
	sex varchar(3) constraint CK_readers_�Ա�ֻ�����л�Ů check (sex in ('��', 'Ů')),
	age int,
	phone varchar(15) constraint Ck_readers_�绰ֻ�ܰ������� check (phone not like '%[^0-9|-]%') not null,
	dept varchar(20) not null,
	regDate smalldatetime not null
)


create table users(
	username varchar(20) primary key,
	pwd varchar(20) not null constraint CK_users_������볬��6λ check(len(pwd) >= 6),
	readerId int constraint FK_users_�ö��߻����û���Ϣ foreign key references readers(readerId),
	userCard varchar(32),
)

create table admins(
	username varchar(20) primary key,
	pwd varchar(20) not null constraint CK_admins_������볬��6λ check(len(pwd) >= 6),
)

create table borrow(
	readerId int constraint FK_borrow_�ö��ߴ��ڽ�����Ϣ foreign key references readers(readerId),
	barCode int constraint FK_borrow_���鱾���ڽ�����Ϣ foreign key references books(barCode),
	borrowTime smalldatetime not null,
)

create table borrowLog(
	readerId int constraint FK_borrowLog_�ö��ߴ��ڽ�����Ϣ foreign key references readers(readerId),
	barCode int constraint FK_borrowLog_���鱾���ڽ�����Ϣ foreign key references books(barCode),
	borrowTime smalldatetime not null,
	returnTime smalldatetime,
	fine money,
	remarks varchar(50),
	paymented varchar(10)
)

create table recommend(
	readerId int constraint FK_recommend_�ö��߻����鱾�Ƽ���Ϣ foreign key references readers(readerId) not null,
	ISBN varchar(30) not null,
	bookName varchar(30) not null,
	author varchar(40) not null,
	publish varchar(40),
	recommendDate smalldatetime not null,
	recommendStatus varchar(10) not null,
	remarks varchar(50)
)
