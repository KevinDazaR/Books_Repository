using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro1_Solid.Services.Books;
using Simulacro1_Solid.Models;

namespace Simulacro1_Solid.Controllers.Books
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        public readonly IBookRepository _bookRepository;
        
        public BookController (IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetById(id);
            
            if(book == null)
            {
                return NotFound(new { message = "Book not found"});
            }
            return Ok(book);
        }

    }
}