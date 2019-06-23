use bookManager
go
create trigger onBorrowDelete
on borrow after delete
as
declare tmpCur cursor scroll for select * from deleted
declare @readerId int, @barCode int, @borrowTime smalldatetime
declare @ISBN varchar(30)
begin
	begin try
		begin tran
			open tmpCur
				fetch next from tmpCur into @readerId, @barCode, @borrowTime
				while @@fetch_status = 0
				begin
					declare @fine money
					set @fine = (select datediff(day, @borrowTime, getdate()))
					set @fine = @fine - dbo.getReaderCanBorrowTimes(@readerId)
					if(@fine < 0) set @fine = null
					insert into borrowLog values(@readerId, @barCode, @borrowTime, getdate(), @fine, null)
					update books set borrowStatus = '可借阅' where barCode = @barCode
					select @ISBN = ISBN from books where barCode = @barCode
					update bookItem set isBorrowed = isBorrowed - 1 where ISBN = @ISBN
					fetch next from tmpCur into @readerId, @barCode, @borrowTime
				end
			close tmpCur
			deallocate tmpCur
		commit tran
	end try
	begin catch
		rollback tran
		declare @errorMessage varchar(200)
		declare @errorSeverity int
		declare @errorState int
		select
			@errorMessage = error_message(),
			@errorSeverity = error_severity(),
			@errorState = error_state()
		raiserror (@errorMessage, @errorSeverity, @errorState)
	end catch
end

go
create trigger onBorrowInsert
on borrow
after insert
as
declare @readerId int
declare @barCode varchar(30)
declare @ISBN varchar(30)
begin
	begin try
		begin tran
			select @readerId = readerId, @barCode = barCode from inserted
			if((select borrowStatus from books where barCode = @barCode) != '可借阅')
				raiserror('该书本已被借阅', 16, 1)
			if((select count(*) from borrow where readerId = @readerId) >= dbo.getReaderCanBorrowItem(@readerId))
				raiserror('您借阅书本的数量已达上限', 16, 1);
			if((select count(*) from borrowLog where readerId = @readerId and fine is not null) > 0)
				raiserror('您还有欠款未缴费', 16, 1);
			update books set borrowStatus = '借出-应还日期：'+ CONVERT(varchar(100), GETDATE() + dbo.getReaderCanBorrowTimes(@readerId), 11) where barCode = @barCode
			select @ISBN = ISBN from books where barCode = @barCode
			update bookItem set borrowTimes = borrowTimes + 1 where ISBN = @ISBN
			update bookItem set isBorrowed = isBorrowed + 1 where ISBN = @ISBN
		commit tran
	end try
	begin catch
		rollback tran
		declare @errorMessage varchar(200)
		declare @errorSeverity int
		declare @errorState int
		select
			@errorMessage = error_message(),
			@errorSeverity = error_severity(),
			@errorState = error_state()
		raiserror (@errorMessage, @errorSeverity, @errorState)
	end catch
end

