 
BEGIN
    CREATE DATABASE railwaydbb;
END
GO
USE railwaydbb;
GO

-- Customers
IF OBJECT_ID('dbo.Customerss','U') IS NULL
CREATE TABLE dbo.Customerss (
    CustID INT PRIMARY KEY,
    CustName VARCHAR(100),
    Phone VARCHAR(20),
    MailID VARCHAR(100)
);

-- Train
IF OBJECT_ID('dbo.Train','U') IS NULL
CREATE TABLE dbo.Train (
    TrainID INT IDENTITY(1,1) PRIMARY KEY,
    TrainName NVARCHAR(100) NOT NULL,
    Source NVARCHAR(50) NOT NULL,
    Destination NVARCHAR(50) NOT NULL,
    DepartureTime DATETIME NOT NULL,
    ArrivalTime DATETIME NOT NULL,
    TotalSeats INT NOT NULL,
    AvailableSeats INT NOT NULL
);

-- TrainClasses
IF OBJECT_ID('dbo.TrainClasses','U') IS NULL
CREATE TABLE dbo.TrainClasses (
    TrainID INT NOT NULL,
    ClassName VARCHAR(50) NOT NULL,
    SeatCount INT NOT NULL,
    Fare DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_TrainClasses_Train FOREIGN KEY (TrainID) REFERENCES dbo.Train(TrainID)
);

-- Reservation
IF OBJECT_ID('dbo.Reservation','U') IS NULL
CREATE TABLE dbo.Reservation (
    BookingID INT PRIMARY KEY,
    CustNo INT,
    TrainID INT,
    CustName VARCHAR(100),
    TravelDate DATE,
    Class VARCHAR(20),
    SeatsBooked INT,
    TotalCost DECIMAL(10,2),
    BookingDate DATE,
    CONSTRAINT FK_Reservation_Customer FOREIGN KEY (CustNo) REFERENCES dbo.Customerss(CustID),
    CONSTRAINT FK_Reservation_Train FOREIGN KEY (TrainID) REFERENCES dbo.Train(TrainID)
);
select *from dbo.Reservation

-- Cancellation
IF OBJECT_ID('dbo.Cancellations','U') IS NULL
CREATE TABLE dbo.Cancellations (
    BookingID INT PRIMARY KEY,
    TicketCancelled BIT,
    RefundAmount DECIMAL(10,2),
    CancellationDate DATE,
    CONSTRAINT FK_Cancellation_Reservations FOREIGN KEY (BookingID) REFERENCES dbo.Reservation(BookingID)
);


-- sample data (only inserts if not exist)
IF NOT EXISTS (SELECT 1 FROM dbo.Customerss WHERE CustID = 1)
INSERT INTO dbo.Customerss (CustID, CustName, Phone, MailID) VALUES
(1, 'Monali', '9876543210', 'monali@gmail.com'),
(2, 'Ramya', '9123456780', 'ramya@gmail.com'),
(3, 'Suchithra', '9988776655', 'suchitra@gmail.com');

IF NOT EXISTS (SELECT 1 FROM dbo.Train)
BEGIN
    INSERT INTO dbo.Train (TrainName, Source, Destination, DepartureTime, ArrivalTime, TotalSeats, AvailableSeats)
    VALUES
    ('Visakha Express', 'Visakhapatnam', 'Secunderabad', '2025-08-12 06:00:00', '2025-08-12 18:00:00', 500, 500),
    ('Godavari Express', 'Visakhapatnam', 'Hyderabad', '2025-08-12 19:00:00', '2025-08-13 07:00:00', 450, 450),
    ('Janmabhoomi Express', 'Visakhapatnam', 'Vijayawada', '2025-08-12 14:00:00', '2025-08-12 20:00:00', 400, 400);
END

IF NOT EXISTS (SELECT 1 FROM dbo.TrainClasses)
BEGIN
    INSERT INTO dbo.TrainClasses (TrainID, ClassName, SeatCount, Fare) VALUES
    (1, 'Sleeper', 300, 350.00),
    (1, 'AC 3 Tier', 120, 750.00),
    (1, 'AC 2 Tier', 60, 1100.00),
    (2, 'Sleeper', 280, 400.00),
    (2, 'AC 3 Tier', 120, 800.00),
    (3, 'Sleeper', 250, 300.00),
    (3, 'AC Chair Car', 100, 500.00);
	INSERT INTO  dbo.Cancellation VALUES (1001, 1, 500, '2025-08-11')

END