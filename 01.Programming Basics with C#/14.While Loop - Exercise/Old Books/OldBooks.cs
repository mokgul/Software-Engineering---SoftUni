using System;

namespace Old_Books
{
    class OldBooks
    {
        static void Main(string[] args)
        {
            int booksChecked = 0;
            string input = "";
            string book = Console.ReadLine();

            while (input != book)
            {
                input = Console.ReadLine();
                if (input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {booksChecked} books.");
                    break;
                }
                if (input != book)
                    booksChecked++;
            }
            if (input == book)
                Console.WriteLine($"You checked {booksChecked} books and found it.");
        }
    }
}
