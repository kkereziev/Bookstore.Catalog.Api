using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Catalog.DTO
{
    public class BookAuthorDto
    {
        public int Position { get; set; }

        public BookDto Book { get; set; }

        public AuthorDto Author { get; set; }
    }
}
