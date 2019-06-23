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

insert into borrow values(1, 2, '2019-5-1')

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

