using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Components
{
    //creating view components
    public class NavigationMenuViewComponent : ViewComponent
    {
        private BooksRepository repository;

        public NavigationMenuViewComponent (BooksRepository r)
        {
            repository = r;
        }

        //return view with queried categories
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
