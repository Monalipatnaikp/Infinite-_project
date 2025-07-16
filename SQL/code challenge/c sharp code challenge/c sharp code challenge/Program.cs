using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_code_challenge
{
    class Program
   
    {
        public class Employee
        {  public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public DateTime DOB { get; set; }
            public string Location { get; set; }
        }

       
        
            static void Main(string[] args)
            {

            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), Location = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "Manager", DOB = new DateTime(1984, 7, 7), Location = "Delhi" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "AsstManager", DOB = new DateTime(1994, 8, 20), Location = "Chennai" },
                new Employee { EmployeeID = 1004, FirstName = "Shaikh", LastName = "Shaikh", Title = "Consultant", DOB = new DateTime(1987, 11, 14), Location = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), Location = "Chennai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), Location = "Pune" },
                new Employee { EmployeeID = 1007, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), Location = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), Location = "Delhi" },
                new Employee { EmployeeID = 1009, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), Location = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Suresh", LastName = "Shah", Title = "Associate", DOB = new DateTime(1992, 8, 12), Location = "Pune" },
                new Employee { EmployeeID = 1011, FirstName = "Sumit", LastName = "Mistry", Title = "Manager", DOB = new DateTime(1991, 4, 12), Location = "Mumbai" }
            };
                void DisplayEmployee(Employee emp)
                {
                    Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, Location: {emp.Location}");
                }
                Console.WriteLine("\n All Employee Details:");
                foreach (var emp in empList)
                    DisplayEmployee(emp);
                Console.WriteLine("\n Employees whose location is not in Mumbai:");
                var notMumbai = empList.Where(e => !string.Equals(e.Location, "Mumbai", StringComparison.OrdinalIgnoreCase));
                foreach (var emp in notMumbai)
                    DisplayEmployee(emp);
                Console.WriteLine("\n Employees with title AsstManager:");
                var asstManagers = empList.Where(e => e.Title == "AsstManager");
                foreach (var emp in asstManagers)
                    DisplayEmployee(emp);
                Console.WriteLine("\nEmployees whose Last Name starts with 'S':");
                var lastNameS = empList.Where(e => e.LastName.StartsWith("S", StringComparison.OrdinalIgnoreCase));
                foreach (var emp in lastNameS)
                    DisplayEmployee(emp);

                Console.ReadLine();
            }
        }
    }
   