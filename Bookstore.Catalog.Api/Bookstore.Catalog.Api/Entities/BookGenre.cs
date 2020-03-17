using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Catalog.Api.Entities
{
    public class BookGenre
    {
        public int BookID { get; set; }
        public int GenreID { get; set; }

        public Genre Ganre { get; set; }
        public Book Book { get; set; }
    }
}
