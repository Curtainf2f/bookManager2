use bookManager
go
create trigger onBorrowDelete
on borrow after delete
as
declare tmpCur cursor scroll for select * from deleted
declare @readerId int, @barCode int, @borrowTime smalldatetime
declare @ISBN varchar(30)
declare @remarks varchar(50)
declare @payment varchar(10)
begin
	begin try
		begin tran
			open tmpCur
				fetch next from tmpCur into @readerId, @barCode, @borrowTime
				while @@fetch_status = 0
				begin
					declare @fine money
					set @payment = '�ѽɷ�'
					set @remarks = null
					set @fine = (select datediff(day, @borrowTime, getdate()))
					set @fine = @fine - dbo.getReaderCanBorrowTimes(@readerId)
					if(@fine < 0) set @fine = null
					if(@fine is not null)
						begin
							set @remarks = '��ʱ';
							set @payment = 'δ�ɷ�'
						end
					insert into borrowLog values(@readerId, @barCode, @borrowTime, getdate(), @fine, @remarks, @payment)
					update books set borrowStatus = '�ɽ���' where barCode = @barCode
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
			if((select borrowStatus from books where barCode = @barCode) != '�ɽ���')
				raiserror('���鱾�ѱ�����', 16, 1)
			if((select count(*) from borrow where readerId = @readerId) > dbo.getReaderCanBorrowItem(@readerId))
				raiserror('�������鱾�������Ѵ�����', 16, 1)
			if((select count(*) from borrowLog where readerId = @readerId and paymented = 'δ�ɷ�') > 0)
				raiserror ('������Ƿ��δ�ɷ�', 16, 1)
			if((select count(*) from borrowInfo where readerId = @readerId and �Ƿ�ʱ = '�ѳ�ʱ') > 0)
				raiserror ('���г�ʱ���鱾δ�黹�����ȹ黹', 16, 1)
			update books set borrowStatus = '���-Ӧ�����ڣ�'+ CONVERT(varchar(100), GETDATE() + dbo.getReaderCanBorrowTimes(@readerId), 11) where barCode = @barCode
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