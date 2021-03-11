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
        public BuyModel (IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
;        }
        //adds book based on bookID
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId);
           

            Cart.AddItem(book, 1);
            
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //removes book based on bookID
        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            {
                Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookID == bookID).Book);
                return RedirectToPage(new { returnUrl = returnUrl });
            }
        }
    }
}
