----------1---------
declare @n int = 10;         
declare @result bigint = 1;
while @n > 1
begin
    set @result = @result * @n;
    set @n = @n - 1;
end
print 'factorial is: ' + cast(@result as varchar)


----------2---------
create procedure generatetable
    @num int,          -- the base number
    @upto int          -- how far to multiply
as
begin
    declare @i int = 1;

    while @i <= @upto
    begin
        print cast(@num as varchar) + ' x ' + cast(@i as varchar) + ' = ' + cast(@num * @i as varchar);
        set @i = @i + 1;
    end
end
exec generatetable @num = 7, @upto =10



------------3---------------
create table student (
    sid int primary key,
    sname varchar(30))
insert into student values(1, 'jack')
insert into student values(2, 'rithvik')
insert into student values(3, 'jaspreeth')
insert into student values(4, 'praveen')
insert into student values(5, 'bisa')
insert into student values(6, 'suraj')
select *from student


create table marks (
    mid int primary key,
    sid int,
    score int,
    foreign key (sid) references student(sid))

insert into marks values(1, 1, 23)
insert into marks values(2, 6, 95)
insert into marks values(3, 4, 98)
insert into marks values(4, 2, 17)
insert into marks values(5, 3, 53)
insert into marks values(6, 5, 13)
select *from marks

create function getstatus (@score int)
returns varchar(10)
as
begin
    declare @result varchar(10);

    if @score >= 50
        set @result = 'pass';
    else
        set @result = 'fail';

    return @result;
end;

select 
    s.sid,
    s.sname,
    m.score,
    dbo.getstatus(m.score) as status
from 
    student s
join 
    marks m on s.sid = m.sid;
