use bookManager
go
create trigger onBooksInsert
on books after insert
as
declare @ISBN varchar(20)
begin
	begin try
		begin tran
			select @ISBN = ISBN from inserted
			update bookItem set inventory = inventory + 1 where ISBN = @ISBN
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
create trigger onBooksDelete
on books after delete
as
declare @ISBN varchar(20)
begin
	begin try
		begin tran
			select @ISBN = ISBN from deleted
			update bookItem set inventory = inventory - 1 where ISBN = @ISBN
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