using System.Globalization;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //02. Age Restriction
            //Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()!));

            //03. GetGoldenBooks
            //Console.WriteLine(GetGoldenBooks(db));

            //04.Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            //05. Not Released In
            //Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(Console.ReadLine()!)));

            //06.Book Titles by Category
            //Console.WriteLine(GetBooksByCategory(db, Console.ReadLine()!));

            //07.Released Before Date
            //Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()!));

            //08.Author Search
            //Console.WriteLine(GetAuthorNamesEndingIn(db, Console.ReadLine()!));

            //09. Book Search
            //Console.WriteLine(GetBookTitlesContaining(db, Console.ReadLine()!));

            //10. Book Search by Author
            //Console.WriteLine(GetBooksByAuthor(db, Console.ReadLine()!));

            //11. Count Books
            //Console.WriteLine(CountBooks(db, int.Parse(Console.ReadLine()!)));

            //12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            //13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(db));

            //15. Increase Prices
            //IncreasePrices(db);

            //16. Remove Books
            //RemoveBooks(db);

        }

        //02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine($"{book.Title}");
            return sb.ToString().TrimEnd();

        }

        //03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine(book.Title);

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40m)
                .OrderByDescending(b => b.Price)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine(book.Title);

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            StringBuilder sb = new StringBuilder();

            //var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //var command2 = string.Join(" ", command);

            var books = context.BooksCategories
                .Where(b => input
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Contains(b.Category.Name.ToLower()))
                .Select(c => new
                {
                    BookTitle = c.Book.Title
                })
                .OrderBy(t => t.BookTitle)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine(book.BookTitle);

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            
            StringBuilder sb = new StringBuilder();
            var dateToDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            
            var books = context.Books
                .OrderByDescending(d => d.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Date = b.ReleaseDate.Value,
                    Edition = b.EditionType,
                    Price = b.Price,

                })
                .Where(d => d.Date < dateToDate)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine($"{book.Title} - {book.Edition.ToString()} - ${book.Price:f2}");

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(n => new
                {
                    FullName = n.FirstName + " " + n.LastName,
                })
                .OrderBy(n => n.FullName)
                .AsNoTracking()
                .ToArray();

            foreach (var auth in authors)
                sb.AppendLine(auth.FullName);

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(t => t.Title)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine(book.Title);

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(a => a.Author.LastName
                    .ToLower()
                    .StartsWith(input.ToLower()))
                .Select(b => new
                {
                    Title = b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName,
                    Id = b.BookId
                })
                .OrderBy(i => i.Id)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
                sb.AppendLine($"{book.Title} ({book.FullName})");

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .AsNoTracking()
                .ToArray();
            return books.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(b => new
                {
                    FullName = b.FirstName + " " + b.LastName,
                    Copies = b.Books.Sum(c => c.Copies),
                })
                .OrderByDescending(c => c.Copies)
                .AsNoTracking()
                .ToArray();

            foreach (var auth in authors)
                sb.AppendLine($"{auth.FullName} - {auth.Copies}");

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var profits = context.Categories

                .Select(b => new
                {
                    Category = b.Name,
                    Profit = b.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price)
                })
                .OrderByDescending(p => p.Profit)
                .ThenBy(n => n.Category)
                .AsNoTracking()
                .ToArray();

            foreach (var profit in profits)
                sb.AppendLine($"{profit.Category} ${profit.Profit:f2}");

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Category = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Select(b => new
                        {
                            Title = b.Book.Title,
                            Year = b.Book.ReleaseDate.Value.Year
                        })
                        .Take(3)
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            foreach (var cat in books)
            {
                sb.AppendLine($"--{cat.Category}");
                foreach (var book in cat.Books)
                    sb.AppendLine($"{book.Title} ({book.Year})");
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
                book.Price += 5;

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Length;
        }
    }
}


