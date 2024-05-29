using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Models;

namespace Simulacro1_Solid.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll(); // Select * from users
        Author GetById(int id); // Select * from users where id = ?
        void Add(Author author); // Insert into users ()values()
        void Remove(int id); // Delete from users where id = ?
        void Update(Author author); // update set Name='' , LastName='' from user where id = ?
    }
}