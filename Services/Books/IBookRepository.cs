using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Models;

namespace Simulacro1_Solid.Services.Books
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Remove(int id);
        void Update(Book book);
    }
}