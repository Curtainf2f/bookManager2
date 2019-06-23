use bookManager
go
create view borrowInfo
as
select borrow.readerId, borrow.barCode ������, books.ISBN, bookItem.name ����, bookItem.author ����, bookItem.publisher ������, borrow.borrowTime ����ʱ��, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId) ����黹ʱ��, dbo.dateOverTime(borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId), getdate()) �Ƿ�ʱ from borrow left join books on borrow.barCode = books.barCode left join bookItem on books.ISBN = bookItem.ISBN
