using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro1_Solid.Services.Editorials;
using Simulacro1_Solid.Models;

namespace Simulacro1_Solid.Controllers.Editorials
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialCreateController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialCreateController(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        [HttpPost]
        public IActionResult Create(Editorial editorial)
        {
           _editorialRepository.Add(editorial);
           return CreatedAtAction(nameof(Create),new {id = editorial.Id},"Editorial created successfully");
        }
    }
}