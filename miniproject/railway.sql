create database railwaydb
use railwaydb


create table customerss (
    custid int primary key,
    custname varchar(100),
    phone varchar(20),
    mailid varchar(100))
    

create table trains (
    trainno int primary key,
    trainname varchar(100),
    sourcee varchar(50),
    destination varchar(50),
    class varchar(20),
    availabile int,
    costperseat decimal(10,2))



create table reservation (
    bookingid int primary key,
    custno int,
    custname varchar(100),
    traveldate date,
    class varchar(20),
    seatsbooked int,
    totalcost decimal(10,2),
    bookingdate date,
    foreign key (custno) references customerss(custid))

create table cancellation (
    bid int primary key,
    ticketcancelled bit,
    refundamount decimal(10,2),
    cancellationdate date,
    foreign key (bid) references reservation(bookingid))

insert into customerss values (1, 'monali', '9876543210', 'monali@gmail.com')
insert into customerss values(2, 'ramya', '9123456780', 'ramya@gmail.com')
insert into customerss values(3, 'suchithra', '9988776655', 'suchitra@gmail.com')
select *from customerss

insert into trains values (101, 'rajdhani express', 'delhi', 'mumbai', 'sleeper', 100, 500.00)
insert into trains values(102, 'godavari express', 'punjab', 'delhi', '2nd ac', 50, 1200.00)
insert into trains values(103, 'visaka express', 'mumbai', 'visakaptnam', '3rd ac', 75, 800.00)
insert into trains values(104, 'humsafar express', 'visakaptnam', 'tirupati', 'sleeper', 70, 900.00)
select *from trains

INSERT INTO Reservation VALUES (1001, 1, 'monali', '2025-08-10', 'Sleeper', 2, 1000.00, '2024-06-08')
INSERT INTO Reservation VALUES (2002, 2, 'ramya', '2025-08-12', '2nd AC', 1, 1200.00, '2024-08-06')
INSERT INTO Reservation VALUES (3003, 3, 'suchitra', '2025-08-15', '3rd AC', 3, 2400.00, '2024-09-05')
select *from reservation

INSERT INTO Cancellation VALUES (1002, 1, 600.00, '2025-07-30')  











