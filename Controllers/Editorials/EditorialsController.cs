using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1_Solid.Services.Editorials;
using Simulacro1_Solid.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro1_Solid.Controllers.Editorials
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialController(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        [HttpGet]
        public IEnumerable<Editorial> GetEditorials()
        {
            return _editorialRepository.GetAll();
        }

        // GET: api/editorials/5
        [HttpGet("{id}")]

        public IActionResult Details(int id)
        {
            var editorial = _editorialRepository.GetById(id);
            if (editorial == null)
            {
                return NotFound(new { message = "Editorial not found" });
            }

            return Ok(editorial);
        }
    }
}