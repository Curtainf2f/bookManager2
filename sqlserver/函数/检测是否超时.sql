use bookManager
go
create function dateOverTime(@a smalldatetime, @b smalldatetime)
returns varchar(10)
as
begin
	if(@a < @b)
		return '�ѳ�ʱ'
	return 'δ��ʱ'
end