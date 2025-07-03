using System;

class Account
{
    int accNo;
    string custName;
    string accType;
    char transType;
    int amount;
    int balance;

    public Account(int accNo, string custName, string accType)
    {
        this.accNo = accNo;
        this.custName = custName;
        this.accType = accType;
        this.balance = 0;
    }

    public void Credit(int amt)
    {
        balance += amt;
        Console.WriteLine("Amount Deposited.");
    }

    public void Debit(int amt)
    {
        if (amt <= balance)
        {
            balance -= amt;
            Console.WriteLine("Amount Withdrawn.");
        }
        else
        {
            Console.WriteLine("Insufficient Balance!");
        }
    }

    public void ShowData()
    {
        Console.WriteLine("\n Account Details ");
        Console.WriteLine("Account No: " + accNo);
        Console.WriteLine("Customer Name: " + custName);
        Console.WriteLine("Account Type: " + accType);
        Console.WriteLine("Balance: " + balance);
    }
public void PerformTransaction()
    {
        Console.Write("Enter Transaction Type (D/W): ");
        string input = Console.ReadLine().ToUpper();

        if (!string.IsNullOrEmpty(input))
        {
            transType = input[0];

            Console.Write("Enter Amount: ");
            amount = Convert.ToInt32(Console.ReadLine());

            if (transType == 'D')
            {
                Credit(amount);
            }
            else if (transType == 'W')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid Transaction ");
            }
        }
    }
} class Program
{
    static void Main()
    {
        Console.Write("Enter Account Number: ");
        int accNo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Account Type: ");
        string type = Console.ReadLine();

        Account obj = new Account(accNo, name, type);
        obj.PerformTransaction();
        obj.ShowData();

        Console.ReadLine(); 
    }
}
class Student
        {
            int rollNo;
            string name;
            string className;
            string semester;
            string branch;
            int[] marks = new int[5];

            public Student(int rollNo, string name, string className, string semester, string branch)
            {
                this.rollNo = rollNo;
                this.name = name;
                this.className = className;
                this.semester = semester;
                this.branch = branch;
            }

            public void GetMarks()
            {
                Console.WriteLine("Enter marks for 5 subjects:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Subject {i + 1}: ");
                    marks[i] = Convert.ToInt32(Console.ReadLine());
                }
            }

            public void DisplayResult()
            {
                double avg = 0;
                bool failed = false;

                foreach (int mark in marks)
                {
                    avg += mark;
                    if (mark < 35)
                    {
                        failed = true;
                    }
                }

                avg /= 5;

                if (failed)
                {
                    Console.WriteLine("Result: Failed (One or more subjects < 35)");
                }
                else if (avg < 50)
                {
                    Console.WriteLine("Result: Failed (Average < 50)");
                }
                else
                {
                    Console.WriteLine("Result: Passed");
                }

                Console.WriteLine($"Average Marks: {avg}");
        Console.ReadLine();
            }

            public void DisplayData()
            {
                Console.WriteLine($"\nRoll No: {rollNo}\nName: {name}\nClass: {className}\nSemester: {semester}\nBranch: {branch}");
            }
        } class SaleDetails
        {
            int salesNo;
            int productNo;
            double price;
            int quantity;
            string dateOfSale;
            double totalAmount;

            public SaleDetails(int salesNo, int productNo, double price, int quantity, string date)
            {
                this.salesNo = salesNo;
                this.productNo = productNo;
                this.price = price;
                this.quantity = quantity;
                this.dateOfSale = date;
                this.totalAmount = price * quantity;
            }

            public void ShowData()
            {
                Console.WriteLine($"\nSales No: {salesNo}");
                Console.WriteLine($"Product No: {productNo}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine($"Quantity: {quantity}");
                Console.WriteLine($"Date of Sale: {dateOfSale}");
                Console.WriteLine($"Total Amount: {totalAmount}");
                Console.ReadLine();
            }
        }

    

