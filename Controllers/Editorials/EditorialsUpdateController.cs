using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro1_Solid.Models;
using Simulacro1_Solid.Services.Editorials;

namespace Simulacro1_Solid.Controllers.Editorials
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialsUpdateController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialsUpdateController(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEditorial(int id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest(new { message = "Editorial ID mismatch" });
            }

            try
            {
                _editorialRepository.Update(editorial);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_editorialRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Editorial not found" });
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