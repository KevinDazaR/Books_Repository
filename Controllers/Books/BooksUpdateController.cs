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
    public class BooksUpdateController : ControllerBase
    {
        public readonly IBookRepository _bookRepository;

        public BooksUpdateController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if(id != book.Id)
            {
                return BadRequest(new { message = "Book ID mismatch" });
            }
            try
            {
                _bookRepository.Update(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_bookRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Book not found" });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}