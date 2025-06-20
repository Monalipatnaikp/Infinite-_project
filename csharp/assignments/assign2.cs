using System;

class Program
{
    static void Main()
    {
       

        Console.WriteLine(" Swap Two Numbers");
        Console.Write("Enter first number : ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number : ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Before Swap: a = {a}, b = {b}");
        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine($"After Swap: a = {a}, b = {b}\n");
        Console.WriteLine(" Display Number Four Times");
        Console.Write("Enter a digit: ");
        string digit = Console.ReadLine();
        Console.WriteLine($"{digit} {digit} {digit} {digit}");
        Console.WriteLine($"{digit}{digit}{digit}{digit}\n");
        Console.WriteLine(" Day Number to Day Name");
        Console.Write("Enter day number : ");
        int day = Convert.ToInt32(Console.ReadLine());
        if (day == 1) Console.WriteLine("Monday");
        else if (day == 2) Console.WriteLine("Tuesday");
        else if (day == 3) Console.WriteLine("Wednesday");
        else if (day == 4) Console.WriteLine("Thursday");
        else if (day == 5) Console.WriteLine("Friday");
        else if (day == 6) Console.WriteLine("Saturday");
        else if (day == 7) Console.WriteLine("Sunday");
        else Console.WriteLine("Invalid day number\n");

      
        Console.WriteLine("\nArray Operations (Average, Min, Max)");
        int[] numbers = { 10, 20, 30, 40, 50 };
        int sum = 0;
        int min = numbers[0];
        int max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            if (numbers[i] < min) min = numbers[i];
            if (numbers[i] > max) max = numbers[i];
        }

        double avg = (double)sum / numbers.Length;

        Console.WriteLine("Array Elements: " + string.Join(", ", numbers));
        Console.WriteLine($"Average: {avg}");
        Console.WriteLine($"Minimum: {min}, Maximum: {max}\n");

        
        Console.WriteLine(" Enter 10 Marks for Students");
        int[] marks = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter mark {i + 1}: ");
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }

        int total = 0;
        int minMark = marks[0];
        int maxMark = marks[0];

        for (int i = 0; i < 10; i++)
        {
            total += marks[i];
            if (marks[i] < minMark) minMark = marks[i];
            if (marks[i] > maxMark) maxMark = marks[i];
        }

        double average = (double)total / marks.Length;

        Console.WriteLine($"Total Marks: {total}");
        Console.WriteLine($"Average Marks: {average}");
        Console.WriteLine($"Minimum Mark: {minMark}, Maximum Mark: {maxMark}");
        Array.Sort(marks);
        Console.WriteLine("Ascending Order: " + string.Join(", ", marks));
        Console.Write("Descending Order: ");
        for (int i = marks.Length - 1; i >= 0; i--)
        {
            Console.Write(marks[i] + " ");
        }
        Console.WriteLine("\n");
        Console.WriteLine(" Copy Elements from One Array to Another (No Built-in)");
        int[] source = { 5, 10, 15, 20, 25 };
        int[] destination = new int[source.Length];

        for (int i = 0; i < source.Length; i++)
        {
            destination[i] = source[i];
        }

        Console.WriteLine("Source Array: " + string.Join(", ", source));
        Console.WriteLine("Copied Array: " + string.Join(", ", destination) + "\n");
        Console.WriteLine(" String ");

        // a. Length of a word
        Console.Write("Enter a word to find its length: ");
        string word1 = Console.ReadLine();
        Console.WriteLine($"Length of '{word1}' is: {word1.Length}");

        Console.Write("Enter a word to reverse: ");
        string word2 = Console.ReadLine();
        string reversed = "";
        for (int i = word2.Length - 1; i >= 0; i--)
        {
            reversed += word2[i];
        }
        Console.WriteLine($"Reversed: {reversed}");

        Console.Write("Enter first word: ");
        string w1 = Console.ReadLine();
        Console.Write("Enter second word: ");
        string w2 = Console.ReadLine();

        if (w1 == w2)
            Console.WriteLine("Both words are the SAME.");
        else
            Console.WriteLine("Words are DIFFERENT.");


        Console.ReadLine();
    }
}