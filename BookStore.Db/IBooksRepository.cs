using BookStore.Db.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Db
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        public void Buy(Guid bookId);
    }

    
}