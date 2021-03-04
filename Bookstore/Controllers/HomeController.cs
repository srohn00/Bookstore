using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//add in viewmodels
using Bookstore.Models.ViewModels;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //added
        private IBookstoreRepository _repository;

        //items per page variable
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
                                //pass page 1 as default page to display
        public IActionResult Index(string category, int page=1)
        {
            if (ModelState.IsValid)
            {
                //return #items per page with linq 
                return View(new BookListViewModel
                {
                    Books = _repository.Books
                            //filter
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
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
