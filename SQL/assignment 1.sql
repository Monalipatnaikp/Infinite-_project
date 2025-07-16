create database cb
create table EMP2(
    EMPNO INT PRIMARY KEY,
    ENAME VARCHAR(20),
    JOB VARCHAR(20),
    MGR_ID INT,
    HIREDATE DATE,
    SAL DECIMAL(10, 2),
    COMM DECIMAL(10, 2),
    DEPTNO INT)
insert into EMP2 values (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20);

insert into EMP2 values (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30);

insert into EMP2 values (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30);

insert into EMP2 values (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20);

insert into EMP2 values (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30);

insert into EMP2 values (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30);

insert into EMP2 values (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10);

insert into EMP2 values (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20);

insert into EMP2 values(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10);

insert into EMP2 values (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30);

insert into EMP2 values(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20);

insert into EMP2 values (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30);

insert into EMP2 values (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20);

insert into EMP2 values (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);
select *from EMP2
    
	create table department (
    dEPTNO INT PRIMARY KEY,
    dNAME VARCHAR(20),
    LOC VARCHAR(20))

insert into  department (DEPTNO, DNAME, LOC) VALUES (10, 'ACCOUNTING', 'NEW YORK');
insert into department(DEPTNO, DNAME, LOC) VALUES (20, 'RESEARCH', 'DALLAS');
insert into department (DEPTNO, DNAME, LOC) VALUES (30, 'SALES', 'CHICAGO');
insert into department(DEPTNO, DNAME, LOC) VALUES (40, 'OPERATIONS', 'BOSTON');
select *from department
-----------1---------
 select * from EMP2 where  ENAME like 'A%'
-----------2----------
select * from EMP2 where MGR_ID is null
-----------3-----------
Select ENAME, EMPNO, SAL from EMP2 where  SAL between  1200  and 1400
-----------4-----------
SELECT * FROM EMP2 WHERE DEPTNO = 20
update  EMP2
set SAL = SAL * 1.10 where DEPTNO = 20
select * from EMP2 where DEPTNO = 20
------------5----------
select count(*) as Number_of_Clerks from EMP2 where JOB = 'CLERK'
------------6----------
select JOB, AVG(SAL) as Avg_Salary, COUNT(*) as NumEmployees from EMP2 group by JOB
------------7----------
select MIN(sal) from EMP2  
select MAX(sal) from EMP2 
------------8---------
select * from department where DEPTNO not in (SELECT DISTINCT DEPTNO FROM EMP);
------------9----------
SELECT ENAME, SAL FROM EMP2 WHERE JOB = 'ANALYST' AND SAL > 1200 AND DEPTNO = 20 ORDER BY ENAME;
------------10----------

SELECT department.DNAME, department.DEPTNO, SUM(EMP.SAL) AS Total_Salary
FROM department
JOIN EMP ON DEPT.DEPTNO = EMP.DEPTNO
GROUP BY DEPT.DNAME, DEPT.DEPTNO;

-------------11------------
SELECT ENAME, SAL FROM EMP
WHERE ENAME IN ('MILLER', 'SMITH');


------------12--------------
SELECT * FROM EMP
WHERE ENAME LIKE 'A%' OR ENAME LIKE 'M%';
------------13---------------
SELECT ENAME, SAL * 12 AS Yearly_Salary
FROM EMP
WHERE ENAME = 'SMITH';
------------14-------------
SELECT ENAME, SAL FROM EMP
WHERE SAL NOT BETWEEN 1500 AND 2850;
------------15-------------
SELECT MGR_ID, COUNT(*) AS Num_Employees FROM EMP2 WHERE MGR_ID IS NOT NULL GROUP BY MGR_ID HAVING COUNT(*) > 2;
