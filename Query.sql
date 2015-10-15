use Taygeta
delete from Vacancies
delete from Wrappers
delete from Logs

select * from Pages
select * from Keywords
select * from Resources
select [Message] from Logs where [Date] between '20151014 12:24' and '20151011 10:25'
select * from Logs where [Date] > '20151014 12:00' and exception != ''
select * from Logs where Level = 'ERROR' order by [date] desc

declare @LTR nchar(1) = nchar(0x200E);
declare @RTL nchar(1) = nchar(0x200F);

delete from Resources where [name] = 'helloString' and culturename = 'he-IL'
insert Resources (Name, CultureName, Value) values ('helloString', 'he-IL', N'{0}' + N' שלום')
select value from resources where [name] = 'helloString' and culturename = 'he-IL'

