using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Catalog.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        [StringLength(450)]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Cover { get; set; }
        public int Year { get; set; }
        public int PublisherID { get; set; }
        public int LanguageID { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        public Publisher Publisher { get; set; }
        public Language Language { get; set; }
        public ICollection<BookGenre> Genres { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
