use bookManager
go
create function getFreeBookTypeId()
returns int
as
begin
	declare @id int
	set @id = 1
	if((select count(*) from freeBookTypeId) > 0)
		set @id = (select top 1 id from freeBookTypeId)
	else if((select count(*) from bookTypes) > 0)
		set @id = (select top 1 bookTypeId from bookTypes order by bookTypeId desc) + 1
	return @id
end

go
create function getFreeBarCode()
returns int
as
begin
	declare @id int
	set @id = 1
	if((select count(*) from books) > 0)
		set @id = (select top 1 barCode from books order by barCode desc) + 1
	return @id
end

go
create function getFreeReaderTypeId()
returns int
as
begin
	declare @id int
	set @id = 1
	if((select count(*) from freeReaderTypeId) > 0)
		set @id = (select top 1 id from freeReaderTypeId)
	else if((select count(*) from readerTypes) > 0)
		set @id = (select top 1 readerTypeId from readerTypes order by readerTypeId desc) + 1
	return @id
end


go
create function getFreeReaderId()
returns int
as
begin
	declare @id int
	set @id = 1
	if((select count(*) from readers) > 0)
		set @id = (select top 1 readerId from readers order by readerId desc) + 1
	return @id
end

