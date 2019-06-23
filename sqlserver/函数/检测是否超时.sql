use bookManager
go
create function dateOverTime(@a smalldatetime, @b smalldatetime)
returns varchar(10)
as
begin
	if(@a < @b)
		return 'ÒÑ³¬Ê±'
	return 'Î´³¬Ê±'
end