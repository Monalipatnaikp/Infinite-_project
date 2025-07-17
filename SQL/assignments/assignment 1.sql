create database mp






create table client(
    Client_ID INT ,
    Cname VARCHAR(40) NOT NULL,
    adresss VARCHAR(30),
    Email VARCHAR(30) UNIQUE,
    Phone INT NOT NULL,
    Business VARCHAR(20))

	insert into client values(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing')
    insert into client values(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant')
    insert into client values(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller')
    insert into client values(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional')
	
	select *from client2




create table employeee1(
             EMPNO INT,
			 ENAME varchar(80),
			 JOB varchar(90),
			 SALARY INT,
			 DEPTNO INT)
insert into employeee1 values(7001,'Sandeep ','Analyst',25000,10)
insert into employeee1 values(7002,'rajesh','designer',30000,10)
insert into employeee1 values(7003,'madhav','develepor',40000,20)
insert into employeee1 values(7004,'manoj','developer',40000,20)
insert into employeee1 values(7005,'abhay','designer',35000,10)
insert into employeee1 values(7006,'uma','tester',30000,30)
insert into employeee1 values(7007,'gita','tech writer',30000,40)
insert into employeee1 values(7008,'priya','tester',35000,30)
insert into employeee1 values(7009,'nutan','developer',45000,20)
insert into employeee1 values(7010,'smitha','analyst',20000,10)
insert into employeee1 values(7011,'anand','projectmgr',65000,10)

select *from employeee1



create table department1(
            DEPTNO INT,
			DNAME varchar(80),
			LOC varchar(60))

insert into department1 values(10,'design','pune')
insert into department1 values(20,'development','pune')
insert into department1 values(30,'testing','mumbai')
insert into department1 values(40,'document','mumbai')

select *from department1





create table project1(
            project_id INT,
			descr varchar(50),
			startdate DATE,
			planned_enddate DATE,
			actual_enddate DATE,
			budget INT,
			clientid INT)

insert into project1 values(401, 'inventory', '2011-04-10' ,'2011-10-01' ,'2011-10-31', 15000, 1001 )
insert into project1 values(402, 'accunting', '2011-8-30' ,'2011-1-01' ,'2011-10-31', 50000, 1002 )
insert into project1 values(401, 'payroll', '2011-10-01' ,'2011-12-11' ,'2011-10-31', 75000, 1003 )
insert into project1 values(401, 'contact mgmt', '2011-11-11' ,'2011-12-01' ,'2011-10-31', 50000, 1004 )

select *from project1


create table EmpprojectTask(
              project_id INT,
			  EMPNO INT,
			  starting_date DATE,
			  ending_date DATE,
			  task varchar(70),
			  statuss varchar(80))

insert into EmpprojectTask values(401, 7001, '2011-04-01', '2011-04-20', 'System Analysis',' Completed') 
insert into EmpprojectTask values(401, 7002, '2011-04-21', '2011-05-30', 'system design',' Completed') 
insert into EmpprojectTask values(401, 7003, '2011-06-01', '2011-07-15', 'coding',' Completed') 
insert into EmpprojectTask values(401, 7004, '2011-06-18', '2011-07-11', 'coding',' Completed') 
insert into EmpprojectTask values(401, 7006, '2011-09-03', '2011-09-15', 'testing',' Completed') 
insert into EmpprojectTask values(401, 7009, '2011-09-18', '2011-10-15', 'code challenge',' Completed') 
insert into EmpprojectTask values(401, 7008, '2011-10-06', '2011-10-16', 'testing',' Completed') 
insert into EmpprojectTask values(401, 7007, '2011-10-06', '2011-10-22', 'documentation',' Completed') 
insert into EmpprojectTask values(401, 7011, '2011-10-22', '2011-10-31', 'Sign off',' Completed') 
insert into EmpprojectTask values(402, 7010, '2011-08-01', '2011-08-20', 'System Analysis',' Completed') 

select *from EmpprojectTask

























    





