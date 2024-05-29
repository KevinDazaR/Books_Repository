using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Important for StatusCodes
using Simulacro1_Solid.Services;
using Simulacro1_Solid.Models;

namespace Simulacro1_Solid.Controllers.Authors
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        
        public AuthorsController(IAuthorRepository authorRepository){
            _authorRepository = authorRepository;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Author author)
        {
            _authorRepository.Add(author);
            return CreatedAtAction(nameof(Create), new { id = author.Id }, "Author created successfully");
        }

    }
}