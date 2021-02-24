using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Bookstore.Models
{
    public class Book
    {
        //set primary key for db
        [Key]
        public int BookID { get; set; }
        // req field
        [Required]
        public string Title { get; set; }
        //split up author name to normalize db, middle intial not req
        public string AuthorMiddle { get; set; }
        // req field
        [Required]
        public string AuthorLast { get; set; }
        // req field
        [Required]
        public string AuthorFirst { get; set; }
        // req field
        [Required]
        public string Publisher { get; set; }
        // req field, set formatting req for isbn ###-##########
        [Required]
        //[RegularExpression(@"^[0-9]{3}[-]{1}[0-9]{10}$")]
        [RegularExpression(@"^[0-9]{3}[-]{1}[0-9]{10}$", ErrorMessage = "Please enter ISBN in the following format: ###-##########")]
        public string ISBN { get; set; }
        // req field, split classification and category to normalize db
        [Required]
        public string Classification { get; set; }
        // req field
        [Required]
        public string Category { get; set; }
        // req field
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}
