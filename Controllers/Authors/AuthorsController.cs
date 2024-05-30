using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1_Solid.Services.Authors;
using Simulacro1_Solid.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro1_Solid.Controllers.Authors
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
   { 
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return _authorRepository.GetAll();
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        
        public IActionResult Details(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
            {
                return NotFound(new { message = "Author not found" });
            }
            return Ok(author);
        }
   } 

}