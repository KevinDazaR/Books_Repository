using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Important for StatusCodes
using Simulacro1_Solid.Models;
using Simulacro1_Solid.Services;

namespace Simulacro1_Solid.Controllers.Authors
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsUpdateController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsUpdateController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest(new { message = "Author ID mismatch" });
            }

            try
            {
                _authorRepository.Update(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_authorRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Author not found" });
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