using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1_Solid.Models;
using Microsoft.EntityFrameworkCore;
using Simulacro1_Solid.Services;

namespace Simulacro1_Solid.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) 
        {
        }
        
        // internal object author;
        public DbSet<Author> Authors {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<Editorial> Editorials {get; set;}
        
    }


}