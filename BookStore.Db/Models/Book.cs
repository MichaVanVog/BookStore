using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Db.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int ReleaseYear { get; set; }
    }
}
