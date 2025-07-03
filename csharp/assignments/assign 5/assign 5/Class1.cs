using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign_5
{
    class Class1
    {
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
            }

            public void DisplayData()
            {
                Console.WriteLine($"\nRoll No: {rollNo}\nName: {name}\nClass: {className}\nSemester: {semester}\nBranch: {branch}");
            }
        }



class SaleDetails
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

}
}
