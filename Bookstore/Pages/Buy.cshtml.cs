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
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repository;

        //constructor
        public BuyModel (IBookstoreRepository repo)
        {
            repository = repo;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart()
;        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId);

            Cart = HttpContext.Session.SetJson<Cart>("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
