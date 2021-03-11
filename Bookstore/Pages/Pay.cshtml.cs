using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class PayModel : PageModel
    {
        private BooksRepository repository;

        //constructor
        public PayModel (BooksRepository repo, Cart cartservice)
        {
            repository = repo;
            Cart = cartservice;
        }
        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long BookID, string returnUrl)
        {
            Books books = repository.Books.FirstOrDefault(p => p.BookID == BookID);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(books, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Books.BookID == BookID).Books);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
