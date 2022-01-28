using BookStore.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Db
{
    public class BooksDbRepository : IBooksRepository
    {

        private readonly DatabaseContext databaseContext;

        public BooksDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await databaseContext.Books.ToListAsync();
        }

        public async Task BuyAsync (Guid bookId)
        {
            var buyBook = await databaseContext.Books.FirstOrDefaultAsync(book => book.Id == bookId);
            databaseContext.Books.Remove(buyBook);
            databaseContext.SaveChanges();
        }
    }
}
