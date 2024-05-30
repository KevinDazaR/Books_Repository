using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Data;
using Simulacro1_Solid.Models;
using Simulacro1_Solid.Services.Editorials;

namespace Simulacro1_Solid.Services.Editorials
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly BaseContext _context;
        
        public EditorialRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Editorial> GetAll()
        {
            return _context.Editorials.ToList();
        }

        public Editorial GetById(int id)
        {
            return _context.Editorials.Find(id);
        }

        public void Add(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            _context.SaveChanges();
        }

        public void Update(Editorial editorial)
        {
            _context.Editorials.Update(editorial);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var editorial = _context.Editorials.Find(id);
            if (editorial != null)
            {
                // Cambiar el estado a 'inactive'
                editorial.State = "inactive";
                _context.Editorials.Update(editorial);
                _context.SaveChanges();
            }
        }
    }
}