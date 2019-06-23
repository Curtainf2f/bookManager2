use bookManager
go
create view borrowInfo
as
select borrow.readerId, borrow.barCode 条形码, books.ISBN, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, borrow.borrowTime 借阅时间, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId) 最晚归还时间, dbo.dateOverTime(borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId), getdate()) 是否超时 from borrow left join books on borrow.barCode = books.barCode left join bookItem on books.ISBN = bookItem.ISBN
