using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Models;

namespace Simulacro1_Solid.Services.Editorials
{
    public interface IEditorialRepository
    {
        IEnumerable<Editorial> GetAll();
        Editorial GetById(int id);
        void Add(Editorial editorial);
        void Remove(int id);
        void Update(Editorial editorial);
    }
}