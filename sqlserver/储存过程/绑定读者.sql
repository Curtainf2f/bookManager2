use bookManager
go
create proc boundReader
	@username varchar(20),
	@readerTypeId int,
	@idCard varchar(20),
	@name varchar(20),
	@sex varchar(3),
	@age int,
	@phone varchar(15),
	@dept varchar(20)
as
declare @readerId int
begin
	begin try
		begin tran
			declare @key varchar(52)
			if((select count(*) from users where username = @username) = 0)
				raiserror ('该用户不存在', 16, 1)
			set @readerId = -1
			select @readerId = readerId from users where username = @username
			if(@readerId != -1)
				raiserror ('该用户已绑定读者信息', 16, 1)
			set @key = @username + @idCard
			set @readerId = dbo.getFreeReaderId()
			insert into readers values(@readerId, @readerTypeId, @idCard, @name, @sex, @age, @phone, @dept, getdate())
			update users set userCard = substring(sys.fn_sqlvarbasetostr(HashBytes('MD5',@key)),3,32) where username = @username
			update users set readerId = @readerId where username = @username
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
create proc changeUser
	@idCard varchar(20),
	@username varchar(20),
	@password varchar(20)
as
declare @readerId int
begin
	begin try
		begin tran
			declare @key varchar(52)
			if((select count(*) from readers where idCard = @idCard) = 0)
				raiserror ('该读者不存在', 16, 1)
			set @key = @username + @idCard
			select @readerId = readerId from readers where idCard = @idCard
			delete from users where readerId = @readerId
			insert into users values (@username, @password, @readerId, substring(sys.fn_sqlvarbasetostr(HashBytes('MD5',@key)),3,32))
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
