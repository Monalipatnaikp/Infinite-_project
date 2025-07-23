use cb
--------1----------
create table person (
    name varchar(50),
    birthday date)
insert into person values ('monali', '2004-08-02');
select *from person
select 
    name,
    birthday,
    datename(weekday, birthday) as day_of_week
from 
    person

-------2-----------
select 
    name,
    birthday,
    datediff(day, birthday, getdate()) as age_in_days
from 
    person

--------3---------
create table empp1 (
    emp_id int,
    emp_name varchar(50),
    join_date date)

insert into empp1 values (1, 'monali', '2018-07-10')
insert into empp1 values (2, 'sravya', '2015-07-20')
insert into empp1 values (3, 'lakshmi', '2020-07-05')
insert into empp1 values (4, 'rakshi', '2019-06-15')
insert into empp1 values (5, 'ramya', '2014-07-25')

select *from empp1
where join_date <= dateadd(year, -5, getdate()) and month(join_date) = month(getdate());


---------4--------------
create table employee (
    empno int primary key,
    ename varchar(50),
    sal decimal(10,2),
    doj date)
insert into employee values (101, 'monali', 30000, '2011-06-10')
insert into employee values (102, 'minnie', 35000, '2012-07-15')
insert into employee values (103, 'rakshitha', 49000, '2013-08-20')

update employee
set sal = sal * 1.15
where empno = 102;
select *from employee


delete from employee
where empno = 101;
select *from employee


begin transaction beforedelete;
delete from employee
where empno = 101;
rollback transaction beforedelete;
commit;


--------5------------------

create function  dbo.calculatebonus (
    @sal decimal(10,2),
    @deptno int)
returns decimal(10,2)
as
begin
    declare @bonus decimal(10,2);

    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;

    return @bonus;
end;

select 
    empno,
    ename,
    sal,
    deptno,
    dbo.calculatebonus(sal, deptno) as bonus
from 
    empp;
-----------6-------------
create procedure updatesalesssalary
as
begin
    update empp
    set sal = sal + 500
    where job = 'salesman' and sal < 1500;
    select empno, ename, job, sal
    from empp
    where job = 'salesman';
end;
exec updatesalesssalary;
















