using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_6
{
    class Program
    {
       public class Book
        {
            public string BookName { get; set; }
            public string AuthorName { get; set; }

            public Book(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }
   public void Display()
            {
                Console.WriteLine($"Book: {BookName} | Author: {AuthorName}");
            }
        }

    public class BookShelf
        {
            private Book[] books = new Book[5];

            public Book this[int index]
            {
                get { return books[index]; }
                set { books[index] = value; }
            }
      public void ShowBooks()
            {
                Console.WriteLine("\nBooks in the shelf:");
                foreach (var book in books)
                {
                    book.Display();
                }
            }
        }
   static void Main()
            {
                BookShelf shelf = new BookShelf();

                Console.WriteLine("Enter details of books:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Enter name of Book {i + 1}: ");
                    string bookName = Console.ReadLine();

                    Console.Write($"Enter author of Book {i + 1}: ");
                    string authorName = Console.ReadLine();

                    shelf[i] = new Book(bookName, authorName);
                }

                shelf.ShowBooks();
                Console.Write("\n lines want in a file ");
                int lineCount = int.Parse(Console.ReadLine());

                string[] lines = new string[lineCount];

                for (int i = 0; i < lineCount; i++)
                {
                    Console.Write($"Enter line {i + 1}: ");
                    lines[i] = Console.ReadLine();
                }

                string filePath = "output";
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"\n{lineCount} lines  written to '{filePath}'.");
            Console.ReadLine();
                if (File.Exists(filePath))
                {
                    int totalLines = File.ReadAllLines(filePath).Length;
                    Console.WriteLine($"Total number of lines in '{filePath}': {totalLines}");
                Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' not found.");
                Console.ReadLine();
                }
            }
        }
    }


        
        
    

