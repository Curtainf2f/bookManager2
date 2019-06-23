use bookManager

insert into admins values('admin', '123456')
insert into users values('a','123456', null, null)
exec addReaderType '学生', 5, 14
exec addReaderType '教师', 20, 30
exec boundReader 'a', 1, '350526199811111111', '小刚', '男', 18, '18795354129', '信息学院'
exec addBookType '文学类'
exec addBookType '哲学'
insert into bookItem values ('9787110357460', 1, '俗世奇人', '冯骥才', '作家出版社', '2016-5-1', 23, 0, 0, 0)
insert into bookItem values ('9787121352645', 2, '社会计算中的组织行为模式挖掘', '苏鹏', '北京电子工业出版社', '2019-1-1', 49, 0, 0, 0)
exec addBook '9787110357460'
exec addBook '9787121352645'
exec addBook '9787121352645'
insert into borrow values(1, 1, getdate())
insert into users values('b', '123456', null, null)
exec boundReader 'b', 1, '350526199811111221', '小红', '女', 18, '18795354249', '信息学院'
exec changeUser '350526199811111111', 'c', '222222'
update readerTypes set bookCanBorrow = 2 where readerTypeId = 1
insert into borrow values(1, 2, getdate())
--超时--
update borrow set borrowTime = '2019-5-1' where barCode = 2
--即将超时--
update borrow set borrowTime = '2019-6-10' where barCode = 2

select * from users
select * from readers
select * from readerTypes
select * from books
select * from bookTypes
select * from bookItem
select * from borrow
select * from borrowLog

delete from users
delete from readers
delete from readerTypes
delete from books
delete from bookTypes
delete from borrow
delete from borrowLog

select row_number() over (order by borrowTimes desc) 排名, bookItem.ISBN, bookTypes.typeName 书本类型, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, borrowTimes 借阅册次, inventory 库存, isBorrowed 已被借阅
from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId order by 借阅册次 desc

select ISBN, bookTypes.typeName, name, author, publisher, publishTime from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId

select barCode 条形码, borrowStatus 借阅状态 from books 

select readers.readerId, readers.name from users left join readers on users.readerId = readers.readerId where username = 'c'

select borrowLog.barCode 条形码, books.ISBN, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, 
borrowLog.borrowTime 借出时间, borrowLog.returnTime 归还时间, borrowLog.fine 罚金,
borrowLog.remarks 管理员备注 from borrowLog left join books on books.barCode = borrowLog.barCode left join bookItem on bookItem.ISBN = books.ISBN
where borrowLog.readerId = 1

select barCode 条形码, borrowTime 借出时间, returnTime 归还时间, fine 罚金, remarks 管理员备注 from borrowLog where fine is not null

select ISBN, bookName 书名, author 作者, publish 出版社, recommendDate 推荐日期, recommendStatus 推荐状态, remarks 管理员备注 from recommend order by recommendDate desc

select borrow.readerId, borrow.barCode 条形码, books.ISBN, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, borrow.borrowTime 借阅时间, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId) 最晚归还时间
from borrow left join books on borrow.barCode = books.barCode left join bookItem on books.ISBN = bookItem.ISBN
where datediff(day, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId), getdate()) <= 3

select users.username 用户名, users.pwd 密码, readers.name 读者姓名, readers.idCard 身份证号, readers.sex 性别, readers.age 年龄, readers.phone 电话, readers.dept 系别, readers.regDate 注册时间 from users left join readers on users.readerId = readers.readerId
where username = 'd'

select users.username 用户名, readers.name 读者姓名, ISBN, bookName 书名, author 作者, publish 出版社, recommendDate 荐阅日期, recommendStatus 当前状态, remarks 管理员备注
from recommend left join readers on readers.readerId = recommend.readerId left join users on users.readerId = readers.readerId

select users.username 用户名, readers.name 读者姓名, borrowLog.barCode 条形码, borrowLog.borrowTime 借阅时间, borrowLog.returnTime 归还时间, fine 罚金, remarks 管理员备注, paymented 是否缴费
from borrowLog left join readers on readers.readerId = borrowLog.readerId left join users on readers.readerId = users.readerId