using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //set repository
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
