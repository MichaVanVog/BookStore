using BookStore.Db;
using BookStore.Db.Models;
using BookStore.Models;
using BookStoreWebApp.Helpers;
using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository booksRepository;
        public HomeController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public async Task<IActionResult> Index(SortState sortOrder = SortState.TitleAsc)
        {
            var books = await booksRepository.GetAllAsync();
            var queryableBooks = books.AsQueryable();
            ViewData["TitleSort"] = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            ViewData["AuthorSort"] = sortOrder == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            ViewData["ReleaseYear"] = sortOrder == SortState.ReleaseYearAsc ? SortState.ReleaseYearDesc : SortState.ReleaseYearAsc;

            queryableBooks = sortOrder switch
            {
                SortState.TitleAsc => queryableBooks.OrderBy(queryableBooks => queryableBooks.Title),
                SortState.TitleDesc => queryableBooks.OrderByDescending(queryableBooks => queryableBooks.Title),
                SortState.AuthorAsc => queryableBooks.OrderBy(queryableBooks => queryableBooks.Author),
                SortState.AuthorDesc => queryableBooks.OrderByDescending(queryableBooks => queryableBooks.Author),
                SortState.ReleaseYearAsc => queryableBooks.OrderBy(queryableBooks => queryableBooks.ReleaseYear),
                SortState.ReleaseYearDesc => queryableBooks.OrderByDescending(queryableBooks => queryableBooks.ReleaseYear),
                _ => queryableBooks.OrderBy(queryableBooks => queryableBooks.Title)
            };
            books = queryableBooks.ToList();
            return View(Mapping.ToBookViewModel(books));
        }

        public async Task<IActionResult> BuyAsync(Guid bookId)
        {
            await booksRepository.BuyAsync(bookId);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
