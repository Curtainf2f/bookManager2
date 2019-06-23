use bookManager
go
create trigger onRecommendInsert
on recommend after insert
as
declare @ISBN varchar(30)
begin
	begin try
		begin tran
			select @ISBN = ISBN from inserted;
			if((select count(*) from bookItem where ISBN = @ISBN) > 0)
				raiserror ('图书馆已有该书', 16, 1);
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