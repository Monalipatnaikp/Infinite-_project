use cb
-----------1--------------
create procedure gn_payslip 
    @empno int
as
begin
    declare @ename varchar(100), @sal decimal(10,2);
    declare @hra decimal(10,2), @da decimal(10,2);
    declare @pf decimal(10,2), @it decimal(10,2);
    declare @deduction decimal(10,2), @gross decimal(10,2), @net decimal(10,2);
    select @ename = ename, @sal = sal 
    from empp 
    where empno = @empno;
    set @hra = @sal * 0.10;
    set @da = @sal * 0.20;
    set @pf = @sal * 0.08;
    set @it = @sal * 0.05;
    set @deduction = @pf + @it;
    set @gross = @sal + @hra + @da;
    set @net = @gross - @deduction;
 
    print '===== payslip =====';
    print 'employee no     : ' + cast(@empno as varchar);
    print 'name            : ' + @ename;
    print 'basic salary    : ' + cast(@sal as varchar);
    print 'hra (10%)       : ' + cast(@hra as varchar);
    print 'da (20%)        : ' + cast(@da as varchar);
    print 'pf (8%)         : ' + cast(@pf as varchar);
    print 'it (5%)         : ' + cast(@it as varchar);
    print 'deductions      : ' + cast(@deduction as varchar);
    print 'gross salary    : ' + cast(@gross as varchar);
    print 'net salary      : ' + cast(@net as varchar);
    print '===================';
 
end;
exec gn_payslip @empno =7566;


------------2----------------

create table holidayss(
    holiday_date date primary key,
    holiday_name varchar(50))

insert into holidayss values('2025-12-25', 'christmas') 
insert into holidayss values ('2025-10-02', 'gandhi jayanthi')
insert into holidayss values('2025-07-25', 'new year')
insert into holidayss values('2025-07-24', 'independence day')
select *from holidayss


 
create trigger trg_on_holiday
on empp
after insert, update, delete
as
begin
    declare @today date = cast(getdate() as date);
    declare @holidayname varchar(100);

    
    select @holidayname = holiday_name
    from holidayss
    where holiday_date = @today;

    if @holidayname is not null
    begin
        raiserror('due to %s you cannot manipulate data.', 16, 1, @holidayname);
        rollback transaction;
    end
end;
update empp set sal = sal + 800 where empno = 101;

