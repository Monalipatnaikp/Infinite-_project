
create database we
CREATE TABLE Employee_D (
    EmpId INT IDENTITY(1,1) PRIMARY KEY,     
    Name VARCHAR(100),
    Salary DECIMAL(10,2),                      
    NetSalary DECIMAL(10,2),                   
    Gender VARCHAR(10))

	CREATE PROCEDURE InsertEmployeeDetails
    @Name NVARCHAR(100),
    @GivenSalary DECIMAL(10,2),
    @Gender NVARCHAR(10),
    @GeneratedEmpId INT OUTPUT,
    @CalculatedSalary DECIMAL(10,2) OUTPUT,
    @CalculatedNetSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

   
    SET @CalculatedSalary = @GivenSalary * 0.90;
    SET @CalculatedNetSalary = @CalculatedSalary * 0.90;

    INSERT INTO Employee_D (Name, Salary, NetSalary, Gender)
    VALUES (@Name, @CalculatedSalary, @CalculatedNetSalary, @Gender);

   
    SET @GeneratedEmpId = SCOPE_IDENTITY();
END;

DECLARE @Empname varchar,@EmpId INT, @Salary DECIMAL(10,2), @NetSalary DECIMAL(10,2);

EXEC InsertEmployeeDetails
    @Name = 'monali',
    @GivenSalary = 90000,
    @Gender = 'female',
    @GeneratedEmpId = @EmpId OUTPUT,
    @CalculatedSalary = @Salary OUTPUT,
    @CalculatedNetSalary = @NetSalary OUTPUT;
	

SELECT 
    'Inserted Successfully' AS Status,
    @EmpId AS GeneratedEmpId,
    @Salary AS SalaryAfter10Percent,
    @NetSalary AS NetSalaryAfterAdditional10Percent;
	select *from  Employee_D
	--------2-----------
	
	
	
	CREATE PROCEDURE UpdateEmployeeSalarys
    @EmpId INT,
    @UpdatedSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentSalary DECIMAL(10,2);

    
    SELECT @CurrentSalary = Salary
    FROM Employee_D
    WHERE EmpId = @EmpId;

    
    IF @CurrentSalary IS NOT NULL
    BEGIN
        SET @UpdatedSalary = @CurrentSalary + 100;

        UPDATE Employee_D
        SET Salary = @UpdatedSalary
        WHERE EmpId = @EmpId;
    END
    ELSE
    BEGIN
       
        SET @UpdatedSalary = 0;
    END
END

DECLARE @NewSalary DECIMAL(10,2);


EXEC UpdateEmployeeSalarys
    @EmpId = 1,
    @UpdatedSalary = @NewSalary OUTPUT;


PRINT 'Updated Salary = ₹' + CAST(@NewSalary AS VARCHAR);

