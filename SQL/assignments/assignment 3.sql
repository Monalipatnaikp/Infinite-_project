use cb
 
----------1-------------
 select * from empp where job = 'manager'
----------2-------------
select ename, sal from empp where sal > 1000
-----------3------------
select ename, sal from empp where ename != 'james'
-----------4-------------
select * from empp where ename like 's%'
-------------5-----------
select ename from empp where ename like '%a%'
--------------6-----------
select ename from empp where ename like '__l%'
---------------7-----------
select ename, sal / 30 as daily_salary from empp where ename = 'jones'
----------------8----------
select sum(sal) as total_monthly_salary from empp
----------------9-----------
select avg(sal * 12) as average_annual_salary from empp
----------------10----------
select ename, job, sal, deptno from empp where deptno = 30 and job != 'salesman'
---------------11------------
select distinct deptno from empp
---------------12-------------
select ename as employee, sal as "monthly_salary" from empp where sal > 1500 and deptno in (10, 30)
--------------13---------------
select ename, job, sal from empp where job in ('manager', 'analyst') and sal not in (1000, 3000, 5000)
--------------14---------------
select ename, sal, comm from empp where comm > sal * 1.1
---------------15--------------
select ename from empp where (ename like '%l%l%' and deptno = 30) or mgr_id = 7782
----------------16------------
select ename from empp where datediff(year, hiredate, getdate()) > 30 and datediff(year, hiredate, getdate()) < 40
select count(*) as total_employees from empp
----------------17--------------
select deptno, ename from empp order by deptno asc, ename desc
----------------18--------------
select datediff(year, hiredate, getdate()) as experience from empp where ename = 'miller'