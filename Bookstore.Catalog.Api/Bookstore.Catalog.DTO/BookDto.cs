using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Catalog.DTO
{
    public class BookDto
    {
        public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Cover { get; set; }
        public int Year { get; set; }
        public DateTime ModifiedOn { get; set; }
        public PublisherDto Publisher { get; set; }
        public LanguageDto Language { get; set; }
        public ICollection<BookAuthorDto> Authors { get; set; }
        public ICollection<GenreDto> Genres { get; set; }

    }
}
