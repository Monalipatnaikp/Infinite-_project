using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment7
{
    class Program
    {
        static void Main()
        {
           
           
            Console.Write("Enter numbers : ");
            var numberInput = Console.ReadLine();
            var numbers = numberInput.Split(' ').Select(int.Parse).ToList();

          
            foreach (var num in numbers)
            {
                int square = num * num;
                if (square > 20)
                {
                    Console.WriteLine($"{num} -> {square}");
                    Console.ReadLine();
                }
            }

           
            Console.WriteLine("\n Words Starting with 'a' and Ending with 'm'");
            Console.Write("Enter words : ");
            var wordInput = Console.ReadLine();
            var words = wordInput.Split(',').Select(w => w.Trim().ToLower()).ToList();

            Console.WriteLine("Words starting with 'a' and ending with 'm':");
            foreach (var word in words)
            {
                if (word.StartsWith("a") && word.EndsWith("m"))
                {
                    Console.WriteLine(word);
                    Console.ReadLine();
                }
            }

        
            Console.WriteLine("\n 3. Employee Data ");

            var employees = new List<Employee>
            {
                new Employee { EmpId = 101, EmpName = "Monali", EmpCity = "Bangalore", EmpSalary = 50000 },
                new Employee { EmpId = 102, EmpName = "Rakshitha", EmpCity = "Delhi", EmpSalary = 40000 },
                new Employee { EmpId = 103, EmpName = "Sravya", EmpCity = "Bangalore", EmpSalary = 30000 },
                new Employee { EmpId = 104, EmpName = "Ramya", EmpCity = "Mumbai", EmpSalary = 60000 }
            };

            Console.WriteLine("\nAll Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmpId} - {emp.EmpName} - {emp.EmpCity} - ₹{emp.EmpSalary}");
            }

            Console.WriteLine("\nEmployees with Salary > 45000:");
            foreach (var emp in employees.Where(e => e.EmpSalary > 45000))
            {
                Console.WriteLine($"{emp.EmpName} - ₹{emp.EmpSalary}");
            }

            Console.WriteLine("\nEmployees from Bangalore:");
            foreach (var emp in employees.Where(e => e.EmpCity.ToLower() == "bangalore"))
            {
                Console.WriteLine($"{emp.EmpName} - {emp.EmpCity}");
            }

            Console.WriteLine("\nEmployees in Name Ascending Order:");
            foreach (var emp in employees.OrderBy(e => e.EmpName))
            {
                Console.WriteLine(emp.EmpName);
                Console.ReadLine();
            }


            Console.WriteLine("\n Travel Concession Based on Age");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            const int TotalFare = 500;

            if (age <= 5)
            {
                Console.WriteLine($"Hi {name}, you're a Little Champ. Free ticket!");
            }
            else if (age > 60)
            {
                double discount = TotalFare * 0.3;
                double finalFare = TotalFare - discount;
                Console.WriteLine($"Hi {name}, you're a Senior Citizen.");
                Console.WriteLine($"Concession applied: ₹{discount}");
                Console.WriteLine($"Final Ticket Fare: ₹{finalFare}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($" {name}, Ticket Book");
                Console.ReadLine();
            }

        }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
}