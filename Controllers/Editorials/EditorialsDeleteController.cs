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
    public class EditorialDeleteController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialDeleteController(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEditorial(int id)
        {
            var editorial = _editorialRepository.GetById(id);
            if (editorial == null)
            {
                return NotFound(new { message = "Editorial not found" });
            }

            try
            {
                _editorialRepository.Remove(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating editorial status.");
            }

            return Ok(new { message = $"Editorial {id} marked as inactive" });
        }
    }
}