using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Catalog.DTO
{
    public class PublisherDto
    {
        public int PublisherID { get; set; }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}
