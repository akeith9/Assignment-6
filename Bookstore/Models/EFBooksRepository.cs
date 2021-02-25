using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFBooksRepository : BooksRepository
    {
        private BooksContext _context;

        //Constructor
        public EFBooksRepository (BooksContext context)
        {
            _context = context;
        }

        public IQueryable<Books> Books => _context.Books;
    }
}
