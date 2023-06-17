using Library.Data;
using Library.Models.Book;
using Library.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Library.Data.Models;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext _data;

        public BookController(LibraryDbContext _context)
        {
            _data = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var books = await _data.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();

            return View(books);
        }

        public async Task<IActionResult> Mine()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var books = await _data.Books
                .Where(b => b.UsersBooks.Any(ub => ub.CollectorId == userId))
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _data.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            BookFormModel model = new BookFormModel()
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            };

            Book newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.Url,
                Rating = book.Rating,
                CategoryId = book.CategoryId
            };
            await _data.Books.AddAsync(newBook);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var book = await _data.Books.FirstOrDefaultAsync(b => b.Id == id);

            try
            {
                if (!book.UsersBooks.Any(ub => ub.CollectorId == userId))
                {
                    book.UsersBooks.Add(new IdentityUserBook()
                    {
                        BookId = id,
                        CollectorId = userId
                    });
                }
                await _data.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var book = await _data.UsersBooks.FirstOrDefaultAsync(ub => ub.BookId == id && ub.CollectorId == userId);
            try
            {
                if (book != null)
                {
                    _data.UsersBooks.Remove(book);
                    await _data.SaveChangesAsync();
                }
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("Mine", "Book");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _data.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            var book = await _data.Books.FirstOrDefaultAsync(b => b.Id == id);

            BookEditModel model = new BookEditModel()
            {
                Id= book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Url = book.ImageUrl,
                Rating = book.Rating,
                CategoryId = book.CategoryId,
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditModel book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var bookToEdit = await _data.Books.FirstOrDefaultAsync(b => b.Id == book.Id);

            bookToEdit.Title = book.Title;
            bookToEdit.Author = book.Author;
            bookToEdit.Description = book.Description;
            bookToEdit.ImageUrl = book.Url;
            bookToEdit.Rating = book.Rating;
            bookToEdit.CategoryId = book.CategoryId;

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Book");
        }
    }
}
