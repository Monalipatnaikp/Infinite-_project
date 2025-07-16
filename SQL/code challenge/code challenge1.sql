create database tp
------------1-----------
create table book (
    id INT PRIMARY KEY,
    title VARCHAR(14),
    author VARCHAR(19),
    isbn BIGINT UNIQUE,
    published DATETIME)

INSERT INTO book VALUES (1, 'My First SQL book', 'Mary Parker', 981483029127, 2012-02)
INSERT INTO book VALUES(2, 'My Second SQL book', 'John Mayer', 857300923713, 1972-02)
INSERT INTO book VALUES(3, 'My Third SQL book', 'Cary Flint', 523120967812, 2015-10)


select * from book where author like '%er'



--------2---------
create table reviews (
    id INT,
    book_id INT,
    reviewer_name VARCHAR(100),
    content TEXT,
    rating INT,
    published_date DATETIME)

INSERT INTO reviews VALUES (123, 1, 'John Smith', 'My first review', 5, 2017)
INSERT INTO reviews VALUES(124, 2, 'Alice Walker','My second review', 4, 2017)
INSERT INTO reviews VALUES(125, 2, 'John Smith', 'My third  review', 1, 2018)

select  b.title, b.author, r.reviewer_name from book b JOIN  reviews r on b.id = r.book_id





------------3------------
create table customer (
    id INT,
    name VARCHAR(16),
    age INT,
    address VARCHAR(15),
    salary DECIMAL(10, 2))
INSERT INTO customer  VALUES (1, 'Ramesh', 32, 'Ahmedabad', 2000.00)
INSERT INTO customer  VALUES(2, 'Khilan', 25, 'Delhi', 1500.00)
INSERT INTO customer  VALUES(3, 'Kaushik', 23, 'Kota', 2000.00)
INSERT INTO customer  VALUES(4, 'Chaitali', 25, 'Mumbai', 6500.00)
INSERT INTO customer  VALUES(5, 'Hardik', 27, 'Bhopal', 8500.00)
INSERT INTO customer  VALUES(6, 'Komal', 22, 'MP', 4500.00)
INSERT INTO customer  VALUES(7, 'Muffy', 24, 'Indore', 10000.00)

select name from customer WHERE address like '%o%'


---------4--------------
create table order1 (
    oid INT,
    odate DATETIME,
    customer_id INT,
    amount DECIMAL(10,2))
INSERT INTO order1 VALUES(102 ,2009-10,1, 3000)
INSERT INTO order1 VALUES(100,2003-10,3, 1500)
INSERT INTO order1 VALUES(101, 2009-11, 2, 1560)
INSERT INTO order1 VALUES(103, 2008-05, 4, 2960)
SELECT odate,COUNT(DISTINCT customer_id) AS total_customers FROM order1 GROUP BY odate


---------5--------------
create table employee1 (
    id INT,
    name VARCHAR(100),
    age INT,
    address VARCHAR(100),
    salary DECIMAL(10, 2))
	INSERT INTO employee1 VALUES(1, 'Ramesh', 32, 'Ahmedabad', NULL)
INSERT INTO employee1 VALUES(2, 'Khilan', 25, 'Delhi', 1500.00)
INSERT INTO employee1 VALUES(3, 'Kaushik', 23, 'Kota', 2000.00)
INSERT INTO employee1 VALUES(4, 'Chaitali', 25, 'Mumbai', 6500.00)
INSERT INTO employee1 VALUES(5, 'Hardik', 27, 'Bhopal', 8500.00)
INSERT INTO employee1 VALUES(6, 'Komal', 22, 'MP', NULL)
INSERT INTO employee1 VALUES(7, 'Muffy', 24, 'Indore', 10000.00)

select LOWER(name) as name_in_lowercase from employee1 where salary is null



---------------5------------------
create table StudentDetails (
    RegisterNo INT,
    Name VARCHAR(50),
    Age INT,
    Qualification VARCHAR(20),
    MobileNo VARCHAR(15),
    MailID VARCHAR(100),
    Location VARCHAR(50),
    Gender CHAR(1))
INSERT INTO StudentDetails VALUES(1, 'Kumar', 20, 'BSC', '9952836777', 'Sai@gmail.com', 'Madurai', 'F')
INSERT INTO StudentDetails VALUES(2, 'Nisha', 25, 'B.Tech', '7890125648', 'Kumar@gmail.com', 'Chennai', 'M')
INSERT INTO StudentDetails VALUES(3, 'Selvi', 22, 'M.E', '8904567342', 'selvi@gmail.com', 'Madurai', 'M')
INSERT INTO StudentDetails VALUES(4, 'SaiSaran', 21, 'B.A', '7834672310', 'Nisha@gmail.com', 'Selam', 'F')
INSERT INTO StudentDetails VALUES(5, 'Tom', 23, 'BCA', '7890345678', 'saran@gmail.com', 'Theni', 'F')
INSERT INTO StudentDetails VALUES(6, 'Saran', 24, 'B.Sc', '8901234675', 'Tom@gmail.com', 'Pune', 'M')

select Gender,COUNT(*) as TotalCount from StudentDetails group by Gender



