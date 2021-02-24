using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();
            
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    //add in seed data
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorMiddle = null,
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95m,
                        Pages = 1488
                    },
                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58m,
                        Pages = 944
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorMiddle = null,
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54m,
                        Pages = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61m,
                        Pages = 864
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorMiddle = null,
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33m,
                        Pages = 528
                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorMiddle = null,
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95m,
                        Pages = 288
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorMiddle = null,
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99m,
                        Pages = 304
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorMiddle = null,
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66m,
                        Pages = 240
                    },
                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorMiddle = null,
                        AuthorLast = "Johnson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Fiction",
                        Category = "Business",
                        Price = 29.16m,
                        Pages = 400
                    },
                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorMiddle = null,
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03m,
                        Pages = 642
                    },
                    new Book
                    {
                        Title = "Fahrenheit 451",
                        AuthorFirst = "Ray",
                        AuthorMiddle = null,
                        AuthorLast = "Bradbury",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-1451673265",
                        Classification = "Fiction",
                        Category = "Novel",
                        Price = 24.99m,
                        Pages = 158
                    },
                    new Book
                    {
                        Title = "Uglies",
                        AuthorFirst = "Scott",
                        AuthorMiddle = null,
                        AuthorLast = "Westerfeld",
                        Publisher = "Simon Pulse",
                        ISBN = "978-1442419810",
                        Classification = "Fiction",
                        Category = "Sci-Fi",
                        Price = 9.99m,
                        Pages = 406
                    },
                    new Book
                    {
                        Title = "The Righteous Mind",
                        AuthorFirst = "Jonathan",
                        AuthorMiddle = null,
                        AuthorLast = "Haidt",
                        Publisher = "Vintage",
                        ISBN = "978-0307455772",
                        Classification = "Psychology",
                        Category = "Philosophy",
                        Price = 17.00m,
                        Pages = 371
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
