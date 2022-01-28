using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Наименование"), Required(ErrorMessage = "Наименование книги обязательно")]
        public string Title { get; set; }

        [Display(Name = "Автор"), Required(ErrorMessage = "Необходимо указать автора")]
        public string Author { get; set; }

        [Display(Name = "Год"), Required(ErrorMessage = "Необходимо указать год издания книги")]
        public int ReleaseYear { get; set; }
    }
}
