using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Data;
using Simulacro1_Solid.Models;
using Microsoft.EntityFrameworkCore; // Importante para el include
using Simulacro1_Solid.Services.Books;

namespace Simulacro1_Solid.Services.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly BaseContext _baseContext;

        public BookRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public IEnumerable<Book> GetAll()
        {
             return _baseContext.Books
                .Include(b => b.Author)
                .Include(b => b.Editorial)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _baseContext.Books
                .Include(b => b.Author)
                .Include(b => b.Editorial)
                .FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            _baseContext.Books.Add(book);
            _baseContext.SaveChanges();
        } 

        public void Update(Book book)
        {
            _baseContext.Books.Update(book);
            _baseContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var book = _baseContext.Books.Find(id);

            if(book != null)
            {
                book.State="inactive";
                _baseContext.Books.Update(book);
                _baseContext.SaveChanges();
            }
        }


    }
}