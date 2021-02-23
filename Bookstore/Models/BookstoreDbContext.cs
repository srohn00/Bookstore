using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Bookstore.Models
{
    public class BookstoreDbContext : DbContext
    {
        //set base options here
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
