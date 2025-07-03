using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_challenge_2
{
    class Program
    {
    abstract class Student
    {
        public string Name;
        public int StudentId;
        public double Grade;

       
        public abstract bool IsPassed(double grade);
    }
   class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
   class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }
  class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;
    }
  static void Main(string[] args)
        {
            Console.WriteLine(" Student Check ");
            HandleStudents();

            Console.WriteLine("\n Product Sorting ");
            HandleProducts();

            Console.WriteLine("\n Exception Handling ");
            HandleExceptionCheck();
        }
     static void HandleStudents()
        {
            Console.Write("Enter Undergraduate Student Name: ");
            string ugName = Console.ReadLine();
            Console.Write("Enter Student ID: ");
            int ugId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade: ");
            double ugGrade = Convert.ToDouble(Console.ReadLine());
            Undergraduate ug = new Undergraduate() { Name = ugName, StudentId = ugId, Grade = ugGrade };
            Console.WriteLine($"{ug.Name}(undergraduate)  is passed ");
            Console.Write("\nEnter Graduate Student Name: ");
            string gName = Console.ReadLine();
            Console.Write("Enter Student ID: ");
            int gId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade: ");
            double gGrade = Convert.ToDouble(Console.ReadLine());
            Graduate g = new Graduate() { Name = gName, StudentId = gId, Grade = gGrade };
            Console.WriteLine($"{g.Name} (Graduate) is passed ");
        }  static void HandleProducts()
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Enter Products :");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\n Product :");

                Console.Write("Product ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                products.Add(new Product() { ProductId = id, ProductName = name, Price = price });
            }

            products.Sort((x, y) => x.Price.CompareTo(y.Price));

            Console.WriteLine("\nSorted Products by Price:");
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Price: {p.Price}");
            }
        }

        static void HandleExceptionCheck()
        {
            try
            {
                Console.Write("Enter a number ");
                int num = Convert.ToInt32(Console.ReadLine());
                
                int result = Square(num);
                Console.WriteLine($" {num} is: {result}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                Console.ReadLine();
            }
        }
        
        static int Square(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Negative numbers ");
            }
            return number * number;
            Console.ReadLine();
          
            
        }
    }

    
        
        }
    

