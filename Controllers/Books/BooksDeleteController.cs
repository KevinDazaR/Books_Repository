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
    public class BooksDeleteController : ControllerBase
    {
        public readonly IBookRepository _bookRepository;

        public BooksDeleteController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);
            if(book == null)
            {
                return NotFound(new { message = "Book not found" });
            }
            try
            {
                _bookRepository.Remove(id);
            }
            catch(DbUpdateConcurrencyException)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error updating book status.");
            }
            return Ok(new { message = $"book {id} marked as inactive" });
        } 


    }
}