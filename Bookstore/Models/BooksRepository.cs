using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //repository for the bookstore site
    public interface BooksRepository
    {
        IQueryable<Books> Books { get; }
    }
}
