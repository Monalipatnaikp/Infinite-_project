using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Remove character at given position");
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        Console.Write("Enter the position : ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index >= 0 && index < word.Length)
        {
            string newWord = word.Remove(index, 1);
            Console.WriteLine("Result: " + newWord);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }

     
        Console.WriteLine("\n  Swap first and last character");
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string swapped = SwapFirstLast(input);
        Console.WriteLine("Result: " + swapped);

      
        Console.WriteLine("\n  Find largest among three numbers ");
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        int largest = FindLargest(num1, num2, num3);
        Console.WriteLine("The largest number is: " + largest);
    }

    static string SwapFirstLast(string str)
    {
        if (str.Length <= 1)
            return str;

        char first = str[0];
        char last = str[str.Length - 1];
        string middle = str.Substring(1, str.Length - 2);

        return last + middle + first;
    }

    static int FindLargest(int a, int b, int c)
    {
        int max = a;

        if (b > max)
            max = b;

        if (c > max)
            max = c;

        return max;
        Console.ReadLine();
    }
}

