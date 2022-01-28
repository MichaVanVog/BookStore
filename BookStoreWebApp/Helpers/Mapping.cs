using BookStore.Db.Models;
using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.Helpers
{
    public static class Mapping
    {
        public static List<BookViewModel> ToBookViewModel(List<Book> books)
        {
            if (books == null)
            {
                return null;
            }
            var booksViewModels = new List<BookViewModel>();
            foreach (var book in books)
            {
                var booksViewModel = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ReleaseYear = book.ReleaseYear
                };
                booksViewModels.Add(booksViewModel);
            }
            return booksViewModels;
        }
    }
}
