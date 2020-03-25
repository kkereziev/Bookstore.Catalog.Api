using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookstore.Catalog.Api;
using Bookstore.Catalog.Entities;
using Bookstore.Catalog.DTO;

namespace Bookstore.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public BooksController(CatalogDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books
                .Include(x=>x.BookAuthors)
                .Include(x=>x.Genres)
                .Include(x=>x.Publisher)
                .Include(x=>x.Language)
                .ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(x => x.BookAuthors)
                .Include(x => x.Genres)
                .Include(x => x.Publisher)
                .Include(x => x.Language)
                .SingleOrDefaultAsync(x => x.BookID == id);
            

            if (book == null)
            {
                return NotFound();
            }
            var bookDto = new BookDto()
            {
                BookID=book.BookID,
                Title=book.Title,
                Description=book.Description,
                Cover=book.Cover,
                ISBN=book.ISBN,
                Year=book.Year,
                Price=book.Price,
                Language=new LanguageDto() { LanguageID=book.LanguageID, Name=book.Language.Name},
                Publisher = new PublisherDto()
                {
                    PublisherID=book.PublisherID,
                    CompanyName=book.Publisher.CompanyName,
                    Country=book.Publisher.Country
                },
                ModifiedOn=book.ModifiedOn,
                Authors=book.BookAuthors.Select(x=>new BookAuthorDto()
                {
                    Position=x.Position,
                    Author=new AuthorDto()
                    {
                        AuthorID = x.Author.AuthorID,
                        FirstName=x.Author.FirstName,
                        LastName=x.Author.LastName,
                        Nationality=x.Author.Nationality
                    }
                }).ToList(),
                Genres=book.Genres.Select(x=> new GenreDto()
                {
                    GenreID=x.Ganre.GenreID,
                    Name=x.Ganre.Name
                }).ToList()
            };

            return bookDto;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookID }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
