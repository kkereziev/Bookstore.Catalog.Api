using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Catalog.Entities
{
    public class Language
    {
        public int LanguageID { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
