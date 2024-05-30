using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Data;
using Simulacro1_Solid.Models;
using Simulacro1_Solid.Services.Authors;

namespace Simulacro1_Solid.Services.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BaseContext _context;
        
        public AuthorRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                // Cambiar el estado a 'inactive'
                author.State = "inactive";
                _context.Authors.Update(author);
                _context.SaveChanges();
            }
        }
    }
}
