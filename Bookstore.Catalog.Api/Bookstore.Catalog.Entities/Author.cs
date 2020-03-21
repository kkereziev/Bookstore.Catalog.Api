using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Catalog.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public int BirthYear { get; set; }
        public string Nationality { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
