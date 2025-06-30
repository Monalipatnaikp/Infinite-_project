using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {

        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
               
                

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddEmployee();
                            break;
                        case "2":
                            ViewAllEmployees();
                            break;
                        case "3":
                            SearchEmployee();
                            break;
                        case "4":
                            UpdateEmployee();
                            break;
                        case "5":
                            DeleteEmployee();
                            break;
                        case "6":
                            keepRunning = false;
                            Console.WriteLine("Exit");
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

       
        static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter ID: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            employees.Add(emp);
            Console.WriteLine("Employee added successfully.");
        }

        static void ViewAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine(" Employee List");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
            }
        }

       
        static void SearchEmployee()
        {
            Console.Write("Enter ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine($"Found: ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        
        static void UpdateEmployee()
        {
            Console.Write("Enter ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.Write("New Name (Leave blank to keep same): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) emp.Name = name;

                Console.Write("New Department (Leave blank to keep same): ");
                string dept = Console.ReadLine();
                if (!string.IsNullOrEmpty(dept)) emp.Department = dept;

                Console.Write("New Salary (Leave blank to keep same): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(salaryInput))
                    emp.Salary = Convert.ToDouble(salaryInput);

                Console.WriteLine("Employee details updated.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

   
        static void DeleteEmployee()
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
                Console.ReadLine();
            }
        }
    }
}
