using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_challenge1
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("string");

            string word = "Python";
            string result1 = word.Remove(1, 1);
            Console.WriteLine("After removing 1 " + result1);
            string result2 = word.Remove(0, 1);
            Console.WriteLine("After removing  2: " + result2);
            string result3 = word.Remove(4, 1);
            Console.WriteLine("After removing  3: " + result3);

           Console.WriteLine("\n Swap  ");
           string input1 = "abcd";
            string input2 = "a";
            string input3 = "xy";
            Console.WriteLine("original: " + input1 + "  Swap: " + SwapFirstLast(input1));
            Console.WriteLine("Original: " + input2 + "  Swap: " + SwapFirstLast(input2));
            Console.WriteLine("Original: " + input3 + "  Swap: " + SwapFirstLast(input3));

             Console.WriteLine("\n large number ");
            FindLargest(1, 2, 3);
            FindLargest(1, 3, 2);
            FindLargest(1, 1, 1);
            FindLargest(1, 2, 2);
        }
          static string SwapFirstLast(string str)
        {
            if (str.Length <= 1)
            {
                return str; 
            }

            char first = str[0];
            char last = str[str.Length - 1];
            string middle = str.Substring(1, str.Length - 2);
            string newWord = last + middle + first;
            return newWord;
        }
      static void FindLargest(int num1, int num2, int num3)
        {
            int biggest = num1;

            if (num2 > biggest)
            {
                biggest = num2;
            }
            if (num3 > biggest)
            {
                biggest = num3;
            }
            Console.WriteLine("Numbers: " + num1 + ", " + num2 + ", " + num3 + " largest is: " + biggest);
            Console.ReadLine();
            {

            }
        }
    }
}
        
    






