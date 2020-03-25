using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Catalog.DTO
{
    public class AuthorDto
    {
        public int AuthorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string About { get; set; }

        public int BirthYear { get; set; }

        public string Nationality { get; set; }

        public ICollection<BookAuthorDto> Books { get; set; }
    }
}
