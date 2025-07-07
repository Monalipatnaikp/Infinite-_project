using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = new List<int> { 10, 5, 15 };
        var result = CalculateMinMaxAvg(numbers);
        Console.WriteLine($"Min: {result.min}, Max: {result.max}, Avg: {result.avg}");
    }

    static (int min, int max, double avg) CalculateMinMaxAvg(IEnumerable<int> numbers)
    {
        int min = numbers.Min();
        int max = numbers.Max();
        double avg = numbers.Average();

        return (min, max, avg);
    }
}
