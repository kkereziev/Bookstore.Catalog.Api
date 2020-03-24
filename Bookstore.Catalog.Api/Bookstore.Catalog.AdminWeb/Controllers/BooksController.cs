using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bookstore.Catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bookstore.Catalog.AdminWeb.Controllers
{
    public class BooksController : Controller
    {
        private string baseUrl = "https://localhost:44320/";
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var booksUrl = $"{baseUrl}/api/books";
                var booksResponse = await client.GetStringAsync(booksUrl);



                var books = JsonConvert.DeserializeObject<List<Book>>(booksResponse);



                return View(books);
            }
        }



        public async Task<IActionResult> Get(int id)
        {
            using (var client = new HttpClient())
            {
                var booksUrl = $"{baseUrl}/api/books/{id}";
                var booksResponse = await client.GetStringAsync(booksUrl);
                var books = JsonConvert.DeserializeObject<Book>(booksResponse);



                return View(books);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
    }
}
