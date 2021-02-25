using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //creating inheritable context for the books db
    public class BooksContext : DbContext
    {
        public BooksContext (DbContextOptions<BooksContext> options) : base (options)
        {

        }

        public DbSet<Books> Books { get; set; }

    }
}
