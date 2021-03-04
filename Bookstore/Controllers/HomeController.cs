using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private variable for the repository
        private BooksRepository _repository;

        //variable for items per page requirement
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, BooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //routing the view to output the private repository of Books
        //now routing to view page 1 with only 5 items
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProjectListViewModel
                {
                    Books = _repository.Books
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.BookID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ? _repository.Books.Count() : 
                            _repository.Books.Where(x => x.Category == category).Count()
                    },
                    CurrentCategory = category
            });       
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
