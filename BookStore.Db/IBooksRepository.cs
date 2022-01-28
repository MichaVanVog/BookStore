using BookStore.Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Db
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetAllAsync();
        public Task BuyAsync(Guid bookId);
    }

    
}