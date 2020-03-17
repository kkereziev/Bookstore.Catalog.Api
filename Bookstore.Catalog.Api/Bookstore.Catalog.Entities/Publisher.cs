using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Catalog.Entities
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
