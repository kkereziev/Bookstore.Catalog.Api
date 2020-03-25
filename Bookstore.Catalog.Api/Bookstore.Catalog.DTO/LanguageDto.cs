using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Catalog.DTO
{
    public class LanguageDto
    {
        public int LanguageID { get; set; }

        public string Name { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}
