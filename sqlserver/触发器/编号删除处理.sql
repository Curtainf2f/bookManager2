use bookManager

go
create trigger onReaderTypesDelete
on readerTypes after delete
as
declare tmpCur cursor scroll for select readerTypeId from deleted
declare @readerTypeId int
begin
	begin try
		begin tran
			open tmpCur
				fetch next from tmpCur into @readerTypeId
				while @@fetch_status = 0
				begin
					insert into freeReaderTypeId values(@readerTypeId)
					fetch next from tmpCur into @readerTypeId
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
create trigger onBookTypesDelete
on bookTypes after delete
as
declare tmpCur cursor scroll for select bookTypeId from deleted
declare @bookTypeId int
begin
	begin try
		begin tran
			open tmpCur
				fetch next from tmpCur into @bookTypeId
				while @@fetch_status = 0
				begin
					insert into freeBookTypeId values(@bookTypeId)
					fetch next from tmpCur into @bookTypeId
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