use bookManager

insert into admins values('admin', '123456')
insert into users values('a','123456', null, null)
exec addReaderType 'ѧ��', 5, 14
exec addReaderType '��ʦ', 20, 30
exec boundReader 'a', 1, '350526199811111111', 'С��', '��', 18, '18795354129', '��ϢѧԺ'
exec addBookType '��ѧ��'
exec addBookType '��ѧ'
insert into bookItem values ('9787110357460', 1, '��������', '������', '���ҳ�����', '2016-5-1', 23, 0, 0, 0)
insert into bookItem values ('9787121352645', 2, '�������е���֯��Ϊģʽ�ھ�', '����', '�������ӹ�ҵ������', '2019-1-1', 49, 0, 0, 0)
exec addBook '9787110357460'
exec addBook '9787121352645'
exec addBook '9787121352645'
insert into borrow values(1, 1, getdate())
insert into users values('b', '123456', null, null)
exec boundReader 'b', 1, '350526199811111221', 'С��', 'Ů', 18, '18795354249', '��ϢѧԺ'
exec changeUser '350526199811111111', 'c', '222222'
update readerTypes set bookCanBorrow = 2 where readerTypeId = 1
insert into borrow values(1, 2, getdate())
--��ʱ--
update borrow set borrowTime = '2019-5-1' where barCode = 2
--������ʱ--
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

select row_number() over (order by borrowTimes desc) ����, bookItem.ISBN, bookTypes.typeName �鱾����, bookItem.name ����, bookItem.author ����, bookItem.publisher ������, borrowTimes ���Ĳ��, inventory ���, isBorrowed �ѱ�����
from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId order by ���Ĳ�� desc

select ISBN, bookTypes.typeName, name, author, publisher, publishTime from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId

select barCode ������, borrowStatus ����״̬ from books 

select readers.readerId, readers.name from users left join readers on users.readerId = readers.readerId where username = 'c'

select borrowLog.barCode ������, books.ISBN, bookItem.name ����, bookItem.author ����, bookItem.publisher ������, 
borrowLog.borrowTime ���ʱ��, borrowLog.returnTime �黹ʱ��, borrowLog.fine ����,
borrowLog.remarks ����Ա��ע from borrowLog left join books on books.barCode = borrowLog.barCode left join bookItem on bookItem.ISBN = books.ISBN
where borrowLog.readerId = 1

select barCode ������, borrowTime ���ʱ��, returnTime �黹ʱ��, fine ����, remarks ����Ա��ע from borrowLog where fine is not null

select ISBN, bookName ����, author ����, publish ������, recommendDate �Ƽ�����, recommendStatus �Ƽ�״̬, remarks ����Ա��ע from recommend order by recommendDate desc

select borrow.readerId, borrow.barCode ������, books.ISBN, bookItem.name ����, bookItem.author ����, bookItem.publisher ������, borrow.borrowTime ����ʱ��, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId) ����黹ʱ��
from borrow left join books on borrow.barCode = books.barCode left join bookItem on books.ISBN = bookItem.ISBN
where datediff(day, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId), getdate()) <= 3

select users.username �û���, users.pwd ����, readers.name ��������, readers.idCard ���֤��, readers.sex �Ա�, readers.age ����, readers.phone �绰, readers.dept ϵ��, readers.regDate ע��ʱ�� from users left join readers on users.readerId = readers.readerId
where username = 'd'

select users.username �û���, readers.name ��������, ISBN, bookName ����, author ����, publish ������, recommendDate ��������, recommendStatus ��ǰ״̬, remarks ����Ա��ע
from recommend left join readers on readers.readerId = recommend.readerId left join users on users.readerId = readers.readerId

select users.username �û���, readers.name ��������, borrowLog.barCode ������, borrowLog.borrowTime ����ʱ��, borrowLog.returnTime �黹ʱ��, fine ����, remarks ����Ա��ע, paymented �Ƿ�ɷ�
from borrowLog left join readers on readers.readerId = borrowLog.readerId left join users on readers.readerId = users.readerId