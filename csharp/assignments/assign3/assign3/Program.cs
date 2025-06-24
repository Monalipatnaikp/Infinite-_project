using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3
{
    class program


    {
    class Accounts
        {

       int accountNo;
        string customerName;
        string accountType;
        char transactionType;
        int amount;
        int balance;
            public Accounts(int accNo, string name, string accType, char transType, int amt, int initialBalance)
            {
                accountNo = accNo;
                customerName = name;
                accountType = accType;
                transactionType = transType;
                amount = amt;
                balance = initialBalance;
                if (transactionType == 'd')
                {
                    Credit(amount);
                }
                else if (transactionType == 'w')
                {
                    Debit(amount);
                }
            }
          void Credit(int amt)
            {
                balance = balance + amt;
            }
          void Debit(int amt)
            {
                if (amt <= balance)
                {
                    balance = balance - amt;
                }
                else
                {
                    Console.WriteLine("Not enough balance to withdraw!");
                }
            }
            public void ShowData()
            {
                Console.WriteLine("\n----- Account Details -----");
                Console.WriteLine("Account No      : " + accountNo);
                Console.WriteLine("Customer Name   : " + customerName);
                Console.WriteLine("Account Type    : " + accountType);
                Console.WriteLine("Transaction Type: " + transactionType);
                Console.WriteLine("Amount          : " + amount);
                Console.WriteLine("Final Balance   : " + balance);
            }
        }   class Student
        {
            int rollNo;
            string name;
            string studentClass;
            string semester;
            string branch;
            int[] marks = new int[5];
            public Student(int r, string n, string cls, string sem, string br)
            {
                rollNo = r;
                name = n;
                studentClass = cls;
                semester = sem;
                branch = br;
            }  public void GetMarks()
            {
                Console.WriteLine("\nEnter marks for 5 subjects:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("Subject " + (i + 1) + ": ");
                    marks[i] = int.Parse(Console.ReadLine());
                }
            }  
            public void DisplayResult()
            {
                int total = 0;
                bool failedSubject = false;

                for (int i = 0; i < 5; i++)
                {
                    total += marks[i];
                    if (marks[i] < 35)
                    {
                        failedSubject = true;
                    }
                }

                double avg = total / 5.0;

                Console.WriteLine("\n----- Result -----");
                if (failedSubject)
                {
                    Console.WriteLine("Result: Failed (Subject < 35)");
                }
                else if (avg < 50)
                {
                    Console.WriteLine("Result: Failed (Average < 50)");
                }
                else
                {
                    Console.WriteLine("Result: Passed");
                }
            }
                public void DisplayData()
            {
                Console.WriteLine("\n----- Student Details -----");
                Console.WriteLine("Roll No   : " + rollNo);
                Console.WriteLine("Name      : " + name);
                Console.WriteLine("Class     : " + studentClass);
                Console.WriteLine("Semester  : " + semester);
                Console.WriteLine("Branch    : " + branch);
                Console.WriteLine("Marks     : " + string.Join(", ", marks));
            }
        }
          class SaleDetails
          {
            int salesNo;
            int productNo;
            double price;
            string dateOfSale;
            int qty;
            double totalAmount;
            public SaleDetails(int sNo, int pNo, double prc, int quantity, string date)
            {
                salesNo = sNo;
                productNo = pNo;
                price = prc;
                qty = quantity;
                dateOfSale = date;
                Sales();
            }
            public void Sales()
            {
                totalAmount = qty * price;
            }    public void ShowData()
            {
                Console.WriteLine("\n----- Sale Details -----");
                Console.WriteLine("Sales No     : " + salesNo);
                Console.WriteLine("Product No   : " + productNo);
                Console.WriteLine("Price        : " + price);
                Console.WriteLine("Quantity     : " + qty);
                Console.WriteLine("Date of Sale : " + dateOfSale);
                Console.WriteLine("Total Amount : " + totalAmount);
            }
        }
        class Program
        {
            static void Main()
            {
                Console.WriteLine("Enter Account Details:");
                Console.Write("Account Number: ");
                int accNo = int.Parse(Console.ReadLine());
                Console.Write("Customer Name: ");
                string custName = Console.ReadLine();
                Console.Write("Account Type: ");
                string accType = Console.ReadLine();
                Console.Write("Transaction Type (d/w): ");
                char transType = char.Parse(Console.ReadLine());
                Console.Write("Amount: ");
                int amt = int.Parse(Console.ReadLine());
                Console.Write("Initial Balance: ");
                int balance = int.Parse(Console.ReadLine());
                Accounts acc = new Accounts(accNo, custName, accType, transType, amt, balance);
                acc.ShowData();
                Console.WriteLine("\n\nEnter Student Details:");
                Console.Write("Roll No: ");
                int roll = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Class: ");
                string cls = Console.ReadLine();
                Console.Write("Semester: ");
                string sem = Console.ReadLine();
                Console.Write("Branch: ");
                string br = Console.ReadLine();

                Student stu = new Student(roll, name, cls, sem, br);
                stu.GetMarks();
                stu.DisplayResult();
                stu.DisplayData();
                Console.WriteLine("\n\nEnter Sale Details:");
                Console.Write("Sales No: ");
                int salesNo = int.Parse(Console.ReadLine());
                Console.Write("Product No: ");
                int productNo = int.Parse(Console.ReadLine());
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int qty = int.Parse(Console.ReadLine());
                Console.Write("Date of Sale: ");
                string date = Console.ReadLine();
                SaleDetails sale = new SaleDetails(salesNo, productNo, price, qty, date);
                sale.ShowData();
                Console.ReadLine();
            }
        }
    }
}