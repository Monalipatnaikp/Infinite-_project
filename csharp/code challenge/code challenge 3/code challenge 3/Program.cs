using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_challenge_3
{
    class Program

    {    
   class CricketTeam
        {
            public void PointsCalculation(int no_of_matches)
            {
                int[] scores = new int[no_of_matches];
                int sum = 0;

                Console.WriteLine("\nEnter the scores");
                for (int i = 0; i < no_of_matches; i++)
                {
                    Console.Write($"Score for match {i + 1}: ");
                    scores[i] = Convert.ToInt32(Console.ReadLine());
                    sum += scores[i];
                }

                double average = (double)sum / no_of_matches;

                Console.WriteLine($"\nTotal : {no_of_matches}");
                Console.WriteLine($"Sum : {sum}");
                Console.WriteLine($"Average : {average:F2}");
            }
        }

       class Box
        {
            public int Length { get; set; }
            public int Breadth { get; set; }

            public Box Add(Box b)
            {
                return new Box
                {
                    Length = this.Length + b.Length,
                    Breadth = this.Breadth + b.Breadth
                };
            }

            public void Display()
            {
                Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
            }
        }

        class FileOperations
        {
            public void AppendTextToFile()
            {
                string filePath = "text appended to file";
                Console.Write("\nEnter the text : ");
                string text = Console.ReadLine();

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(text);
                    }

                    Console.WriteLine($" {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing file: {ex.Message}");
                }
            }
        }

        
        public delegate int CalculatorDelegate(int x, int y);

        class Calculator
        {
            public int Add(int a, int b) => a + b;
            public int Subtract(int a, int b) => a - b;
            public int Multiply(int a, int b) => a * b;

            public void ExecuteOperations(int a, int b)
            {
                CalculatorDelegate calc;

                calc = Add;
                Console.WriteLine($"\nAddition: {calc(a, b)}");

                calc = Subtract;
                Console.WriteLine($"Subtraction: {calc(a, b)}");

                calc = Multiply;
                Console.WriteLine($"Multiplication: {calc(a, b)}");
            }
        }

      static void Main(string[] args)
            {
                Console.WriteLine(" Cricket Team ");
                Console.Write("Enter number of matches: ");
                int matches = Convert.ToInt32(Console.ReadLine());
                CricketTeam team = new CricketTeam();
                team.PointsCalculation(matches);

                Console.WriteLine("\n Box Addition ");
                Box box1 = new Box();
                Box box2 = new Box();

                Console.Write("Enter length for Box 1: ");
                box1.Length = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter breadth for Box 1: ");
                box1.Breadth = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter length for Box 2: ");
                box2.Length = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter breadth for Box 2: ");
                box2.Breadth = Convert.ToInt32(Console.ReadLine());
                Box box3 = box1.Add(box2);
                Console.WriteLine("\nBox 3:");
                box3.Display();
                Console.WriteLine("\n File append ");
                FileOperations fileOps = new FileOperations();
                fileOps.AppendTextToFile();
               
                Console.WriteLine("\n Calculator ");
                Console.Write("Enter first number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                Calculator calc = new Calculator();
                calc.ExecuteOperations(num1, num2);
                 Console.ReadLine();

                
            }
        }
    }
   
        
        
    

