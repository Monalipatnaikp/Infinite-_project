using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment
{
    
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager", DOB=DateTime.Parse("1984-11-16"), DOJ=DateTime.Parse("2011-06-08"), City="Mumbai"},
                new Employee{EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager", DOB=DateTime.Parse("1984-08-20"), DOJ=DateTime.Parse("2012-07-07"), City="Mumbai"},
                new Employee{EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant", DOB=DateTime.Parse("1987-11-14"), DOJ=DateTime.Parse("2015-04-12"), City="Pune"},
                new Employee{EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE", DOB=DateTime.Parse("1990-06-03"), DOJ=DateTime.Parse("2016-02-02"), City="Pune"},
                new Employee{EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE", DOB=DateTime.Parse("1991-03-08"), DOJ=DateTime.Parse("2016-02-02"), City="Mumbai"},
                new Employee{EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant", DOB=DateTime.Parse("1989-11-07"), DOJ=DateTime.Parse("2014-08-08"), City="Chennai"},
                new Employee{EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant", DOB=DateTime.Parse("1989-12-02"), DOJ=DateTime.Parse("2015-06-01"), City="Mumbai"},
                new Employee{EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate", DOB=DateTime.Parse("1993-11-11"), DOJ=DateTime.Parse("2014-11-06"), City="Chennai"},
                new Employee{EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate", DOB=DateTime.Parse("1992-08-12"), DOJ=DateTime.Parse("2014-12-03"), City="Chennai"},
                new Employee{EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager", DOB=DateTime.Parse("1991-04-12"), DOJ=DateTime.Parse("2016-01-02"), City="Pune"}
            };

         

            Console.WriteLine(" Employees  joined before 1/1/2015:");
            var joinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            foreach (var emp in joinedBefore2015)
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - DOJ: {emp.DOJ.ToShortDateString()}");
   

            Console.WriteLine("\n Employees born after 1/1/1990:");
            var bornAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            foreach (var emp in bornAfter1990)
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - DOB: {emp.DOB.ToShortDateString()}");
           

            Console.WriteLine("\n Employees Consultant or Associate:");
            var consultantsAndAssociates = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            foreach (var emp in consultantsAndAssociates)
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - Title: {emp.Title}");
            

            Console.WriteLine($"\n Total number of employees: {empList.Count}");
         

            Console.WriteLine($"\n Total employees in Chennai: {empList.Count(e => e.City == "Chennai")}");
            

            Console.WriteLine($"\n Highest Employee ID: {empList.Max(e => e.EmployeeID)}");
            

            Console.WriteLine($"\n Employees  joined after 1/1/2015: {empList.Count(e => e.DOJ > new DateTime(2015, 1, 1))}");
       

            Console.WriteLine($"\n Employees who  is not Associate: {empList.Count(e => e.Title != "Associate")}");
            

            Console.WriteLine("\n Total employees by City:");
            var empByCity = empList.GroupBy(e => e.City);
            foreach (var group in empByCity)
                Console.WriteLine($"{group.Key}: {group.Count()}");
           

            Console.WriteLine("\n Total employees by City and Title:");
            var empByCityTitle = empList.GroupBy(e => new { e.City, e.Title });
            foreach (var group in empByCityTitle)
                Console.WriteLine($"{group.Key.City} - {group.Key.Title}: {group.Count()}");
           

            Console.WriteLine("\n Youngest employee:");
            var youngest = empList.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"{youngest.FirstName} {youngest.LastName} - DOB: {youngest.DOB.ToShortDateString()}");
            Console.ReadLine();
        }
    }
}
