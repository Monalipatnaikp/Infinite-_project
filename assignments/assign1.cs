using System;

class Assignment
{
    static void Main()
    {
        
        Console.WriteLine(" Check if two integers are equal");
        Console.Write("Input 1st number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input 2nd number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 == num2)
            Console.WriteLine($"{num1} and {num2} are equal");
        else
            Console.WriteLine($"{num1} and {num2} are not equal");

        Console.WriteLine(); 

      
        Console.WriteLine(" Check if a number is positive or negative");
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
            Console.WriteLine($"{number} is a positive number");
        else if (number < 0)
            Console.WriteLine($"{number} is a negative number");
        else
            Console.WriteLine("The number is zero");

        Console.WriteLine(); 

       
        Console.WriteLine("3. Perform arithmetic operation on two numbers");
        Console.Write("Input first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input operation (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        Console.Write("Input second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine($"{a} + {b} = {a + b}");
                break;
            case '-':
                Console.WriteLine($"{a} - {b} = {a - b}");
                break;
            case '*':
                Console.WriteLine($"{a} * {b} = {a * b}");
                break;
            case '/':
                if (b != 0)
                    Console.WriteLine($"{a} / {b} = {a / b}");
                else
                    Console.WriteLine("Division by zero is not allowed.");
                break;
            default:
                Console.WriteLine("Invalid operator.");
                break;
        }

        Console.WriteLine(); 

        
        Console.WriteLine("4. Multiplication table of a number");
        Console.Write("Enter a number to print its multiplication table: ");
        int tableNum = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{tableNum} x {i} = {tableNum * i}");
        }

        Console.WriteLine();

    
        Console.WriteLine(" Swap two numbers");
        Console.Write("Enter first number: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Before Swap: x = {x}, y = {y}");

        int temp = x;
        x = y;
        y = temp;

        Console.WriteLine($"After Swap: x = {x}, y = {y}");

        Console.WriteLine(); 
        Console.WriteLine("6. Sum of two integers (triple the sum if same)");
        Console.Write("Enter first number: ");
        int first = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int second = Convert.ToInt32(Console.ReadLine());

        int result = (first == second) ? 3 * (first + second) : (first + second);
        Console.WriteLine("Result: " + result);
    }
}