using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //added
        private IBookstoreRepository _repository;

        //items per page variable
        public int ItemsPerPage = 5;
        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
                                //pass page 1 as default page to display
        public IActionResult Index(int page=1)
        {
            if (ModelState.IsValid)
            {
                //return #items per page with linq 
                return View(_repository.Books
                    .OrderBy(p=>p.BookID)
                    .Skip((page-1) * ItemsPerPage)
                    .Take(ItemsPerPage)
                    );
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
