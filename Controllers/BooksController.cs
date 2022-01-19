using Bookstore.core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappMongo.DAL.Collection
{
    [ApiController]
    [Route("BooksController")]
    public class BooksController : Controller
    {
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices BookServices)
        {
            _bookServices = BookServices;

        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookServices.GetBooks());

        }
    }
}