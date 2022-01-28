using BookStore.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Db
{
    public class BooksDbRepository : IBooksRepository
    {

        private readonly DatabaseContext databaseContext;

        public BooksDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Book> GetAll()
        {
            return databaseContext.Books.ToList();
        }

        public void Buy (Guid bookId)
        {
            var buyBook = databaseContext.Books.FirstOrDefault(book => book.Id == bookId);
            databaseContext.Books.Remove(buyBook);
            databaseContext.SaveChanges();
        }
    }
}
