use bookManager
go
create function getReaderCanBorrowTimes(@readerId int)
returns int
as
begin
declare @readerTypeId int
set @readerTypeId = (select readerTypeId from readers where readerId = @readerId)
declare @bookTimeCanBorrow int
set @bookTimeCanBorrow = (select bookTimeCanBorrow from readerTypes where readerTypeId = @readerTypeId)
return @bookTimeCanBorrow
end
go
create function getReaderCanBorrowItem(@readerId int)
returns int
as
begin
declare @readerTypeId int
set @readerTypeId = (select readerTypeId from readers where readerId = @readerId)
declare @bookCanBorrow int
set @bookCanBorrow = (select bookCanBorrow from readerTypes where readerTypeId = @readerTypeId)
return @bookCanBorrow
end