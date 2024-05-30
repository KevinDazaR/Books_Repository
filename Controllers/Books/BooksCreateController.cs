using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro1_Solid.Models;
using Simulacro1_Solid.Services.Books;

namespace Simulacro1_Solid.Controllers.Books
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksCreateController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksCreateController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]

        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest(new { message = "Book is required" });
            }

            _bookRepository.Add(book);
            
            return CreatedAtAction(nameof(CreateBook),new {id = book.Id},"Book created successfully");
        }
    }
}