use bookManager
go
create proc addBookType
	@typeName varchar(30)
as
declare @bookTypeId int
begin
	begin try
		begin tran
			set @bookTypeId = dbo.getFreeBookTypeId()
			insert into bookTypes values (@bookTypeId, @typeName)
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
create proc addBook
	@ISBN varchar(30)
as
declare @barCode int
begin
	begin try
		begin tran
			set @barCode = dbo.getFreeBarCode()
			insert into books values (@barCode, @ISBN, '¿É½èÔÄ')
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
create proc addReaderType
	@typeName varchar(30),
	@bookCanBorrow int,
	@bookTimeCanBorrow int
as
declare @readerTypeId int
begin
	begin try
		begin tran
			set @readerTypeId = dbo.getFreeReaderTypeId()
			insert into readerTypes values (@readerTypeId, @typeName, @bookCanBorrow, @bookTimeCanBorrow)
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
