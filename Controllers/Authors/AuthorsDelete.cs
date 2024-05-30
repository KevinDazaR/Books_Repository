using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro1_Solid.Services.Authors;
using Simulacro1_Solid.Models;


namespace Simulacro1_Solid.Controllers.Authors
{
    [ApiController] 
    [Route("api/[controller]")]
    public class AuthorsDelete : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsDelete(IAuthorRepository authorRepository){
            _authorRepository = authorRepository;
        }

         // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
            {
                return NotFound(new { message = "Author not found" });
            }

            try
            {
                _authorRepository.Remove(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating author status.");
            }

            return Ok(new { message = $"Author {id} marked as inactive" });
        }
    }
}